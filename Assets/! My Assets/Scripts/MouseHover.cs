using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHover : MonoBehaviour
{
    // Ref: https://www.instructables.com/id/How-to-make-a-main-menu-in-Unity/

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Renderer>().material.color = Color.white;
    }
    private void OnMouseEnter()
    {
        this.GetComponent<Renderer>().material.color = Color.red;
    }
    private void OnMouseExit()
    {
        this.GetComponent<Renderer>().material.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
