using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.__My_Assets.Scripts
{
    public static class CountdownControl
    {
        public static int TimeLeft { get; set; }
        public static bool TimeEnded { get; private set; }

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


        static CountdownControl()
        {

            //timeSpan = TimeSpan.FromMinutes(initTime);

            //TimerTicks = (float)timeSpan.TotalSeconds;// assign input to countdown clock

        }
        public static void SetCountdownClock(int startTimeInMinutes)
        {
            TimerTicks = (int)TimeSpan.FromMinutes(startTimeInMinutes).TotalSeconds;

        }
        public static void IncreaseCountdown(int secondsToAdd)
        {
            TimerTicks += secondsToAdd;
        }

        public static string GetRemainingTime()
        {
            DecreaseCountdown();
            CountdownText = TimeSpan.FromSeconds(TimerTicks).ToString(@"mm\:ss");
            return CountText();
        }
        private static void DecreaseCountdown()
        {
            TimerTicks -= Time.deltaTime;
            TimeEnded = TimerTicks < 1 ? true : false;

        }
        private static string CountText()
        {
            return TimeSpan.FromSeconds(TimerTicks).ToString(@"mm\:ss"); // prints 
        }

    }
}
