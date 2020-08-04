using static Assets.__My_Assets.Scripts.CountdownControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameEngine : MonoBehaviour
{
    Animator animator;
    public GameObject spider;

    public Text countText;
    //public int initTime;
    public GameObject femaleHuman;
    public GameObject maleHuman;
    private GameObject randomizedHuman;
    private GameObject gameEngineGameObject;
    Transform humanParent;
    Transform player;

    private void Awake()
    {
        //humanParent = transform.GetChild(4);
        player = transform.GetChild(3);
        player.GetComponent<SpiderController>().CanMove = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        SetCountdownClock(MainMenuController.SetInitialMinutesToGame);
        //SetCountdownClock(1);// for testing. Remove in build
        InvokeRepeating("Generate", 0.0f, 3f); // Generates the humans direcley on launch (0.0f) and every second (..,1f)
    }

    public void Generate()
    {
        GameObject human = ObjectPool.sharedInstance.GetPooledObjects();
        if (human != null)
        {
            float randomPosition = Random.Range(-100, 100);
            human.SetActive(true);
            Vector3 position = new Vector3(transform.position.x + randomPosition, 0, transform.position.z + randomPosition); // Calculates a new positionfor spawend human
            human.transform.position = position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetRemainingTime();

        if (!TimeEnded)
        {
            countText.text = CountdownText;
        }
        else
        {
            animator = spider.GetComponent<Animator>();

            animator.SetTrigger("die");
            spider.GetComponent<SpiderController>().CanMove = false;
            countText.text = "--:--";


        }
    }
}
