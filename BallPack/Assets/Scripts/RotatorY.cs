using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorY : MonoBehaviour
{
	public float speed = 100f;

	// Update is called once per frame
	void Update () {
		transform.Rotate(0f,speed * Time.deltaTime,0f);
	}
}
