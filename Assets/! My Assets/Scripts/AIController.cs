﻿using UnityEngine;
using Random = UnityEngine.Random;

public class AIController : MonoBehaviour
{
    public Transform player;
    static Animator anim;
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        targetPosition = new Vector3(Random.Range(-70.0f, 70.0f), 0.0f, Random.Range(-70.0f, 70.0f));

    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(targetPosition, this.transform.position) < 10)
        {
            targetPosition = new Vector3(Random.Range(-70.0f, 70.0f), 0.0f, Random.Range(-70.0f, 70.0f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Referens: https://www.youtube.com/watch?v=gXpi1czz5NA
        Vector3 direction = targetPosition - this.transform.position; // makes the enemy know where the player are
        direction.y = 0; // Removces the posibility for the character to rotate upwards (y-angle)

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

        if (direction.magnitude > 5) // magnitude == length (Z axes is forward)
        {// might be useful for checking if clsoe enought to eat.
            this.transform.Translate(0, 0, 0.05f);
        }
    }
    void OnAttack(Collider colliderObject)
    {
        if (colliderObject.tag == "Human")
        {
            colliderObject.enabled = false;
        }
    }
}
