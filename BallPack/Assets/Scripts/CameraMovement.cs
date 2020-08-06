using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform cameraFollowing;
    int gameMode;
    public float speed;

    public static int stop;

    Rigidbody rigidbody;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        stop = 0;
    }

    void Update()
    {
        if(stop == 0)
        {
            Vector3 newPosition = new Vector3(this.transform.position.x, this.transform.position.y, cameraFollowing.transform.position.z);
            this.transform.position = newPosition;
        }


    }
}
