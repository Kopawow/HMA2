using System.Linq;
using Encog.ML.Data;
using Encog.ML.Data.Basic;
using Encog.ML.Data.Temporal;
using Encog.Neural.Networks;
using Encog.Neural.Networks.Layers;
using Encog.Neural.Networks.Training.Lma;
using Encog.Util;
using MathNet.Numerics.Statistics;

namespace HMA.MLA
{
    public class NuralNetworkPredictionAlgorithm
    { 
        public int WindowSize;
        public int TrainStart;
        public int TrainEnd;
        public int EvaluateStart;
        public BasicNetwork network;

        public const double MaxError = 0.0001;

        private double _predictedValue= 0.0;

        private double[] _comeHomeHoursValues;

        public int EvaluateEnd; 

        private double[] _closedLoop;
        private double[] _normalizedArray;

   
        #region Methods

        public NuralNetworkPredictionAlgorithm(double[] values)
        {
            _comeHomeHoursValues = values;
            
            EvaluateEnd = _comeHomeHoursValues.Length - 1;
            WindowSize = 10;
            TrainStart = WindowSize;
            TrainEnd = _comeHomeHoursValues.Length - 11;
            EvaluateStart = _comeHomeHoursValues.Length - 10;
        } 

        public void Execute()
        {
            NormalizeSunspots(0.01, 1);
            CreateNetwork();
            IMLDataSet training = GenerateTraining();
            Train(training);
        }

        public void PredictValue()
        {
            Predict();
        }

        #endregion

        public void NormalizeSunspots(double lo, double hi)
        {
            _normalizedArray = _comeHomeHoursValues;
            _closedLoop = EngineArray.ArrayCopy(_normalizedArray);
        }


        public IMLDataSet GenerateTraining()
        {
            var result = new TemporalMLDataSet(WindowSize, 1);

            var desc = new TemporalDataDescription(
                TemporalDataDescription.Type.Raw, true, true);
            result.AddDescription(desc);

            for (int day = TrainStart; day < TrainEnd; day++)
            {
                var point = new TemporalPoint(1)
                {
                    Sequence = day,
                    Data = {[0] = _normalizedArray[day] }
                }; 
                result.Points.Add(point);
            }

            result.Generate();
            
            return result;
        }

        public void CreateNetwork()
        {
            network = new BasicNetwork();
            network.AddLayer(new BasicLayer(WindowSize));
            network.AddLayer(new BasicLayer(10));
            network.AddLayer(new BasicLayer(1));
            network.Structure.FinalizeStructure();
            network.Reset();
         
        }

        public void Train(IMLDataSet training)
        {
            var train = new LevenbergMarquardtTraining(network,training);

            do
            {
                train.Iteration();
            } while (train.Error > MaxError);
        }

        public void Predict()
        {
            double[] closedLoopPrediction= new double[10];
            double[] prediction = new double[10];
            for (int day = EvaluateStart; day < EvaluateEnd; day++)
            {
                var input = new BasicMLData(WindowSize);
                for (var i = 0; i < input.Count; i++)
                {
                    input[i] = _normalizedArray[(day - WindowSize) + i];
                }
                IMLData output = network.Compute(input);
                prediction[EvaluateEnd-day] = output[0];
                _closedLoop[day] = prediction[EvaluateEnd - day];

                for (var i = 0; i < input.Count; i++)
                {
                    input[i] = _closedLoop[(day - WindowSize) + i];
                }
                output = network.Compute(input);
                 closedLoopPrediction[EvaluateEnd - day] = output[0];
            }
            _predictedValue = prediction.Where(x=> x != 0).Median();
        }

        public double GetPredictedValue()
        {
            return _predictedValue;
        }
        
    }
}
