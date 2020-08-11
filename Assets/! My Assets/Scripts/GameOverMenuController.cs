using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenuController : MonoBehaviour
{
    public InputField userName;


    // Start is called before the first frame update
    void Start()
    {
    }

    void OnMouseUp()
    {
        string choise = this.GetComponent<BoxCollider>().name;

        switch (choise)
        {
            case "RestartGame":
                SceneManager.LoadScene("StageScene");
                break;
            case "MainMenu":
                SceneManager.LoadScene("MainMenuScene");
                break;
            case "Quit":
                Application.Quit();
                break;
            default:
                throw new System.Exception("Something went wrong!");
        }

    }
    // Update is called once per frame
    void Update()
    {
        //playerScore.PlayerName = userName.text;
    }
}
