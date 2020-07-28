using System.Collections;
using UnityEngine;
public class SpiderController : MonoBehaviour
{

    public float _speed;
    private Animator animator;
    private Transform enemy;
    public AudioSource audioSource;
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        _speed = 100;
    }

    private Vector3 moveDirection = Vector3.zero;
    float speed = 5;
    private float rotationSpeed = 100.0f;
    private bool walking = false;

    void Update()
    {
        controller = GetComponent<CharacterController>();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // https://answers.unity.com/questions/1362883/how-to-make-an-animation-play-on-keypress-unity-ga.html
            animator.SetTrigger("attack");
        }
        // Triggers animation walk when arrows are pressed
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.UpArrow))
        {
            walking = true;
        }
        else
        {
            walking = false;
        }
        //anim.transform.position.x // horizontal
        //anim.transform.position.z // vericalt

        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        rotation *= Time.deltaTime;
        transform.Rotate(0, rotation, 0);
        moveDirection = transform.TransformDirection(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection *= speed;

        animator.SetBool("walking", walking);
        controller.Move(moveDirection * Time.deltaTime);


    }

    /// <summary>
    /// Removes the object when collided and attacked
    /// </summary>
    /// <param name="collideObject"></param>
    void OnTriggerEnter(Collider collideObject)
    {

        if (collideObject.gameObject.tag == "Human")
        {
            StopCoroutine("ReenableMovement");
            animator.gameObject.transform.position = Vector3.zero;
            animator.SetBool("walking", false);
            audioSource.Play();
            animator.SetTrigger("attack");
            collideObject.gameObject.SetActive(false);
            StartCoroutine("ReenableMovement");
        }
    }


    private IEnumerator ReenableMovement()
    {
        walking = true;
        yield return new WaitForSeconds(10);
        //rb.isKinematic = false;
        controller.Move(moveDirection * Time.deltaTime);

        //isRunning = false;
    }
    #region old code
    //// Update is called once per frame
    //void Update()
    //{

    //    bool walking = Input.GetKey(KeyCode.W);
    //    animator.SetBool("walking", walking);
    //    if (Input.GetKeyDown(KeyCode.A))
    //    {
    //        animator.SetTrigger("attack");
    //    }
    //    //animator = GetComponent<Animator>();
    //    //int layerIndex = animator.GetLayerIndex("Base Layer");
    //    //AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(layerIndex);
    //    //animator.StartPlayback();
    //    //firstBehavior = ScriptableObject.CreateInstance<FirstBehavior>();
    //    //firstBehavior.OnStateEnter(animator, stateInfo, layerIndex);
    //    //float moveH = Input.GetAxis("Horizontal");
    //    //float moveV = Input.GetAxis("Vertical");

    //    //Vector3 movement = new Vector3(moveH, 0.0f, moveV);
    //    //body.AddForce(movement * _speed * Time.deltaTime);
    //}
    #endregion
}
