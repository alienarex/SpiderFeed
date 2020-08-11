using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Assets.__My_Assets.Scripts
{
    public static class SaveLoad
    {
        public static List<Player> savedGames = new List<Player>();

        public static void Save()
        {
            savedGames.Add(Player.current);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/savedScore.gd");
            bf.Serialize(file, SaveLoad.savedGames);
            file.Close();
        }

        public static void Load()
        {
            if (File.Exists(Application.persistentDataPath + "/savedScore.gd"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/savedScore.gd", FileMode.Open);
                SaveLoad.savedGames = (List<Player>)bf.Deserialize(file);
                file.Close();
            }
        }

    }
}