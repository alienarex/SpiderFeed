using Assets.__My_Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GetScoreboard : MonoBehaviour
{
    public Text scoreboardText;

    private void Awake()
    {
        SaveLoad.Load();
    }

    // Start is called before the first frame update
    void Start()
    {
        GetPlayersHighScoreOrderByDescending();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Gets players saved highscore stored in Application.persistentDataPath.
    /// </summary>
    void GetPlayersHighScoreOrderByDescending()
    {
        scoreboardText.GetComponent<Text>().enabled = true;

        List<Player> players = SaveLoad.savedGames;

        System.Text.StringBuilder strBulider = new System.Text.StringBuilder();
        for (int i = 0; i < players.Count; i++)
        {
            foreach (var savedResult in players[i].gameResults.OrderByDescending(x => x.totalTime))
            {
                var test = savedResult;
                strBulider.AppendFormat("{0}. {1}\t{2}\n", i + 1, players[i].playerName, TimeSpan.FromSeconds(savedResult.totalTime).ToString((@"mm\:ss")));
            }
        }
        scoreboardText.text = strBulider.ToString();
    }
}
