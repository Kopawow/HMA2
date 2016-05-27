using System.Collections.Generic;
using System.Data;
using HMA.Models;

namespace HMA.Repositories.Interfaces
{
  public interface IDataRepository
  {
    void SaveData(List<ComingHomeModel> table);
    List<ComingHomeModel> GetData();
  }
}