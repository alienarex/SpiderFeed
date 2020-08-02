using Assets.__My_Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class GameEngine : MonoBehaviour
{
    public GameObject spider;
    public Text countText;
    public int initTime;
    private CountdownControl countdownControl;

    // Start is called before the first frame update
    void Start()
    {
        countdownControl = new CountdownControl(initTime);
    }
    Animator animator;
    // Update is called once per frame
    void Update()
    { 
        countText.text = countdownControl.GetRemainingTime();
        if (countdownControl.TimeEnded)
        {
            animator = spider.GetComponent<Animator>();
            animator.SetTrigger("die");
        }
    }
}
