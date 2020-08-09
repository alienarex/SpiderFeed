﻿using UnityEngine;
using UnityEngine.UI;
using static Assets.__My_Assets.Scripts.CountdownControl;


public class SpiderController : MonoBehaviour
{

    //float speed = 5; // Obsolete?
    //private Transform enemy; // Obsolete?

    [SerializeField] private float _movementSpeed;

    private Vector3 _moveDirection = Vector3.zero;
    private float _rotationSpeed = 100.0f;
    private Animator _animator;
    private CharacterController _controller;
    private bool _canMove;

    public AudioSource audioSource;
    public Text countEatenHumans;
    public int HumansEaten { get; private set; }

    public bool CanMove
    {
        get => _canMove;
        set
        {
            if (_canMove != value)
            {
                _canMove = value;
            }
        }
    }// Test to make spider stop when attacking


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
        _movementSpeed = 5;
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // https://answers.unity.com/questions/1362883/how-to-make-an-animation-play-on-keypress-unity-ga.html
            _animator.SetTrigger("attack");
        }

        //TODO When space pressed the movements stops but animations keeps going
        if (CanMove)
        {

            float rotation = Input.GetAxis("Horizontal") * _rotationSpeed;
            rotation *= Time.deltaTime;
            transform.Rotate(0, rotation, 0);
            _moveDirection = transform.TransformDirection(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _moveDirection *= _movementSpeed;

            // Triggers animation when object moves
            //if (moveDirection != Vector3.zero)
            if (_moveDirection.magnitude > 0.1)
            {
                _animator.SetBool("walking", true);
            }
            else
            {
                _animator.SetBool("walking", false);
            }

            _controller.Move(_moveDirection * Time.deltaTime);
        }
    }

    /// <summary>
    /// Removes the object when collided and attacked
    /// </summary>
    /// <param name="colliderObject"></param>
    void OnTriggerEnter(Collider colliderObject)
    {
        int secondsToAdd = 10;
        if (colliderObject.gameObject.tag == "Human")
        {
            _animator.SetTrigger("attack");
            audioSource.Play();
            colliderObject.gameObject.SetActive(false);
            IncreaseCountdown(secondsToAdd);
            //audioSource.Stop();
        }
    }
}