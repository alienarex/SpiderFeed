using System.Collections;
using UnityEngine;
using static Assets.__My_Assets.Scripts.CountdownControl;

public class Human : MonoBehaviour
{
    private int _timeValue = 10;
    private float _lifeTimeSpan = 20;

    public int Size { get; set; }
    public int TimeValue { get; private set; }
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

    IEnumerator Hide()
    {
        yield return new WaitForSeconds(LifeCycleSpan);
        this.gameObject.SetActive(false);
    }

    void SetInactiveHuman()
    {
        IncreaseCountdown(TimeValue);
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
