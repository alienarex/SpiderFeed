using System.Collections.Generic;
using UnityEngine;

public class SpawnNewHumans : MonoBehaviour
{
    //Ref: https://www.youtube.com/watch?v=nLo-79cWOk0
    public GameObject femaleHuman;
    public GameObject maleHuman;
    private GameObject randomizedHuman;
    private List<Human> humans;
    private int isFemale;

    private void Awake()
    {
        humans = new List<Human>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("Generate", 0.0f, 1f); // Generates the humans direcley on launch (0.0f) and every second (..,1f)
        //humans.Add(new Human { GameObjectHuman = randomizedHuman });
    }

    public void Generate()
    {
        //GameObject human = ObjectPool.sharedInstance.GetPooledObjects();
        //if (human != null)
        //{
        //    float randomPosition = Random.Range(-100, 100);
        //    human.SetActive(true);
        //    Vector3 position = new Vector3(transform.position.x + randomPosition, 0, transform.position.z + randomPosition); // Calculates a new positionfor spawend human
        //    human.transform.position = position;
        //}
        //int randomHuman = Random.Range(0, 2);
        //randomizedHuman = randomHuman == 1 ? femaleHuman : maleHuman;
        //Instantiate(randomizedHuman, position, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
