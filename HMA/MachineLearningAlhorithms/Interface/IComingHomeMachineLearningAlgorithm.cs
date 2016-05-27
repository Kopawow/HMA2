using System.Collections.Generic;
using HMA.Models;

namespace HMA.MachineLearningAlhorithms.Interface
{
  public interface IComingHomeMachineLearningAlgorithm
  {
    ComingHomeModel CalculateComingHomeTime(List<ComingHomeModel> list);
  }
}