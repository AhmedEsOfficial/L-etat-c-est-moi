using UnityEngine;
using UnityEngine.Serialization;

namespace Models.Algorithm_Code
{
    public class NoiseSettings
    {
        public float ElevationScale
            ,TemperatureScale
            ,RainScale;
        public float ElevationCoefficient,
            TemperatureCoefficient,
            RainCoefficient;

        public float GetElevationScale()
        {
            return ElevationScale;
        }
        
        public float GetRainScale()
        {
            return RainScale;
        }
        public float GetTemperatureScale()
        {
            return TemperatureScale;
        }
        
        public float GetTemperatureCoefficient()
        {
            return TemperatureCoefficient;
        }
        public float GetElevationCoefficient()
        {
            return ElevationCoefficient;
        }
        
        public float GetRainCoefficient()
        {
            return RainCoefficient;
        }

        public void SetElevationScale(float ES)
        {
            ElevationScale = ES;
        }
        
        public void SetTemperatureScale(float TS)
        {
            TemperatureScale = TS;
        }
        
        public void SetRainScale(float RS)
        {
            TemperatureScale = RS;
        }
        
        public void SetElevationCoefficient(float EC)
        {
            ElevationCoefficient = EC;
        }
        
        public void SetTemperatureCoefficient(float TC)
        {
            TemperatureCoefficient = TC;
        }
        
        public void SetRainCoefficient(float RC)
        {
            TemperatureCoefficient = RC;
        }

        
    }
}