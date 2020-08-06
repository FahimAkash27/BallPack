using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBelowMovement : MonoBehaviour
{
    public Transform BallFollowing;

    Rigidbody rigidbody;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 newPosition = new Vector3(BallFollowing.transform.position.x, this.transform.position.y, BallFollowing.transform.position.z);
        this.transform.position = newPosition;

    }
}
