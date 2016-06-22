using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HMA.Helpers;
using HMA.MLA;
using HMA.Models;
using HMA.Repositories;
using HMA.Repositories.Interfaces;
using HMA.Services;
using HMA.Services.Interfaves;

namespace HMA
{
  public partial class HMA : Form
  {
    private readonly IDataRepository _dataRepository = new ExcelRepository();
    private readonly IWeatherService _weatherService = new WeatherService();
    private List<ComingHomeModel> _list = new List<ComingHomeModel>();
    private NuralNetworkPredictionAlgorithm _predict;
    private double _predictANN;
    private double _predictRL;
    private double _predictWma;
    private bool currentState = true;
    private string selectedWeekday;

    public HMA()
    {
      InitializeComponent();
      PrepareDataTable();
      Closed += (x, e) => { _dataRepository.SaveData(_list); };

      comboBox1.SelectedIndex = 0;
    }

    private void PrepareDataTable()
    {
      try
      {
        _list = _dataRepository.GetData();
      }
      catch (Exception e)
      {
        MessageBox.Show(e.Message);
      }
    }

    private void SetText(string text)
    {
      if (InvokeRequired)
      {
        Invoke(new MethodInvoker(delegate { SetText(text); }));
      }
      else
      {
        textBox1.Text = text;
      }
    }

    private void bGetWeather_Click(object sender, EventArgs e)
    {
      var task = _weatherService.GetTodaysTemperature();
      task.ContinueWith(x => { SetText(task.Result.ToString(CultureInfo.InvariantCulture)); }
        );
    }

    private void bImHome_Click(object sender, EventArgs e)
    {
      var currentDateTime = DateTime.Now;
      var model = new ComingHomeModel
      {
        Date = currentDateTime.Date,
        Hour = currentDateTime.Hour.ToString(),
        Minutes = currentDateTime.Minute.ToString()
      };

      _list.Add(model);
    }

    private List<ComingHomeModel> GetAllModelForWeekday(string weekDayText)
    {
      var day = GetWeekDay(weekDayText);
      var listOdWeekDay = _list.Where(x => x.Date.DayOfWeek == day);
      return listOdWeekDay.ToList();
    }

    private DayOfWeek GetWeekDay(string weekDayText)
    {
      if (weekDayText.Equals("Poniedziałek"))
        return DayOfWeek.Monday;
      if (weekDayText.Equals("Wtorek"))
        return DayOfWeek.Tuesday;
      if (weekDayText.Equals("Środa"))
        return DayOfWeek.Wednesday;
      if (weekDayText.Equals("Czwartek"))
        return DayOfWeek.Thursday;
      if (weekDayText.Equals("Piątek"))
        return DayOfWeek.Friday;
      if (weekDayText.Equals("Sobota"))
        return DayOfWeek.Saturday;
      if (weekDayText.Equals("Niedziela"))
        return DayOfWeek.Sunday;

      throw new Exception("nie wybrano dnia tygodnia");
    }

    private void bExecuteAlgorthm_Click(object sender, EventArgs e)
    {
      tbPredictedValue.Text = "";
      selectedWeekday = comboBox1.SelectedItem.ToString();
      RunANN();
    }

    private void RunANN()
    {
      var list = GetAllModelForWeekday(selectedWeekday);
      var takeNumber = HowManyTake(list.Count);
      var comeHomingValues =
        list.OrderByDescending(u => u.Date)
          .Select(z => new TimeSpan(0,int.Parse(z.Hour), int.Parse(z.Minutes), 0))
          .Take(takeNumber)
          .ToList();
      if (takeNumber < 40)
      {
        var random = new Random();
        for (var i = takeNumber; i < 40; i++)
        {
          comeHomingValues.Add(comeHomingValues[random.Next(takeNumber)]);
        }
      }
      var comeHomingHourValues =
        comeHomingValues.Select(y => TimeConverter.ConvertFromTimeToDouble(y.TotalMinutes)).ToArray();

      _predict = new NuralNetworkPredictionAlgorithm(comeHomingHourValues);
      _predict.Execute();


      _predict.PredictValue();

      _predictANN = _predict.GetPredictedValue();
    }

    private int HowManyTake(int count)
    {
      var howManyTens = count/10;
      return 10*howManyTens;
    }

    public void AppendTextBox(string value, TextBox tb)
    {
      if (InvokeRequired)
      {
        Invoke(new Action<string, TextBox>(AppendTextBox), value, tb);
        return;
      }
      tb.Text += value;
    }

