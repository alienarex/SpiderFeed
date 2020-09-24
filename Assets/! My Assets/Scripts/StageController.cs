using Assets.__My_Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;
using static Assets.__My_Assets.Scripts.StringHelpers;

public class StageController : MonoBehaviour
{
    private bool _isPaused;
    public GameObject pauseMenu;
    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        Timer.Instance.AddSecondsToTimer(PlayerPrefs.GetFloat("initialGamingTime"));
        InvokeRepeating("Generate", 0.0f, 3f); // Generates the humans direcley on launch (0.0f) and every second (..,1f)
        _isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        PauseOrResumeGame();
        Timer.Instance.UpdateTimer();
        timeText.text = Timer.Instance.TimeRemaining.ConvertTimeToString();
    }

    void PauseOrResumeGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.F10))
        {
            if (!_isPaused)
            {
                pauseMenu.SetActive(true);
                PauseGame();
            }
            else
            {
                pauseMenu.SetActive(false);
                ResumeGame();
            }
        }
    }

    /// <summary>
    /// Sets timeScale to zero, pausing the game
    /// </summary>d 
    void PauseGame()
    {
        Time.timeScale = 0;
        _isPaused = true;
    }

    /// <summary>
    /// Sets timeScale to 1, resuming the game
    /// </summary>
    void ResumeGame()
    {
        Time.timeScale = 1;
        _isPaused = false;
    }


    public void Generate()
    {
        GameObject human = ObjectPool.sharedInstance.GetPooledObjects();
        if (human != null)
        {
            float randomPosition = UnityEngine.Random.Range(-70, 70);
            human.SetActive(true);
            Vector3 position = new Vector3(transform.position.x + randomPosition, 0.0f, transform.position.z + randomPosition); // Calculates a new positionfor spawend human 1.6 to keep em on the ground not below
            human.transform.position = position;
        }
    }
}
