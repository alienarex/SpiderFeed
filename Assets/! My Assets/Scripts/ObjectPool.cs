using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    // Ref: https://learn.unity.com/tutorial/introduction-to-object-pooling-2019-3#5ea6e96eedbc2a001f584402

    public static ObjectPool sharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPoolFemale;
    public GameObject objectToPoolMale;
    public int amountMaleAndFemaleToPool;

    private void Awake()
    {
        sharedInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountMaleAndFemaleToPool; i++)
        {
            tmp = Instantiate(objectToPoolFemale);
            tmp.AddComponent<Human>();
            tmp.SetActive(false);
            pooledObjects.Add(tmp);

            tmp = Instantiate(objectToPoolMale);
            tmp.AddComponent<Human>();
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public GameObject GetPooledObjects()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
