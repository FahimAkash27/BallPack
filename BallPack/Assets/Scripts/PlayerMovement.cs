using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Rigidbody rigidbody;

    public string jumpKey;

    int flag = 0;

    public bool  IsGrounded;

    Vector3 newVelocity;

    public float jumpSpeed = 2;
    public float maxSpeed = 1;

    public GameObject deathPartical;

    bool jump;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        IsGrounded = true;
    }

    //void Update()
    //{

    //    if (Input.GetKey(jumpKey) && IsGrounded == true)
    //    {
    //        IsGrounded = false;
    //        rigidbody.AddForce(new Vector3(0f, jumpForce, rigidbody.velocity.z));
    //    }
    //    else if (IsGrounded == true)
    //    {
    //        //rigidbody.velocity = Vector3.forward * speed;
    //        rigidbody.AddForce(Vector3.forward * speed);

    //    }


    //}


    void Update()
    {

        var newVelocity = rigidbody.velocity;
        if (Input.GetKey(jumpKey) && IsGrounded == true)
        {

            Jump();
        }

        if (jump == true)
        {
            newVelocity.y = jumpSpeed;
            jump = false;
        }
        newVelocity.z = maxSpeed;
        rigidbody.velocity = newVelocity;



    }

    public void Jump()
    {
        //if(Time.timeScale == 0)
        //{
        //    Time.timeScale = 1;
        //}

        if(IsGrounded == true)
        {            
            IsGrounded = false;
            jump = true;

        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            IsGrounded = true;
            //if(flag == 1)
            //{
            //    Debug.Log(gameObject.transform.position.z);
            //    flag = 0;
            //}
        }
        if (collision.gameObject.tag == "EnemyCube")
        {
            int gameMode = PlayerPrefs.GetInt("GameMode");
            if(gameMode == 3)
            {
                SceneManager.LoadScene("Gameplay");
            }
            else
            {
                //gameObject.SetActive(false);
                var players = GameObject.FindGameObjectsWithTag("Player");
                foreach (var player in players)
                    player.SetActive(false);
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Finish")
        {
            CanvasScript.canvasScript.ShowLevelCompletePanel();
            gameObject.SetActive(false);

        }

        if(other.tag == "EnemyCube")
        {
            GameObject d = Instantiate(deathPartical);
            d.transform.position = other.transform.position - Vector3.forward;
            CanvasScript.canvasScript.ShowRestartPanel();
            gameObject.SetActive(false);
            CameraMovement.stop = 1;
        }
        if(other.tag == "DeathBelow")
        {
            GameObject d = Instantiate(deathPartical);
            d.transform.position = other.transform.position - Vector3.forward*3;
            CanvasScript.canvasScript.ShowRestartPanel();
            gameObject.SetActive(false);
            CameraMovement.stop = 1;
        }
    }


    public void Restart()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in enemies)
        {
            Destroy(enemy);
        }

        var platforms = GameObject.FindGameObjectsWithTag("Platform");
        foreach (var platform in platforms)
        {
            Destroy(platform);
        }

        var finish = GameObject.FindGameObjectWithTag("Finish");
        Destroy(finish);

        GameManazer.GM.LevelStart();

    }


}
