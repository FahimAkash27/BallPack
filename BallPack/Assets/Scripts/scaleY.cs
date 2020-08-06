using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleY : MonoBehaviour
{

	public float speed = .25f;
	public float maximumScale = 3f;
	public float minimumScale = 1f;
	Vector3 temp;
	int flag = 0;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		temp = transform.localScale;
		if(temp.y <= maximumScale && flag == 0 ){

			temp.y += Time.deltaTime * speed;
			transform.localScale = temp;
		}else{
			flag = 1;
			temp.y -= Time.deltaTime * speed;
			transform.localScale = temp;
			if(temp.y <= minimumScale){
				flag = 0;
			}

		}

	}
}
