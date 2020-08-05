using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.__My_Assets.Scripts
{
    public static class CountdownControl
    {
        public static string TimePlayed
        {
            get;
            set;
        }
        public static bool TimeEnded
        {
            get => _timeEnded;
            private set
            {

                if (!_timeEnded)
                {
                    _timeEnded = value;
                    TimePlayed = TimeSpan.FromSeconds(_timePlayed).ToString(@"mm\:ss");

                }
            }
        }
        private static bool _timeEnded;
        public static Text countText;
        private static TimeSpan timeSpan;
        private static float _timerTicks;
        private static string _countdownText;

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
        private static float _timePlayed;

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
        public static void SetCountdownClock(int startTimeInMinutes)
        {
            TimerTicks = (int)TimeSpan.FromMinutes(startTimeInMinutes).TotalSeconds;
        }
        public static void IncreaseCountdown(int secondsToAdd)
        {
            TimerTicks += secondsToAdd;
        }

        public static void GetRemainingTime()
        {
            DecreaseCountdown();
            CountdownText = TimeSpan.FromSeconds(TimerTicks).ToString(@"mm\:ss");
        }
        private static void DecreaseCountdown()
        {
            //TODO _timePlayed returns 1 sec under complete time
            _timePlayed += Time.deltaTime;
            TimerTicks -= Time.deltaTime;
            TimeEnded = TimerTicks < 1 ? true : false;

        }
        private static string CountText()
        {
            return TimeSpan.FromSeconds(TimerTicks).ToString(@"mm\:ss"); // prints 
        }

    }
}