    private void bLienearRegression_Click(object sender, EventArgs e)
    {
      tBRlPredictedValue.Text = "";
      selectedWeekday = comboBox1.SelectedItem.ToString();
      RunRl();
    }

    private void RunRl()
    {
      var list = GetAllModelForWeekday(selectedWeekday);
      var takeNumber = list.Count;
      var comeHomingValues =
        list.OrderByDescending(u => u.Date)
          .Select(z => new TimeSpan(0, int.Parse(z.Hour), int.Parse(z.Minutes), 0))
          .Take(takeNumber)
          .ToList();
      var xs = new double[takeNumber];
      var value = 0.1;
      for (var i = 0; i < xs.Length; i++)
      {
        xs[i] = value;
        value += 0.1;
      }
      var comeHomingHourValues =
        comeHomingValues.Select(y => TimeConverter.ConvertFromTimeToDouble(y.TotalMinutes)).ToArray();
      double r;
      double yintercept;
      double slope;
      LinearRegression.Execute(xs, comeHomingHourValues, 1, takeNumber - 1, out r, out yintercept, out slope);
      var predictionValue = slope*(value + 0.1) + yintercept;
      _predictRL = predictionValue;
    }

    private void bImOut_Click(object sender, EventArgs e)
    {
      tbWma.Text = "";
      tBRlPredictedValue.Text = "";
      tbPredictedValue.Text = "";
      selectedWeekday = comboBox1.SelectedItem.ToString();

      var doPredictionsTask = new Task(() =>
      {
        try
        {
          RunRl();
          RunANN();
          RunWma();
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message);
        }
      });
      doPredictionsTask.Start();
      doPredictionsTask.Wait();
      AppendTextBox(TimeConverter.ConvertFromDoubleToTime(_predictWma).ToString(), tbWma);
      AppendTextBox(TimeConverter.ConvertFromDoubleToTime(_predictRL).ToString(), tBRlPredictedValue);
      AppendTextBox(TimeConverter.ConvertFromDoubleToTime(_predictANN).ToString(), tbPredictedValue);
      var valueAnn = TimeSpan.Parse(tbPredictedValue.Text, CultureInfo.InvariantCulture);
      var newValue = new TimeSpan(0,valueAnn.Minutes,valueAnn.Seconds,0);
      tbHeatingStart.Text ="00:"+
        TimeSpan.FromSeconds(newValue.TotalSeconds-HeaterService.CalculateHeaterUseTime(0.8, 20, 17100,13500).TotalSeconds);
      var valueWma = TimeSpan.Parse(tbWma.Text, CultureInfo.InvariantCulture);
      var newValueWma = new TimeSpan(0, valueWma.Minutes, valueWma.Seconds, 0);
      tbWmaHeatingStart.Text = "00:" +
        TimeSpan.FromSeconds(newValueWma.TotalSeconds - HeaterService.CalculateHeaterUseTime(0.8, 20, 17100,13500).TotalSeconds);
      var valueRl = TimeSpan.Parse(tbWma.Text, CultureInfo.InvariantCulture);
      var newValueRl = new TimeSpan(0, valueRl.Minutes, valueRl.Seconds, 0);
      tbRlStartHeating.Text = "00:" +
        TimeSpan.FromSeconds(newValueRl.TotalSeconds - HeaterService.CalculateHeaterUseTime(0.8, 20, 17100,13500).TotalSeconds);
    }

    private void bChangeHeaterState_Click(object sender, EventArgs e)
    {
      var hs = new HeaterService();
      currentState = !currentState;
      hs.ChangeHeaterState(currentState);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      selectedWeekday = comboBox1.SelectedItem.ToString();
      tbWma.Text = "";
      RunWma();
    }


    private void RunWma()
    {
      var list = GetAllModelForWeekday(selectedWeekday);
      var takeNumber = list.Count;
      var comeHomingValues =
        list.OrderByDescending(u => u.Date)
          .Select(z => new TimeSpan(0, int.Parse(z.Hour), int.Parse(z.Minutes), 0))
          .Take(takeNumber)
          .ToList();

      var prediction =
        WMA.WeightedMovingAverage(
          comeHomingValues.Select(y => TimeConverter.ConvertFromTimeToDouble(y.TotalMinutes)).ToArray(), 1,
          0.05, 0.15, 0.20, 0.25, 0, 0.35);
      _predictWma = prediction.Value;
    }
  }
}