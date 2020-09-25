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

    /// <summary>
    /// Manange the submission from main menu options  
    /// </summary>
    void OnMouseUp()
    {
        string submit = this.GetComponent<BoxCollider>().name;

        switch (submit)
        {
            case "MenuEasy":
                PlayerPrefs.SetFloat("initialGamingTime", (60 * 3));
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
                SceneManager.LoadScene("Stage1");

                break;
            case "MenuMedium":
                PlayerPrefs.SetFloat("initialGamingTime", (60 * 2));
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
                SceneManager.LoadScene("Stage1");

                break;
            case "MenuHard":
                PlayerPrefs.SetFloat("initialGamingTime", (60 * 1));
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);

                SceneManager.LoadScene("Stage1");
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
            default:
                break;
        }
    }
}
