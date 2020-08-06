using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera playerOneCamera;
    public Camera playerTwoCamera;
    void Update()
    {

        playerOneCamera.rect.Set(0f, 0f, 1f, 0.5f);
        playerTwoCamera.rect.Set(0f,0.5f,1f,0.5f);
    }

}
