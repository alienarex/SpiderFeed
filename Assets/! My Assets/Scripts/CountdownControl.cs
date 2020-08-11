using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.__My_Assets.Scripts
{
    public static class CountdownControl
    {
        private static bool _timeEnded;
        public static Text countText;
        private static TimeSpan timeSpan;
        private static float _timerTicks;
        private static string _countdownText;
        private static string _convertTotalTimePlayedToString;
        private static TimeSpan _totalPlaydTime;


        public static bool TimeEnded { get; private set; }
        public static string GetTotalTimePlayed
        {
            get => _convertTotalTimePlayedToString;
            set
            {
                if (_convertTotalTimePlayedToString != value)
                {
                    _convertTotalTimePlayedToString = value;
                }
            }
        }
        public static string CountdownText
        {
            get => _countdownText;
            private set
            {
                if (_countdownText != value)
                {
                    _countdownText = value;
                }
            }

        }

        public static float TimerTicks
        {
            get => _timerTicks;
            set
            {
                if (_timerTicks != value)
                {
                    _timerTicks = value;
                }
            }

        }

        /// <summary>
        /// Initial set countdown clock.
        /// Adds initial value to players total played time.
        /// </summary>
        /// <param name="startTimeInMinutes"></param>
        public static void SetCountdownClock(int startTimeInMinutes)
        {
            TimerTicks = (int)TimeSpan.FromMinutes(startTimeInMinutes).TotalSeconds;
            _totalPlaydTime = TimeSpan.FromMinutes(startTimeInMinutes);
        }

        /// <summary>
        /// Adds value to countdown clock and players total played time.
        /// </summary>
        /// <param name="secondsToAdd"></param>
        public static void IncreaseCountdown(int secondsToAdd)
        {
            TimerTicks += secondsToAdd;
            _totalPlaydTime += TimeSpan.FromSeconds(secondsToAdd);
        }

        /// <summary>
        /// Calls DecreasesCountdown() and set the new value to CountdownText.
        /// </summary>
        public static void GetRemainingTime()
        {
            DecreaseCountdown();
            CountdownText = TimeSpan.FromSeconds(TimerTicks).ToString(@"mm\:ss");
        }

        /// <summary>
        /// Decreases TimerTicks (for the countdown clock).
        /// Checks if less then 1 and set TimeEnded to true.
        /// </summary>
        private static void DecreaseCountdown()
        {
            TimerTicks -= Time.deltaTime;
            if (TimerTicks < 0.5)
            {
                TimeEnded = true;
                GetTotalTimePlayed = _totalPlaydTime.ToString(@"mm\:ss");

            }
            TimeEnded = TimerTicks < 1 ? true : false;

        }
        private static string CountText()
        {
            return TimeSpan.FromSeconds(TimerTicks).ToString(@"mm\:ss"); // prints 
        }

    }
}
