/*
This file was created by Adrian Ferstera
Email: adrian@ferstera.com
Standard MIT License
*/
using System;
using System.Collections.Generic;
using System.Linq;
using HerkulexApi;

namespace HerkulexGuiMapper
{
    /// <summary>
    /// A class to generate different kind of waveforms. 
    /// </summary>
    public class WaveformGenerator
    {
        /// <summary>
        /// Generates an array of waves according to the input which can be displayed in a graphical user interface. 
        /// </summary>
        /// <param name="type">wave type which should be generated </param>
        /// <param name="fc">Frequency of the wave</param>
        /// <param name="playCycles">How many times if should be repeated</param>
        /// <param name="amplitude">Current amplitude of the wave. Can be between 0 and maxAmplitude</param>
        /// <param name="maxAmplitude">Maximal possible amplitude</param>
        /// <returns></returns>
        public static IEnumerable<HerkulexDatapoint> Generate(WaveformType type, double fc, double playCycles,
            double amplitude, double maxAmplitude)
        {
            var appointList = new List<HerkulexDatapoint>();
            if (type == WaveformType.NegativeSawtooth)
                appointList = CalculateNegativeSawtoothWave(playCycles, fc, amplitude);
            if (type == WaveformType.PositiveSawtooth)
                appointList = CalculatePositiveSawtoothWave(playCycles, fc, amplitude);
            if (type == WaveformType.Sine)
                appointList = CalculateSineWave(playCycles, fc, amplitude);
            if (type == WaveformType.Triangle)
                appointList = CalculateTriangleWave(playCycles, fc, amplitude);
            if (type == WaveformType.SineTriangle)
                appointList = CalculateSineTriangle(playCycles, fc, amplitude);
            if (type == WaveformType.TriangleSine)
                appointList = CalculateTriangleSine(playCycles, fc, amplitude);

            return appointList;
        }
        /// <summary>
        /// Generates an array of waves according to the input which can be used to apply these waves to a serries of servos. 
        /// </summary>
        /// <param name="type">wave type which should be generated </param>
        /// <param name="fc">Frequency of the wave</param>
        /// <param name="playCycles">How many times if should be repeated</param>
        /// <param name="amplitude">Current amplitude of the wave. Can be between 0 and maxAmplitude</param>
        /// <param name="maxAmplitude">Maximal possible amplitude</param>
        /// <returns></returns>
        public static IEnumerable<HerkulexDatapoint> GeneratePlayValues(WaveformType type, double fc, double playCycles,
            double amplitude, double maxAmplitude)
        {
            var appointList = new List<HerkulexDatapoint>();
            if (type == WaveformType.NegativeSawtooth)
                appointList = CalculateNegativeSawtoothWave(playCycles, fc, amplitude, true);
            if (type == WaveformType.PositiveSawtooth)
                appointList = CalculatePositiveSawtoothWave(playCycles, fc, amplitude, true);
            if (type == WaveformType.Sine)
                appointList = CalculateSineWave(playCycles, fc, amplitude, true);
            if (type == WaveformType.Triangle)
                appointList = CalculateTriangleWave(playCycles, fc, amplitude, true);
            if (type == WaveformType.SineTriangle)
                appointList = CalculateSineTriangle(playCycles, fc, amplitude, true);
            if (type == WaveformType.TriangleSine)
                appointList = CalculateTriangleSine(playCycles, fc, amplitude, true);

            return appointList;
        }
        private static List<HerkulexDatapoint> CalculateTriangleWave(double playCycles, double fc, double amplitude, bool forServo = false)
        {
            var triangleWave = new List<HerkulexDatapoint>();
            triangleWave.Add(new HerkulexDatapoint(0, 0));
            if (forServo)
            {
                for (int i = 0; i < playCycles * fc; i++)
                {
                    var gabs = 1.0 / fc;
                    triangleWave.Add(new HerkulexDatapoint((gabs / 2),
                        amplitude)
                    { AccelerationRatio = 0 });
                    triangleWave.Add(new HerkulexDatapoint((gabs / 2), 0) { AccelerationRatio = 0 });
                }
                return triangleWave;
            }
            for (int i = 0; i < playCycles * fc; i++)
            {
                var gabs = 1.0 / fc;
                var counterDouble = Convert.ToDouble(i);
                triangleWave.Add(new HerkulexDatapoint(counterDouble / fc + (gabs / 2),
                    amplitude));
                triangleWave.Add(new HerkulexDatapoint(counterDouble / fc + gabs, 0));
            }
            return triangleWave;
        }
        private static List<HerkulexDatapoint> CalculateNegativeSawtoothWave(double playCycles, double fc, double amplitude, bool forServo = false)
        {
            var sawTooths = new List<HerkulexDatapoint>();
            sawTooths.Add(new HerkulexDatapoint(0, 0));
            for (int i = 1; i <= playCycles * fc; i++)
            {
                var counterDouble = Convert.ToDouble(i);
                if (forServo)
                {
                    sawTooths.Add(new HerkulexDatapoint(0, amplitude) { AccelerationRatio = 0 });
                    sawTooths.Add(new HerkulexDatapoint(1 / fc, 0) { AccelerationRatio = 0 });
                }
                else
                {
                    sawTooths.Add(new HerkulexDatapoint((counterDouble - 1) / fc, amplitude));
                    sawTooths.Add(new HerkulexDatapoint(counterDouble / fc, 0));
                }

            }
            return sawTooths;
        }

