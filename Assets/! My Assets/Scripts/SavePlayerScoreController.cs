using Assets.__My_Assets.Scripts;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SavePlayerScoreController : MonoBehaviour
{
    public InputField inputField;
    public TextMesh totalTimeText;

    // Start is called before the first frame update
    void Start()
    {
        totalTimeText.text = $" Time: {Timer.Instance.TotalTime.ConvertTimeToString()}";
    }

    /// <summary>
    /// Corountine to wait and then launch game over scene
    /// </summary>
    /// <returns></returns>
    IEnumerator LoadScene()
    {
        totalTimeText.fontSize = 40;
        totalTimeText.text = $"Saved successfully!";
        yield return new WaitForSeconds(2);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        SceneManager.LoadSceneAsync("GameOverScene"); // Can Async put gameover scene on top of current scenee?
    }

    /// <summary>
    /// Saves players info if saved is pushed else game over is launched without saving
    /// </summary>
    private void OnMouseUp()
    {
        string submit = this.GetComponent<BoxCollider>().name;
        string inputName = GameObject.Find("InputField").GetComponent<InputField>().text;

        switch (submit)
        {
            case "Save":
                Player player = new Player
                {
                    playerName = inputName,
                };
                // TODO get total played time 
                player.gameResults.Add(new GameResult { totalTime = Timer.Instance.TotalTime });
                Player.current = player;
                SaveLoad.Save();
                StartCoroutine("LoadScene");
                //SaveLoad.Load();
                // Save result with PlayerScore class
                break;
            case "Cancel":
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
                SceneManager.LoadScene("GameOverScene");
                break;
            default:
                throw new System.Exception("Someting went terrible wrong when saving, try again");
        }

    }

    // Update is called once per frame
    void Update()
    {
    }
}