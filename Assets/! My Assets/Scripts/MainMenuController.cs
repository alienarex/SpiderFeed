using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Ref: https://www.instructables.com/id/How-to-make-a-main-menu-in-Unity/

    private bool[] difflctiesLevels;
    public bool easy;
    public bool medium;
    public bool hard;
    public bool isQuit;
    public static int _setInitialMinutesToGame;
    public Transform transformMainMenu;

    public static MainMenuController mainMenu;
    public static int SetInitialMinutesToGame
    {
        get => _setInitialMinutesToGame;
        private set
        {
            if (_setInitialMinutesToGame != value)
            {
                _setInitialMinutesToGame = value;
            }
        }

    }

    private void Awake()
    {
        difflctiesLevels = new bool[3] { hard, medium, easy };
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnMouseUp()
    {
        int defaultMinutesToAdd = 1;
        for (int i = 0; i < difflctiesLevels.Length; i++)
        {
            if (difflctiesLevels[i])
            {
                _setInitialMinutesToGame = defaultMinutesToAdd + i;
                SceneManager.LoadScene("Stage1");
            }
        }
        if (isQuit)
        {
            Application.Quit();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
