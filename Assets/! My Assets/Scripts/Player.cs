using System;
using System.Collections.Generic;

namespace Assets.__My_Assets.Scripts
{
    [Serializable]
    public class Player
    {
        public static Player current;
        public string playerName;
        public string totalPlayedTime;
        public int numberOfHumansEaten;
        public List<GameResult> gameResults;

        public Player()
        {
            gameResults = new List<GameResult>();
        }

    }
}
