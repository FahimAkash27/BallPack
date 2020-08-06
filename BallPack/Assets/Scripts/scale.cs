using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scale : MonoBehaviour
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
		if(temp.x <= maximumScale && flag == 0 ){

			temp.x += Time.deltaTime * speed;
			transform.localScale = temp;
		}else{
			flag = 1;
			temp.x -= Time.deltaTime * speed;
			transform.localScale = temp;
			if(temp.x <= minimumScale){
				flag = 0;
			}

		}

    }
}
