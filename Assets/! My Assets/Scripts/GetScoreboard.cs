using Assets.__My_Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GetScoreboard : MonoBehaviour
{

    public Text scoreboardText;
    public Image image;
    public Button button;
    Text buttonText;
    private void Awake()
    {
        SaveLoad.Load();
    }
    // Start is called before the first frame update
    void Start()
    {
        /*
        var players1 = new List<Player>() { new Player { playerName = "Eva" } };
        players1.Add(new Player { playerName = "Annica" });
        players1[1].gameResults.Add(new GameResult { totalTime = 240 });// 4minuter
        players1[1].gameResults.Add(new GameResult { totalTime = 90 }); // 1.5 minut
        players1[1].gameResults.Add(new GameResult { totalTime = 180 }); // 3 minuter
        players1[0].gameResults.Add(new GameResult { totalTime = 60 });// 1 minuter
        var bajs = players1.Select(x => x.gameResults.Select(g => g.totalTime));
        */

        button.gameObject.GetComponentInChildren<Text>().text = "High score";
        button.GetComponent<Button>().onClick.AddListener(TaskOnClick);
        //Button btn = getScoreBoardButton.GetComponent<Button>();
        //btn.onClick.AddListener(TaskOnClick);

    }

    void TaskOnClick()
    {
        if (image.GetComponent<Image>().enabled == false && scoreboardText.GetComponent<Text>().enabled == false)
        {
            image.GetComponent<Image>().enabled = true;
            scoreboardText.GetComponent<Text>().enabled = true;

            List<Player> players = SaveLoad.savedGames;

            System.Text.StringBuilder strBulider = new System.Text.StringBuilder();
            for (int i = 0; i < players.Count; i++)
            {
                foreach (var game in players[i].gameResults.OrderByDescending(x => x.totalTime))
                {
                    var test = game;
                    strBulider.AppendFormat("1. {0}\t{1}\n", players[i].playerName, TimeSpan.FromSeconds(game.totalTime).ToString((@"mm\:ss")));
                }
            }
            scoreboardText.text = strBulider.ToString();
            button.gameObject.GetComponentInChildren<Text>().text = "Back";

        }
        else
        {
            image.GetComponent<Image>().enabled = false;
            scoreboardText.GetComponent<Text>().enabled = false;
            button.gameObject.GetComponentInChildren<Text>().text = "High Score";

        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
