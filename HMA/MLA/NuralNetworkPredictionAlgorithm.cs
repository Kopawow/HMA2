using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Encog.Engine.Network.Activation;
using Encog.ML.Data;
using Encog.ML.Data.Basic;
using Encog.ML.Data.Temporal;
using Encog.Neural.Networks;
using Encog.Neural.Networks.Layers;
using Encog.Neural.Networks.Training;
using Encog.Neural.Networks.Training.Propagation.Back;
using Encog.Neural.Networks.Training.Propagation.Resilient;
using Encog.Util;
using Encog.Util.Arrayutil;

namespace HMA.MLA
{
    public class NuralNetworkPredictionAlgorithm
    { 
        public int WindowSize;
        public int TrainStart;
        public int TrainEnd;
        public int EvaluateStart;
        public BasicNetwork network;

        public const double MaxError = 0.01;

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
            NormalizeSunspots(0.1, 1);
            network = CreateNetwork();
            IMLDataSet training = GenerateTraining();
            Train(network, training);
        }

        public void PredictValue()
        {
            Predict(network);
        }

        #endregion

        public void NormalizeSunspots(double lo, double hi)
        {
            var norm = new NormalizeArray { NormalizedHigh = hi, NormalizedLow = lo };

            _normalizedArray = norm.Process(_comeHomeHoursValues);
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

        public BasicNetwork CreateNetwork()
        {
            var network = new BasicNetwork();
            network.AddLayer(new BasicLayer(WindowSize));
            network.AddLayer(new BasicLayer(1));
            network.AddLayer(new BasicLayer(1));
            network.Structure.FinalizeStructure();
            network.Reset();
            return network;
        }

        public void Train(BasicNetwork network, IMLDataSet training)
        {
            ITrain train = new ResilientPropagation(network, training);

            do
            {
                train.Iteration();
            } while (train.Error > MaxError);
        }

        public void Predict(BasicNetwork network)
        {
            double closedLoopPrediction= 0.0;
            double prediction = 0.0;
            for (int day = TrainStart; day < EvaluateEnd; day++)
            {
                var input = new BasicMLData(WindowSize);
                for (var i = 0; i < input.Count; i++)
                {
                    input[i] = _normalizedArray[(day - WindowSize) + i];
                }
                IMLData output = network.Compute(input);
                prediction = output[0];
                _closedLoop[day] = prediction;

                for (var i = 0; i < input.Count; i++)
                {
                    input[i] = _closedLoop[(day - WindowSize) + i];
                }
                output = network.Compute(input);
                 closedLoopPrediction = output[0];
            }
            _predictedValue = closedLoopPrediction;
        }

        public double GetPredictedValue()
        {
            return _predictedValue;
        }
    }
}
