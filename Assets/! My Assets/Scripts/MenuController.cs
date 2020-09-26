using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Ref: https://www.instructables.com/id/How-to-make-a-main-menu-in-Unity/

    //public static int _setInitialMinutesToGame;
    //public Transform transformMainMenu;

    public static MenuController mainMenu;
    private TextMesh textMesh;
    static GameObject[] levels;
    GameObject[] gameModes;
    GameObject textGameInfo;
    // Start is called before the first frame update
    void Start()
    {
        levels = GameObject.FindGameObjectsWithTag("level");
        gameModes = GameObject.FindGameObjectsWithTag("gameMode");
        textGameInfo = GameObject.Find("GameInfo");
    }


    // Update is called once per frame
    void Update()
    {

    }
    public static float InitialGamingTimeInSeconds { get; set; }
    public static string StageName { get; set; }

    void SetGameScene()
    {
        if (InitialGamingTimeInSeconds == 0)
        {
            textGameInfo.GetComponent<TextMesh>().text = "Choose a level";
        }
        else if (StageName == null)
        {
            textGameInfo.GetComponent<TextMesh>().text = "Choose a game mode";
        }
        else
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
            PlayerPrefs.SetFloat("initialGamingTime", InitialGamingTimeInSeconds);
            SceneManager.LoadScene(StageName);
        }


    }
    /// <summary>
    /// Manange the submission from main menu options  
    /// </summary>
    void OnMouseUp()
    {
        string submit = this.GetComponent<BoxCollider>().name;
        textMesh = GetComponent<TextMesh>();

        switch (submit)
        {
            case "MenuEasy":
                InitialGamingTimeInSeconds = 180;
                SetFeedbackLevel();

                SetGameScene();
                break;
            case "MenuMedium":
                InitialGamingTimeInSeconds = 120;
                SetFeedbackLevel();

                SetGameScene();
                break;
            case "MenuHard":
                InitialGamingTimeInSeconds = 60;
                SetFeedbackLevel();
                SetGameScene();
                break;
            case "Quit":
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
                Application.Quit();
                break;
            case "Scoreboard":
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
                SceneManager.LoadScene("ScoreboardScene");
                break;
            case "MainMenu":
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
                SceneManager.LoadScene("MainMenuScene");
                break;
            case "Cancel":
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
                SceneManager.LoadScene("MainMenuScene");
                break;
            case "LightMode":
                StageName = "Stage1";
                SetFeedbackStageMode();
                SetGameScene();
                break;
            case "DarkMode":
                StageName = "Stage2";
                SetFeedbackStageMode();
                SetGameScene();
                break;
            default:
                break;
        }
    }

    void SetFeedbackLevel()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            if (levels[i].Equals(transform.gameObject))
            {
                this.textMesh.fontSize = 70;
                transform.GetComponent<BoxCollider>().enabled = false;
            }
            else
            {
                levels[i].GetComponent<TextMesh>().fontSize = 50;
                levels[i].GetComponent<BoxCollider>().enabled = true;
            }
        }
    }

    void SetFeedbackStageMode(/*GameObject other*//*,Transform thisGameObj*/)
    {
        for (int i = 0; i < gameModes.Length; i++)
        {
            if (gameModes[i].Equals(transform.gameObject))
            {
                this.textMesh.fontSize = 90;
                transform.GetComponent<BoxCollider>().enabled = false;
            }
            else
            {
                gameModes[i].GetComponent<TextMesh>().fontSize = 40;
                gameModes[i].GetComponent<BoxCollider>().enabled = true;
            }
        }
    }

}
