using System;

namespace HMA.HeatDemand
{
    public class HeatDemandForBuilding
    {
        private readonly int _surface;   // 100 [m]
        private readonly int _cubature;  // 300 [m3]
        private readonly int _internalTemperature;   // 21 [stC]
        private readonly double _minimumAirChanges;   // 0,5 [h^-1]        // nmin
        private readonly int _airChangesForBuilding; // 4-10 [h^-1]     // n50
        private readonly double _shieldingFactor; // 0,02                  // ei
        private readonly int _heightCorrectionFactor; // 1              // epsi



        public HeatDemandForBuilding(int surface = 100, int cubature = 300, int internalTemperature = 21, double minimumAirChanges = 0.5, int airChangesForBuilding = 6, double shieldingFactor = 0.02, int heightCorrectionFactor = 1)
        {
            _surface = surface;
            _cubature = cubature;
            _internalTemperature = internalTemperature;
            _minimumAirChanges = minimumAirChanges;
            _airChangesForBuilding = airChangesForBuilding;
            _shieldingFactor = shieldingFactor;
            _heightCorrectionFactor = heightCorrectionFactor;
        }

        public double CalculateHeatDemandForBuilding(double outsideTemperature)
        {
            return (PenetrationHeatLosses(outsideTemperature) + VentilationHeatLosses(outsideTemperature)) * 0.001;
        }

        // Qt,i [W]
        private double PenetrationHeatLosses(double outsideTemperature)
        {
            var outerWall = PenetrationHeatLossesFactor(33, 3, 0.23, 0, 1);
            var outsideWindow = PenetrationHeatLossesFactor(11, 2, 1.6, 0.4, 1);
            var exteriorDoor = PenetrationHeatLossesFactor(1, 2, 2.6, 0.5, 1);
            var flatRoof = PenetrationHeatLossesFactor(10, 10, 0.24, 0.2, 1);
            var groundFloor = PenetrationHeatLossesFactor(10, 10, 0.35, 0.2, 0.5);

            return (outerWall + outsideWindow + exteriorDoor + flatRoof + groundFloor)*(_internalTemperature - outsideTemperature);
        }

        // Qt,i [W]
        private double PenetrationHeatLossesFactor(double dimensionX, double dimensionY, double heatTransferCoefficient, double heatTransferCoefficientAdjusted, double temperatureReductionFactor, double thermalBridgeHeatTransferCoefficient = 1, double linearThermalBridgeLength = 0)
        {
            return dimensionX * dimensionY * (heatTransferCoefficient + heatTransferCoefficientAdjusted) * temperatureReductionFactor + thermalBridgeHeatTransferCoefficient * linearThermalBridgeLength;
        }

        //Qv,i [W]
        private double VentilationHeatLosses(double outsideTemperature)
        {
            return VentilationHeatLossesFactor() * (_internalTemperature - outsideTemperature);
        }

        // Hv,i [W/K]
        private double VentilationHeatLossesFactor()
        {
            return 0.34*VentilationAirStream();
        }

        //Vi [m3/h]
        private double VentilationAirStream()  
        {
            return Math.Max(InfiltrationAirStream(), MinimalHygieneAirStream());
        }

        //Vinf,i [m3/h]
        private double InfiltrationAirStream() //Vinf,i [m3/h]
        {
            return 2 * _cubature * _airChangesForBuilding * _shieldingFactor * _heightCorrectionFactor;
        }

        //Vmin,i [m3/h]
        private double MinimalHygieneAirStream()   
        {
            return _minimumAirChanges * _cubature;
        }

    }
}