using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Assets.__My_Assets.Scripts.CountdownControl;


public class SpiderController : MonoBehaviour
{

    [SerializeField] private float _movementSpeed;
    public GameObject bloodSplatterPrefab;
    private Vector3 _moveDirection = Vector3.zero;
    private float _rotationSpeed = 150.0f;
    private Animator _animator;
    private CharacterController _controller;

    public Text countEatenHumans;


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetRemainingTime();
        if (!TimeEnded)
        {
            //countText.text = CountdownText;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                // https://answers.unity.com/questions/1362883/how-to-make-an-animation-play-on-keypress-unity-ga.html
                _animator.SetTrigger("attack");

            }

            float rotation = Input.GetAxis("Horizontal") * _rotationSpeed;
            rotation *= Time.deltaTime;
            transform.Rotate(0, rotation, 0);
            _moveDirection = transform.TransformDirection(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _moveDirection *= _movementSpeed;

            // Triggers animation when object moves
            _animator.SetFloat("walking", _moveDirection.magnitude);

            _controller.Move(_moveDirection * Time.deltaTime);

        }
        else if (TimeEnded)
        {
            StartCoroutine("LoadScene");
        }
    }

    IEnumerator LoadScene()
    {
        //animator = player.GetComponent<Animator>();
        _animator.SetTrigger("die");
        //player.GetComponent<SpiderController>().CanMove = false;
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync("SavePlayerScene"); // Can Async put gameover scene on top of current scenee?
    }

    /// <summary>
    /// Removes the object when collided and attacked
    /// </summary>
    /// <param name="colliderObject"></param>
    void OnTriggerEnter(Collider colliderObject)
    {
        int secondsToAdd = 10;
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {

            if (colliderObject.gameObject.tag == "Human")
            {
                colliderObject.gameObject.SetActive(false);
                IncreaseCountdown(secondsToAdd);
            }
        }
    }
}