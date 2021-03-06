﻿using Assets.__My_Assets.Scripts;
using System.Collections;
using UnityEngine;

public class Human : MonoBehaviour
{
    private float _timeValue = 10;
    private float _lifeTimeSpan = 20;

    public int Size { get; set; }
    public float TimeValue { get; private set; }
    public float LifeCycleSpan
    {
        get => _lifeTimeSpan;
        private set
        {
            if (_lifeTimeSpan != value)
            {
                _lifeTimeSpan = value;
            }
        }
    }

    // Ref: https://forum.unity.com/threads/setting-inactive-after-some-seconds-script-only-working-once.488975/
    void OnEnable()
    {
        StartCoroutine(Hide());
    }

    /// <summary>
    /// Corountine to inactivate human in hirachey after set life cykle value
    /// </summary>
    /// <returns></returns>
    IEnumerator Hide()
    {
        yield return new WaitForSeconds(LifeCycleSpan);
        this.gameObject.SetActive(false);
    }

    /// <summary>
    /// Sets the game object human as inactivated in hirierachy if attacked
    /// </summary>
    void SetInactiveHuman()
    {
        Timer.Instance.AddSecondsToTimer(TimeValue);
        this.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        LifeCycleSpan = _lifeTimeSpan;
        TimeValue = _timeValue;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
