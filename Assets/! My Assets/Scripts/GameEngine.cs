using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Assets.__My_Assets.Scripts.CountdownControl;

public class GameEngine : MonoBehaviour
{
    #region possible obsolete
    //public int initTime;
    //private GameObject randomizedHuman;
    //private GameObject gameEngineGameObject;
    //Transform humanParent;
    //private GameObject spider;
    #endregion possible obsolete

    Animator animator;
    public Text countText;
    //public GameObject femaleHuman;
    //public GameObject maleHuman;
    Transform player;

    private void Awake()
    {
        //humanParent = transform.GetChild(4); //Obsolete?
        player = transform.GetChild(3);
        player.GetComponent<SpiderController>().CanMove = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        //SetCountdownClock(MainMenuController.SetInitialMinutesToGame);
        SetCountdownClock(1);// for testing. Remove in build
        InvokeRepeating("Generate", 0.0f, 3f); // Generates the humans direcley on launch (0.0f) and every second (..,1f)
    }

    public void Generate()
    {
        GameObject human = ObjectPool.sharedInstance.GetPooledObjects();
        if (human != null)
        {
            float randomPosition = UnityEngine.Random.Range(-100, 100);
            human.SetActive(true);
            Vector3 position = new Vector3(transform.position.x + randomPosition, 0, transform.position.z + randomPosition); // Calculates a new positionfor spawend human
            human.transform.position = position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        TimeSpan timeElapsed; // For duration of game
        GetRemainingTime();
        if (!TimeEnded)
        {
            countText.text = CountdownText;
        }
        else if (TimeEnded)
        {
            StartCoroutine("LoadScene");
        }
    }

    IEnumerator LoadScene()
    {
        animator = player.GetComponent<Animator>();
        animator.SetTrigger("die");
        player.GetComponent<SpiderController>().CanMove = false;

        countText.text = GetTotalTimePlayed;
        yield return new WaitForSeconds(3);
        SceneManager.LoadSceneAsync("GameOver"); // Can Async put gameover scene on top of current scenee?
    }
}
