using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnMouseUp()
    {
        string menuChoise = this.GetComponent<BoxCollider>().name;

        if (menuChoise == "RestartGame")
        {
            SceneManager.LoadScene("Stage1");
        }
        else if (menuChoise == "MainMenu")
        {
            SceneManager.LoadScene("MainMenu");
        }
        else if (menuChoise == "Quit")
        {
            Application.Quit();
        }
        else
        {
            throw new System.Exception("Something went wrong!");
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
}
