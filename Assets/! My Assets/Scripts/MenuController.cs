using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Ref: https://www.instructables.com/id/How-to-make-a-main-menu-in-Unity/

    //public static int _setInitialMinutesToGame;
    //public Transform transformMainMenu;

    public static MenuController mainMenu;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {

    }

    void LoadGameScene(float initialGamingTimeInSeconds)
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        PlayerPrefs.SetFloat("initialGamingTime", initialGamingTimeInSeconds);
        SceneManager.LoadScene("Stage1");

    }

    /// <summary>
    /// Manange the submission from main menu options  
    /// </summary>
    void OnMouseUp()
    {
        string submit = this.GetComponent<BoxCollider>().name;
        float initialGamingTimeInSeconds;

        switch (submit)
        {
            case "MenuEasy":
                initialGamingTimeInSeconds = 180;
                LoadGameScene(initialGamingTimeInSeconds);
                break;
            case "MenuMedium":
                initialGamingTimeInSeconds = 120;
                LoadGameScene(initialGamingTimeInSeconds);
                break;
            case "MenuHard":
                initialGamingTimeInSeconds = 60;
                LoadGameScene(initialGamingTimeInSeconds);
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
            default:
                break;
        }
    }
}
