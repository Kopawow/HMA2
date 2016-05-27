using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace HMA.Services.Interfaves
{
  public interface IWeatherService
  {
    Task<double> GetTodaysTemperature();
  }
}