using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public static ColorChanger colorChanger;

    
    public Color[] cameraColors;
    public Camera camera;

    private void Awake()
    {
        colorChanger = this;
    }


    public void SetBackgroundColor(int random)
    {
        camera.backgroundColor = cameraColors[random];
    }

}
