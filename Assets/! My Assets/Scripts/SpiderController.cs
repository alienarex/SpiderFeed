﻿using Assets.__My_Assets.Scripts;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpiderController : MonoBehaviour
{

    [SerializeField] private float _movementSpeed;
    public GameObject bloodSplatterPrefab;
    private Vector3 _moveDirection = Vector3.zero;
    private float _rotationSpeed = 150.0f;
    private Animator _animator;
    private CharacterController _controller;

    public Text countEatenHumans;
    bool timerIsRunning;


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // https://answers.unity.com/questions/1362883/how-to-make-an-animation-play-on-keypress-unity-ga.html
            _animator.SetTrigger("attack");
            var test = _animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;

        }
        else
        {
            float rotation = Input.GetAxis("Horizontal") * _rotationSpeed;
            rotation *= Time.deltaTime;
            transform.Rotate(0, rotation, 0);
            _moveDirection = transform.TransformDirection(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _moveDirection *= _movementSpeed;

            // Triggers animation when object moves
            _animator.SetFloat("walking", _moveDirection.magnitude);

            _controller.Move(_moveDirection * Time.deltaTime);

        }
    }
}