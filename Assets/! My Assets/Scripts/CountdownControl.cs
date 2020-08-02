using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.__My_Assets.Scripts
{
    public class CountdownControl
    {
        public int TimeLeft { get; set; }
        public bool TimeEnded { get; private set; }

        public Text countText;
        private TimeSpan timeSpan;
        private float _timerTicks;

        public CountdownControl(int initTime)
        {

            timeSpan = TimeSpan.FromMinutes(initTime);

            _timerTicks = (float)timeSpan.TotalSeconds;// assign input to countdown clock

        }

        public string GetRemainingTime()
        {
            DecreaseCountdown();
            return CountText();
        }
        private void DecreaseCountdown()
        {
            _timerTicks -= Time.deltaTime;
            TimeEnded = _timerTicks < 1 ? true : false;

        }
        private string CountText()
        {
            return TimeSpan.FromSeconds(_timerTicks).ToString(@"mm\:ss"); // prints 
        }

    }
}
