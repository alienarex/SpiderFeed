using System.Collections;
using UnityEngine;
using static Assets.__My_Assets.Scripts.CountdownControl;
public class SpiderController : MonoBehaviour
{

    public float _speed;
    private Animator animator;
    private Transform enemy;
    public AudioSource audioSource;
    private CharacterController controller;
    private bool canMove = false;
    //private CountdownControl countdownControl;
    public bool CanMove
    {
        get => canMove;
        set
        {
            if (canMove != value)
            {
                canMove = value;
            }
        }
    }// Test to make spider stop when attacking
    public int HumansEaten { get; private set; }



    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        _speed = 100;
        controller = GetComponent<CharacterController>();
    }

    private Vector3 moveDirection = Vector3.zero;
    float speed = 5;
    private float rotationSpeed = 100.0f;
    private bool walking = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // https://answers.unity.com/questions/1362883/how-to-make-an-animation-play-on-keypress-unity-ga.html
            animator.SetTrigger("attack");
            CanMove = false;
        }
        if (CanMove)
        {

            // Triggers animation walk when arrows are pressed
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.UpArrow))
            {
                walking = true;
            }
            else
            {
                walking = false;
            }

            float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
            rotation *= Time.deltaTime;
            transform.Rotate(0, rotation, 0);
            moveDirection = transform.TransformDirection(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            animator.SetBool("walking", walking);
            controller.Move(moveDirection * Time.deltaTime);
        }
    }

    /// <summary>
    /// Removes the object when collided and attacked
    /// </summary>
    /// <param name="collideObject"></param>
    void OnTriggerEnter(Collider collideObject)
    {
        int secondsToAdd = 10;
        HumansEaten = 0;
        if (collideObject.gameObject.tag == "Human")
        {
            audioSource.Play();
            animator.SetTrigger("attack");
            collideObject.gameObject.SetActive(false);
            IncreaseCountdown(secondsToAdd);
        }
    }
}
