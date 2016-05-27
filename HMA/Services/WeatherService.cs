using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using HMA.Services.Interfaves;

namespace HMA.Services
{
  public class WeatherService:IWeatherService
  {
    public async Task<double> GetTodaysTemperature()
    {
      string weburl = "http://api.openweathermap.org/data/2.5/forecast/city?id=3081368&APPID=c7cd5ea156fa1a32bde78b54d0beaae1&mode=xml&units=metric&cnt=1";

      try
      {
        var result = await new WebClient().DownloadStringTaskAsync(new Uri(weburl));
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(result);
        string szTemp = doc.DocumentElement.SelectSingleNode("forecast").SelectSingleNode("time").SelectSingleNode("temperature").Attributes["value"].Value;
        double temp = double.Parse(szTemp.Replace('.',','));
        return temp;
      }
      catch (Exception e)
      {
        MessageBox.Show("błąd przy pobieraniu pogody" + " "+ e.Message);
        return 0;
      }
    }
  }
}