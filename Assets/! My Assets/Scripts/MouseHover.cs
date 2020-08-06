using System.IO;
using UnityEngine;

public class MouseHover : MonoBehaviour
{
    // Ref: https://www.instructables.com/id/How-to-make-a-main-menu-in-Unity/
    private Renderer renderer;
    private TextMesh textMesh;
    private int changeFontSizeOnMouseOver;

    private void Awake()
    {
        renderer = this.GetComponent<Renderer>();
        textMesh = this.GetComponent<TextMesh>();
    }

    // Start is called before the first frame update
    void Start()
    {
        this.renderer.material.color = Color.white;
        changeFontSizeOnMouseOver = 10;
    }
    private void OnMouseEnter()
    {
        this.renderer.material.color = Color.green;
        textMesh.fontSize = textMesh.fontSize + changeFontSizeOnMouseOver;
    }
    private void OnMouseExit()
    {
        this.GetComponent<Renderer>().material.color = Color.white;
        textMesh.fontSize = textMesh.fontSize - changeFontSizeOnMouseOver;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
