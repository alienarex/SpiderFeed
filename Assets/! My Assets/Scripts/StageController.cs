using Assets.__My_Assets.Scripts;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Assets.__My_Assets.Scripts.StringHelpers;

public class StageController : MonoBehaviour
{
    private bool _isPaused;
    public GameObject pauseMenu;
    public Text timeText;

    private void Awake()
    {
        Timer.Instance.ResetTimer();
        ActivateGame(); // sets the game to not paused and timescale to 1
    }

    // Start is called before the first frame update
    void Start()
    {
        Timer.Instance.AddSecondsToTimer(PlayerPrefs.GetFloat("initialGamingTime"));
        //Timer.Instance.AddSecondsToTimer(5f); // test
        InvokeRepeating("Generate", 0.0f, 3f); // Generates the humans direcley on launch (0.0f) and every second (..,1f)
        //_isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        PauseOrActivateGame();
        Timer.Instance.UpdateTimer();
        timeText.text = Timer.Instance.TimeRemaining.ConvertTimeToString();
        if (Timer.Instance.TimeEnded)
        {
            StartCoroutine(LoadScene());
        }
    }

    /// <summary>
    /// Corounatine to wait and then load scene
    /// </summary>
    /// <returns></returns>
    IEnumerator LoadScene()
    {
        GameObject.Find("Spider").GetComponent<Animator>().SetTrigger("die");
        yield return new WaitForSeconds(1);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);

        SceneManager.LoadSceneAsync("SavePlayerScene");
    }

    /// <summary>
    /// Check if the pause keys been pushen and game is paused
    /// </summary>
    void PauseOrActivateGame()
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
                ActivateGame();
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
    void ActivateGame()
    {
        Time.timeScale = 1;
        _isPaused = false;
    }

    /// <summary>
    /// Set human active and place it in a random place on scene
    /// </summary>
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