        private static List<HerkulexDatapoint> CalculatePositiveSawtoothWave(double playCycles, double fc, double amplitude, bool forServo = false)
        {
            var sawTooths = new List<HerkulexDatapoint>();
            sawTooths.Add(new HerkulexDatapoint(0, 0));
            for (int i = 1; i <= playCycles * fc; i++)
            {
                var gabs = 1.0 / fc;
                var counterDouble = Convert.ToDouble(i);
                if (forServo)
                {
                    sawTooths.Add(new HerkulexDatapoint(1 / fc, amplitude) { AccelerationRatio = 0 });
                    sawTooths.Add(new HerkulexDatapoint(0, 0) { AccelerationRatio = 0 });
                }
                else
                {
                    sawTooths.Add(new HerkulexDatapoint(counterDouble / fc, amplitude));
                    sawTooths.Add(new HerkulexDatapoint(counterDouble / fc, 0));
                }
            }
            return sawTooths;
        }

        private static List<HerkulexDatapoint> CalculateSineWave(double playCycles, double fc, double amplitude, bool forServo = false)
        {
            if (forServo)
            {
                var sineReplayServo = CalculateTriangleWave(playCycles, fc, amplitude, true);
                return sineReplayServo.Select(el => new HerkulexDatapoint(el.XValue, el.YValue) { AccelerationRatio = 50 }).ToList();
            }
            var yAxisShift = amplitude / 2;
            var sinData = new List<HerkulexDatapoint>();
            for (int i = 0; i <= playCycles * 1000; i++)
            {
                var doubleCounter = Convert.ToDouble(i) / 1000;
                sinData.Add(new HerkulexDatapoint(doubleCounter,
                    ((yAxisShift) * Math.Sin(2 * Math.PI * fc * doubleCounter - Math.PI / 2) + (yAxisShift))));
            }
            return sinData;
        }

        private static List<HerkulexDatapoint> CalculateSineTriangle(double playCycles, double fc, double amplitude, bool forServo = false)
        {
            if (forServo)
            {
                var sineTriangleReplayServo = CalculateTriangleWave(playCycles, fc, amplitude, true);
                var indexAcceleration = false;
                for (int i = 0; i < sineTriangleReplayServo.Count; i++)
                {
                    if (indexAcceleration)
                    {
                        sineTriangleReplayServo[i].AccelerationRatio = 50;
                        indexAcceleration = false;
                    }
                    else indexAcceleration = true;
                }

                return sineTriangleReplayServo;
            }
            var yAxisShift = amplitude / 2;
            var sinData = new List<HerkulexDatapoint>();
            var resolution = 100;
            for (int i = 0; i < playCycles * fc; i++)
            {
                var doubleCounter = Convert.ToDouble(i);
                for (int j = 0; j < resolution; j++)
                {
                    sinData.Add(new HerkulexDatapoint((doubleCounter + 0.5 * Convert.ToDouble(j) / resolution) / fc,
                        ((yAxisShift) * Math.Sin(Math.PI * Convert.ToDouble(j) / resolution - Math.PI / 2) + (yAxisShift))));
                }
                sinData.Add(new HerkulexDatapoint((i + 1) / fc, 0));

            }
            return sinData;
        }
        private static List<HerkulexDatapoint> CalculateTriangleSine(double playCycles, double fc, double amplitude, bool forServo = false)
        {
            if (forServo)
            {
                var sineTriangleReplayServo = CalculateTriangleWave(playCycles, fc, amplitude, true);
                var indexAcceleration = true;
                for (int i = 0; i < sineTriangleReplayServo.Count; i++)
                {
                    if (indexAcceleration)
                    {
                        sineTriangleReplayServo[i].AccelerationRatio = 50;
                        indexAcceleration = false;
                    }
                    else indexAcceleration = true;
                }
                return sineTriangleReplayServo;
            }
            var yAxisShift = amplitude / 2;
            var sinData = new List<HerkulexDatapoint>();
            var resolution = 100;
            sinData.Add(new HerkulexDatapoint(0, 0));
            for (int i = 0; i < playCycles * fc; i++)
            {
                var doubleCounter = Convert.ToDouble(i);
                sinData.Add(new HerkulexDatapoint((doubleCounter + 0.5) / fc, amplitude));
                for (int j = 0; j < resolution; j++)
                {
                    sinData.Add(new HerkulexDatapoint((doubleCounter + 0.5 + 0.5 * Convert.ToDouble(j) / resolution) / fc,
                        ((yAxisShift) * Math.Sin(Math.PI * Convert.ToDouble(j) / resolution - 1.5 * Math.PI) + (yAxisShift))));
                }
            }
            return sinData;
        }

    }
}
