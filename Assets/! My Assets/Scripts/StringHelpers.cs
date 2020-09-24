using UnityEngine;

namespace Assets.__My_Assets.Scripts
{
    public static class StringHelpers
    {

        /// <summary>
        /// Converts seconds to minutes and seconds
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string ConvertTimeToString(this float time)
        {
            float minutes = Mathf.FloorToInt(time / 60);
            float seconds = Mathf.FloorToInt(time % 60);
            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
