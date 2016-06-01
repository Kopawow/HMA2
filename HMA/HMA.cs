using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
    private List<ComingHomeModel> _list = new List<ComingHomeModel>();
    private readonly IWeatherService _weatherService = new WeatherService();
    private readonly IDataRepository _dataRepository= new ExcelRepository();
      private NuralNetworkPredictionAlgorithm _predict;
    public HMA()
    {
      InitializeComponent();
      PrepareDataTable();
      Closed+= (x,e) =>
      {
        _dataRepository.SaveData(_list);
      };
    }

    private void PrepareDataTable()
    {
      try
      {
        _list = _dataRepository.GetData();
      }
      catch(Exception e)
      {
        MessageBox.Show(e.Message);
      }
    }

    private void SetText(string text)
    {
      if (this.InvokeRequired)
      {
        Invoke(new MethodInvoker(delegate () {
          SetText(text);
        }));
      }
      else
      {
        this.textBox1.Text = text;
      }
    }

    private void bGetWeather_Click(object sender, EventArgs e)
    {
      var task = _weatherService.GetTodaysTemperature();
      task.ContinueWith(x =>
      {
        SetText(task.Result.ToString(CultureInfo.InvariantCulture));
      }
      );
    }
  
    private void bImHome_Click(object sender, EventArgs e)
    {
      var currentDateTime = DateTime.Now;
      var model = new ComingHomeModel()
      {
        Date = currentDateTime.Date,
        Hour = currentDateTime.Hour.ToString(),
        Minutes = currentDateTime.Minute.ToString()
      };

      _list.Add(model);
    }

    private List<ComingHomeModel> GetAllModelForWeekday()
    {
      var day = DateTime.Now.DayOfWeek;
      var listOdWeekDay = _list.Where(x => x.Date.DayOfWeek == day);
      return listOdWeekDay.ToList();
    }

    private void bExecuteAlgorthm_Click(object sender, EventArgs e)
      {
          tbPredictedValue.Text = "";
          Thread neuralThread = new Thread(x =>
          {
              var list = GetAllModelForWeekday();
              var takeNumber = HowManyTake(list.Count);
              var comeHomingValues =
                  list.OrderByDescending(u => u.Date)
                      .Select(z => new TimeSpan(0, int.Parse(z.Hour), int.Parse(z.Minutes), 0))
                      .Take(takeNumber)
                      .ToList();
              if (takeNumber < 40)
              {
                  var random = new Random();
                  for (int i = takeNumber; i < 40; i++)
                  {
                      comeHomingValues.Add(comeHomingValues[random.Next(takeNumber)]);
                  }
                  
              }
              var comeHomingHourValues =
                  comeHomingValues.Select(y => TimeConverter.ConvertFromTimeToDouble(y.TotalMinutes)).ToArray();
             
                  _predict = new NuralNetworkPredictionAlgorithm(comeHomingHourValues);
                  _predict.Execute();
              

              _predict.PredictValue();
              
              AppendTextBox(TimeConverter.ConvertFromDoubleToDateTime(_predict.GetPredictedValue()).ToString(),tbPredictedValue);
          });

          neuralThread.Start();
      }

      private int HowManyTake(int count)
      {
          var howManyTens = count/10;
          return 10*howManyTens;
      }

      public void AppendTextBox(string value,TextBox tb)
    {
        if (InvokeRequired)
        {
            this.Invoke(new Action<string,TextBox>(AppendTextBox), new object[] { value,tb});
            return;
        }
        tb.Text += value;
    }

        private void bLienearRegression_Click(object sender, EventArgs e)
        {
            tBAnimaPredictedValue.Text = "";
            var list = GetAllModelForWeekday();
            var takeNumber = list.Count;
            var comeHomingValues =
                list.OrderByDescending(u => u.Date)
                    .Select(z => new TimeSpan(0, int.Parse(z.Hour), int.Parse(z.Minutes), 0))
                    .Take(takeNumber)
                    .ToList();
            double[] xs = new double[takeNumber];
            double value = 0.1;
            for (var i = 0 ; i<xs.Length;i++)
            {
                xs[i] = value ;
                value += 0.1;
            }
            var comeHomingHourValues =
                comeHomingValues.Select(y => TimeConverter.ConvertFromTimeToDouble(y.TotalMinutes)).ToArray();
            double r;
            double yintercept;
            double slope;
            LinearRegression.Execute(xs,comeHomingHourValues,1, takeNumber-1, out r, out yintercept,out slope);
            double predictionValue = slope*(value + 0.1) + yintercept;
            AppendTextBox(TimeConverter.ConvertFromDoubleToDateTime(predictionValue).ToString(), tBAnimaPredictedValue);
        }
    }
}
