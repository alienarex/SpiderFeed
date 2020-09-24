using UnityEngine;

namespace Assets.__My_Assets.Scripts
{
    public sealed class Timer
    {
        // REf: https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/
        private Timer()
        {
        }
        private static Timer instance = null;
        public static Timer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Timer();
                }
                return instance;
            }
        }

        public float TimeRemaining { get; private set; }
        public float TotalTime { get; private set; }

        bool timerIsRunning;

        /// <summary>
        /// Updates timer values
        /// </summary>
        public void UpdateTimer()
        {
            if (timerIsRunning)
            {
                if (TimeRemaining > 0)
                {
                    TimeRemaining -= Time.deltaTime;
                    TotalTime += Time.deltaTime;
                }
                else
                {
                    TimeRemaining = 0;
                    timerIsRunning = false;
                }
            }
        }

        /// <summary>
        /// Increase seconds to timer
        /// </summary>
        /// <param name="seconds"></param>
        public void AddSecondsToTimer(float seconds)
        {
            TimeRemaining += seconds;
            timerIsRunning = true;
        }
    }
}
