using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Assets.__My_Assets.Scripts.CountdownControl;

public class SavePlayerScoreController : MonoBehaviour
{
    public InputField inputField;
    public TextMesh totalTimeText;

    // Start is called before the first frame update
    void Start()
    {
        totalTimeText = GameObject.Find("TotalplayedTime").GetComponent<TextMesh>();

        totalTimeText.text = $"Total time: {GetTotalTimePlayed}";
    }

    IEnumerator LoadScene()
    {
        totalTimeText.fontSize = 40;
        totalTimeText.text = $"Saved successfully!";
        yield return new WaitForSeconds(3);
        SceneManager.LoadSceneAsync("GameOverScene"); // Can Async put gameover scene on top of current scenee?
    }


    private void OnMouseUp()
    {
        string submit = this.GetComponent<BoxCollider>().name;
        string playerName = GameObject.Find("InputField").GetComponent<InputField>().text;

        switch (submit)
        {
            case "SaveResult":
                PlayerPrefs.SetString("playerName", playerName);
                PlayerPrefs.SetString("totalTime", GetTotalTimePlayed);
                string mju = PlayerPrefs.GetString("playerName");
                StartCoroutine("LoadScene");
                // Save result with PlayerScore class
                break;
            case "DoNotSave":
                SceneManager.LoadScene("GameOverScene");
                break;
            default:
                throw new System.Exception("Someting went wrong when saving, try again");
        }

    }

    // Update is called once per frame
    void Update()
    {
    }
}