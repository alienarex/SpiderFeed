using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Ref: https://www.instructables.com/id/How-to-make-a-main-menu-in-Unity/
    public bool isStart;
    public bool isQuit;
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnMouseUp()
    {
        if (isStart)
        {
            SceneManager.LoadScene(1);
        }
        if (isQuit)
        {
            Application.Quit();
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
