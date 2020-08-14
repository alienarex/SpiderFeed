using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Ref: https://www.instructables.com/id/How-to-make-a-main-menu-in-Unity/

    //public static int _setInitialMinutesToGame;
    //public Transform transformMainMenu;

    public static MainMenuController mainMenu;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnMouseUp()
    {
        string submit = this.GetComponent<BoxCollider>().name;

        switch (submit)
        {
            case "MenuEasy":

                PlayerPrefs.SetInt("initialGamingTime", 3);
                SceneManager.LoadScene("StageScene");

                break;
            case "MenuMedium":
                PlayerPrefs.SetInt("initialGamingTime", 2);
                SceneManager.LoadScene("StageScene");

                break;
            case "MenuHard":
                PlayerPrefs.SetInt("initialGamingTime", 1);
                SceneManager.LoadScene("StageScene");
                break;
            case "Quit":
                Application.Quit();
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
