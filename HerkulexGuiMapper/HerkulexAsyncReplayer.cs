/*
This file was created by Adrian Ferstera
Email: adrian@ferstera.com
Standard MIT License
*/using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using HerkulexApi; 

namespace HerkulexGuiMapper
{
    /// <summary>
    /// A class to control asynchronously a number of servos.  
    /// </summary>
    public class HerkulexAsyncReplayer
    {

        private double minLimDegrees;
        private double maxLimDegrees;



        /// <summary>
        /// Initializes an instance of the HerkuleX Async Replayer class to asynchronously control several servos at the same time.
        /// </summary>
        /// <param name="minLimit">minimum limit in degrees according to the application</param>
        /// <param name="maxLimit">maximum limit in degrees according to the application</param>
        public HerkulexAsyncReplayer(double minLimit, double maxLimit)
        {
            minLimDegrees = minLimit;
            maxLimDegrees = maxLimit;
        }
       /// <summary>
       /// Performs a peristaltic motion according to the input parameters. 
       /// </summary>
       /// <param name="type">The type of the waveform the Async Replayer should perform</param>
       /// <param name="fc">Frequency of the performed wave</param>
       /// <param name="maxAmplitude">Maximum possible amplitude of the actuator</param>
       /// <param name="amplitude">Current amplitude of the systems. Can be between 0 and maxAmplitude</param>
       /// <param name="playCycles">How many times this section should be repeated</param>
       /// <param name="servos">A list with all connected servos</param>
       /// <param name="spatialOnlyPattern">If the wave should be peristaltic or spatial</param>
       /// <param name="startServo">Startpoint of the wave. Can be between the first and last servo.</param>
       public void StartSeries(WaveformType type, double fc, double maxAmplitude, double amplitude, double playCycles, List<IHerkulexServo> servos, bool spatialOnlyPattern = false, int startServo = 1)
        {
           var T = Convert.ToInt32(1 / fc * 1000); //T in ms
            var pauseTimeBetweenServos = 0;
            if (spatialOnlyPattern) pauseTimeBetweenServos = T / servos.Count;
            // Generate the corresponding wave for the servos
            var playValues = WaveformGenerator.GeneratePlayValues(type, fc, playCycles, amplitude, maxAmplitude).ToList();

            //map the wave to degree values of the servos
            var playValuesForServos = playValues.Select(el =>
                new HerkulexDatapoint(el.XValue * 1000, Map2ServoValue(maxLimDegrees, minLimDegrees, 1, 0, el.YValue))
                    { AccelerationRatio = el.AccelerationRatio }).ToList();
            
            // order the replay order according to the input parameter startServo
            var replayServoOrder = OrderServoInReplayList(servos, startServo);
            var threadList = new List<List<Thread>>();
            var awaitThreadList = new List<Thread>();
            foreach (var servoList in replayServoOrder)
            {
                var temporaryThreadList = new List<Thread>();
                foreach (var servo in servoList)
                {
                    var thread = new Thread(() => servo.PlaySeries(playValuesForServos));
                    temporaryThreadList.Add(thread);
                    awaitThreadList.Add(thread);
                }
                threadList.Add(temporaryThreadList);
            }

            foreach (var servoPairThread in threadList)
            {
                foreach (var servoThread in servoPairThread)
                {
                    servoThread.Start();
                }
                Thread.Sleep(pauseTimeBetweenServos);
            }

            foreach (var thread in awaitThreadList)
            {
                //Wait until the threads are finished by joining another to it, its similar to Task.Waitall....
                thread.Join(); 
            }
        }

        /// <summary>
        /// Moves asynchronously all servos to a specific position
        /// </summary>
        /// <param name="target">Target position in degrees</param>
        /// <param name="servos">List with all servos which should be moved</param>
        public void Move2Position(double target, List<IHerkulexServo> servos)
        {
            var valueInDeg = Map2ServoValue(maxLimDegrees, minLimDegrees, 1, 0, target); 
            var threadList = new List<Thread>();
            foreach (var servo in servos)
            {
                var task = new Thread(() => servo.MoveServoPosition(valueInDeg, 1000));
                threadList.Add(task);
            }
            foreach (var thread in threadList) thread.Start();
            foreach (var thread in threadList) thread.Join(); 
        }

        private static double Map2ServoValue(double yMax, double yMin, double xMax, double xMin, double x)
        {
            var mappedValue = (yMax - yMin) / (xMax - xMin) * x + yMin;
            return mappedValue;
        }

        private List<List<IHerkulexServo>> OrderServoInReplayList(List<IHerkulexServo> myServos, int startValue)
        {
            var replayList = new List<List<IHerkulexServo>>();
            replayList.Add(myServos.Where(el => el.Id == startValue).ToList());
            return addServoRecursive(myServos, replayList, startValue + 1, startValue - 1);
        }
        private List<List<IHerkulexServo>> addServoRecursive(List<IHerkulexServo> myServos, List<List<IHerkulexServo>> replayServoList, int servoId1, int servoId2)
        {
            var temporaryServoList = myServos.Where(el => el.Id == servoId1 || el.Id == servoId2).ToList();
            replayServoList.Add(temporaryServoList);
            if (servoId1 +1 <= 8 || servoId2-1 >= 1)
            {
                addServoRecursive(myServos, replayServoList, servoId1 + 1, servoId2 - 1);
            }
            return replayServoList;
        }
    }
}
