using UnityEngine;
using UnityEngine.UI;
using static Assets.__My_Assets.Scripts.CountdownControl;


public class SpiderController : MonoBehaviour
{

    public float _speed;
    private Animator animator;
    private Transform enemy;
    public AudioSource audioSource;
    private CharacterController controller;
    private bool canMove = false;
    public Text countEatenHumans;

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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // https://answers.unity.com/questions/1362883/how-to-make-an-animation-play-on-keypress-unity-ga.html
            animator.SetTrigger("attack");
        }

        //TODO When space pressed the movements stops but animations keeps going
        if (CanMove)
        {

            float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
            rotation *= Time.deltaTime;
            transform.Rotate(0, rotation, 0);
            moveDirection = transform.TransformDirection(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            // Triggers animation when object moves
            if (moveDirection != Vector3.zero)
            {
                animator.SetBool("walking", true);
            }
            else
            {
                animator.SetBool("walking", false);
            }

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
        if (collideObject.gameObject.tag == "Human")
        {
            animator.SetTrigger("attack");
            audioSource.Play();
            collideObject.gameObject.SetActive(false);
            IncreaseCountdown(secondsToAdd);
            //audioSource.Stop();
        }
    }
}