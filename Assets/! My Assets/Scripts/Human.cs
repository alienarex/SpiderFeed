using System.Collections;
using UnityEngine;

public class Human : MonoBehaviour
{
    private float _lifeTimeSpan = 20;

    public int Size { get; set; }
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

    // Start is called before the first frame update
    void Start()
    {
        LifeCycleSpan = _lifeTimeSpan;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
