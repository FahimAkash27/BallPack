using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateY : MonoBehaviour
{
	public float speed = 5f;

	private bool touch;

	public float upbound,downbound;

    // Start is called before the first frame update
    void Start()
    {
		touch = false;
    }

    // Update is called once per frame
    void Update()
    {	
		Vector3 com = transform.position;

		if(com.y >= upbound)
			touch = false;
		else if(com.y <= downbound)
			touch = true;

		if (touch == false) {

			transform.Translate (0f, -speed * Time.deltaTime, 0f);

		
		} else if (touch == true ) {
		
			transform.Translate (0f, speed * Time.deltaTime, 0f);

		}
    }



}
