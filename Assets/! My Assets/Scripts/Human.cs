using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class Human : MonoBehaviour
{
    private float lifeTimeSpan = 4;
    public int Size { get; set; }
    public float LifeCycleSpan
    {
        get => lifeTimeSpan;
        private set
        {
            if (lifeTimeSpan != value)
            {
                lifeTimeSpan = value;
            }
        }
    }

    // Ref: https://forum.unity.com/threads/setting-inactive-after-some-seconds-script-only-working-once.488975/
    void OnEnable()
    {
        StartCoroutine(Hide());
    }

    IEnumerator Hide()
    {
        yield return new WaitForSeconds(LifeCycleSpan);
        this.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        LifeCycleSpan = lifeTimeSpan;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
