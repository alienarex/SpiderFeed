using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNewHumans : MonoBehaviour
{
    //Ref: https://www.youtube.com/watch?v=nLo-79cWOk0
    public GameObject femaleHuman;
    public GameObject maleHuman;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Generate", 0.0f, 3f); // Generates the humans after set timing (0.0f,0.01f) every millisecond
    }

    public void Generate()
    {
        float randomPosition = Random.Range(-100, 100);
        Vector3 position = new Vector3(transform.position.x + randomPosition, 0, transform.position.z + randomPosition); // Calculates a new positionfor spawend human
        Instantiate(femaleHuman, position, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
