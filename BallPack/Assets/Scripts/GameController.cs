using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float distanceBetweenTwoPlatform = 5f;
    public float lastPlatformEndPoint = 50f;
    public int levelNumber;

    public GameObject[] platformsForOneBall;
    public GameObject[] platforrmsForTwoBall;
    public GameObject[] platformsForThreeBall;

    public GameObject end;
    public GameObject endForTwo;
    public GameObject endForThree;

    public GameObject ball1;
    public GameObject ball2;
    public GameObject ball3;

    public GameObject initialPlatform1;
    public GameObject initialPlatform2;
    public GameObject initialPlatform3;

    public GameObject oneBallControl;
    public GameObject twoBallControl;
    public GameObject threeBallControl;

    public Material[] materials;
    int randomPlatformMaterial;

    int isPaused;



    void Start()
    {
        if (PlayerPrefs.HasKey("LevelNumber"))
        {
            levelNumber = PlayerPrefs.GetInt("LevelNumber");
        }
        else
        {
            levelNumber = 1;
            PlayerPrefs.SetInt("LevelNumber", levelNumber);
        }

        randomPlatformMaterial = UnityEngine.Random.Range(0, materials.Length);
        Debug.Log(randomPlatformMaterial);
        ColorChanger.colorChanger.SetBackgroundColor(randomPlatformMaterial);


        PlatfromGenerator(levelNumber);

        //Time.timeScale = 0;
        
    }


    public void PlatfromGenerator(int levelNumber)
    {
        if(levelNumber <= 5)
        {
            InitialSetupForOneBall();
            GeneratePlatformManuallyForOneBall(levelNumber);
        }
        else if(levelNumber > 5 && levelNumber <= 25)
        {
            InitialSetupForOneBall();
            GeneratePlatformAutomaticallyForOneBall(levelNumber);
        }else if(levelNumber > 25 && levelNumber <= 30)
        {

            InitialSetupForTwoBall();
            GeneratePlatformManuallyForTwoBall(levelNumber);
        }
        else if(levelNumber > 30 && levelNumber <=50)
        {
            InitialSetupForTwoBall();
            GeneratePlatformAutomaticallyForTwoBall(levelNumber);
        }
        else
        {
            InitialSetupForThreeBall();
            GeneratePlatformAutomaticallyForThreeBall(levelNumber);
        }
    }

    private void InitialSetupForOneBall()
    {
        ball1.transform.position = new Vector3(0f, 1.925f, 1.5f);
        ball1.SetActive(true);
        initialPlatform1.SetActive(true);
        PlatformmaterialChange(initialPlatform1, randomPlatformMaterial);
        oneBallControl.SetActive(true);
        
        initialPlatform1.transform.position = new Vector3(0f, 0f, 0f);

    }

    private void InitialSetupForTwoBall()
    {
        ball1.transform.position = new Vector3(-2f, 1.925f, 1.5f);
        ball2.transform.position = new Vector3(2f, 1.925f, 1.5f);
        ball1.SetActive(true);
        ball2.SetActive(true);
        twoBallControl.SetActive(true);


        initialPlatform1.SetActive(true);
        PlatformmaterialChange(initialPlatform1, randomPlatformMaterial);
        initialPlatform2.SetActive(true);
        PlatformmaterialChange(initialPlatform2, randomPlatformMaterial);
        initialPlatform1.transform.position = new Vector3(-2f, 0f, 0f);
        initialPlatform2.transform.position = new Vector3(2f, 0f, 0f);
        
    }
    private void InitialSetupForThreeBall()
    {

        ball1.transform.position = new Vector3(-4f, 1.925f, 1.5f);
        ball2.transform.position = new Vector3(4f, 1.925f, 1.5f);
        ball3.transform.position = new Vector3(0f, 1.925f, 1.5f);

        ball1.SetActive(true);
        ball2.SetActive(true);
        ball3.SetActive(true);

        initialPlatform1.SetActive(true);
        PlatformmaterialChange(initialPlatform1, randomPlatformMaterial);
        initialPlatform2.SetActive(true);
        PlatformmaterialChange(initialPlatform2, randomPlatformMaterial);
        initialPlatform3.SetActive(true);
        PlatformmaterialChange(initialPlatform3, randomPlatformMaterial);

        threeBallControl.SetActive(true);



        initialPlatform1.transform.position = new Vector3(-4f, 0f, 0f);
        initialPlatform2.transform.position = new Vector3(4f, 0f, 0f);
        initialPlatform3.transform.position = new Vector3(0f, 0f, 0f);

    }

    private float GettingEndPointOfLastPlatform(GameObject lastPlatform)
    {
        Transform endPointTransform = lastPlatform.transform.GetChild(0).GetChild(1);
        float endPoint = endPointTransform.position.z;
        return endPoint;
    }

    private void GeneratingEndWall(float generationPosition)
    {
        if(levelNumber <= 25)
        {
            Vector3 position = new Vector3(0f, 0f, generationPosition);
            GameObject endWall = Instantiate(end);
            endWall.transform.position = position;

            PlatformmaterialChange(endWall, randomPlatformMaterial);
        }
        else if(levelNumber <= 50)
        {
            Vector3 position = new Vector3(0f, 0f, generationPosition);
            GameObject endWall = Instantiate(endForTwo);
            endWall.transform.position = position;

            PlatformmaterialChange(endWall, randomPlatformMaterial);
        }
        else
        {
            Vector3 position = new Vector3(0f, 0f, generationPosition);
            GameObject endWall = Instantiate(endForThree);
            endWall.transform.position = position;

            PlatformmaterialChange(endWall, randomPlatformMaterial);
        }

    }

    private void GeneratePlatformManuallyForOneBall(int levelNumber)
    {
        if(levelNumber == 1)
        {
            float platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;

            Vector3 position = new Vector3(0f, 0f, platfromGenerationPoint);
            GameObject platform = Instantiate(platformsForOneBall[0]); // Generating Empty Platform
            platform.transform.position = position;

            PlatformmaterialChange(platform, randomPlatformMaterial);

            lastPlatformEndPoint = GettingEndPointOfLastPlatform(platform);
            platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;

            GeneratingEndWall(platfromGenerationPoint);



        }
        else if(levelNumber == 2)
        {
            float platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;
            Vector3 position = new Vector3(0f, 0f, platfromGenerationPoint);
            GameObject platform = Instantiate(platformsForOneBall[1]); 
            platform.transform.position = position;

            PlatformmaterialChange(platform, randomPlatformMaterial);

            lastPlatformEndPoint = GettingEndPointOfLastPlatform(platform);
            platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;

            position = new Vector3(0f, 0f, platfromGenerationPoint);
            platform = Instantiate(platformsForOneBall[1]);
            platform.transform.position = position;

            PlatformmaterialChange(platform, randomPlatformMaterial);

            lastPlatformEndPoint = GettingEndPointOfLastPlatform(platform);
            platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;

            GeneratingEndWall(platfromGenerationPoint);

        }
        else if(levelNumber == 3)
        {
            float platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;
            Vector3 position = new Vector3(0f, 0f, platfromGenerationPoint);
            GameObject platform = Instantiate(platformsForOneBall[1]);
            platform.transform.position = position;

            PlatformmaterialChange(platform, randomPlatformMaterial);

            lastPlatformEndPoint = GettingEndPointOfLastPlatform(platform);
            platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;

            position = new Vector3(0f, 0f, platfromGenerationPoint);
            platform = Instantiate(platformsForOneBall[0]);
            platform.transform.position = position;

            PlatformmaterialChange(platform, randomPlatformMaterial);

            lastPlatformEndPoint = GettingEndPointOfLastPlatform(platform);
            platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;

            position = new Vector3(0f, 0f, platfromGenerationPoint);
            platform = Instantiate(platformsForOneBall[1]);
            platform.transform.position = position;

            PlatformmaterialChange(platform, randomPlatformMaterial);




            lastPlatformEndPoint = GettingEndPointOfLastPlatform(platform);
            platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;

            GeneratingEndWall(platfromGenerationPoint);
        }
        else if(levelNumber == 4)
        {
            float platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;
            Vector3 position = new Vector3(0f, 0f, platfromGenerationPoint);
            GameObject platform = Instantiate(platformsForOneBall[0]);
            platform.transform.position = position;

            PlatformmaterialChange(platform, randomPlatformMaterial);

            for (int i = 1; i<=2; i++)
            {
                lastPlatformEndPoint = GettingEndPointOfLastPlatform(platform);
                platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;

                position = new Vector3(0f, 0f, platfromGenerationPoint);
                platform = Instantiate(platformsForOneBall[1]);
                platform.transform.position = position;

                PlatformmaterialChange(platform, randomPlatformMaterial);
            }

            lastPlatformEndPoint = GettingEndPointOfLastPlatform(platform);
            platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;

            position = new Vector3(0f, 0f, platfromGenerationPoint);
            platform = Instantiate(platformsForOneBall[0]);
            platform.transform.position = position;

            PlatformmaterialChange(platform, randomPlatformMaterial);


            lastPlatformEndPoint = GettingEndPointOfLastPlatform(platform);
            platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;

            GeneratingEndWall(platfromGenerationPoint);
        }
        else if(levelNumber == 5)
        {
            float platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;
            Vector3 position = new Vector3(0f, 0f, platfromGenerationPoint);
            GameObject platform = Instantiate(platformsForOneBall[2]);
            platform.transform.position = position;

            PlatformmaterialChange(platform, randomPlatformMaterial);

            lastPlatformEndPoint = GettingEndPointOfLastPlatform(platform);
            platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;

            position = new Vector3(0f, 0f, platfromGenerationPoint);
            platform = Instantiate(platformsForOneBall[1]);
            platform.transform.position = position;

            PlatformmaterialChange(platform, randomPlatformMaterial);

            lastPlatformEndPoint = GettingEndPointOfLastPlatform(platform);
            platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;

            position = new Vector3(0f, 0f, platfromGenerationPoint);
            platform = Instantiate(platformsForOneBall[0]);
            platform.transform.position = position;

            PlatformmaterialChange(platform, randomPlatformMaterial);

            lastPlatformEndPoint = GettingEndPointOfLastPlatform(platform);
            platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;

            position = new Vector3(0f, 0f, platfromGenerationPoint);
            platform = Instantiate(platformsForOneBall[2]);
            platform.transform.position = position;

            PlatformmaterialChange(platform, randomPlatformMaterial);


            lastPlatformEndPoint = GettingEndPointOfLastPlatform(platform);
            platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;

            GeneratingEndWall(platfromGenerationPoint);
        }
    }

    private void GeneratePlatformAutomaticallyForOneBall(int levelNumber)
    {
        int numberOfPlatfromGeneration = (levelNumber / 5) + 5;
        int totalNumberOfPlatform = platformsForOneBall.Length;

        float platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;

        for (int i = 1; i<numberOfPlatfromGeneration; i++)
        {
            int random = UnityEngine.Random.Range(0, totalNumberOfPlatform);

            Vector3 position = new Vector3(0f, 0f, platfromGenerationPoint);
            GameObject platform = Instantiate(platformsForOneBall[random]); // Generating Empty Platform
            platform.transform.position = position;

            PlatformmaterialChange(platform, randomPlatformMaterial);

            lastPlatformEndPoint = GettingEndPointOfLastPlatform(platform);
            platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;

        }


        GeneratingEndWall(platfromGenerationPoint);
    }

    private void GeneratePlatformManuallyForTwoBall(int levelNumber)
    {
        if (levelNumber == 26)
        {
            float platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;

            Vector3 position = new Vector3(0f, 0f, platfromGenerationPoint);
            GameObject platform = Instantiate(platforrmsForTwoBall[2]); // Generating Empty Platform
            platform.transform.position = position;

            PlatformmaterialChange(platform, randomPlatformMaterial);

            lastPlatformEndPoint = GettingEndPointOfLastPlatform(platform);
            platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;

            GeneratingEndWall(platfromGenerationPoint);



        }
        else if (levelNumber == 27)
        {
            float platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;
            Vector3 position = new Vector3(0f, 0f, platfromGenerationPoint);
            GameObject platform = Instantiate(platforrmsForTwoBall[1]);
            platform.transform.position = position;

            PlatformmaterialChange(platform, randomPlatformMaterial);

            lastPlatformEndPoint = GettingEndPointOfLastPlatform(platform);
            platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;

            position = new Vector3(0f, 0f, platfromGenerationPoint);
            platform = Instantiate(platforrmsForTwoBall[2]);
            platform.transform.position = position;

            PlatformmaterialChange(platform, randomPlatformMaterial);

            lastPlatformEndPoint = GettingEndPointOfLastPlatform(platform);
            platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;

            GeneratingEndWall(platfromGenerationPoint);

        }
        else if (levelNumber == 28)
        {
            float platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;
            Vector3 position = new Vector3(0f, 0f, platfromGenerationPoint);
            GameObject platform = Instantiate(platforrmsForTwoBall[2]);
            platform.transform.position = position;

            PlatformmaterialChange(platform, randomPlatformMaterial);

            lastPlatformEndPoint = GettingEndPointOfLastPlatform(platform);
            platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;

            position = new Vector3(0f, 0f, platfromGenerationPoint);
            platform = Instantiate(platforrmsForTwoBall[0]);
            platform.transform.position = position;

            PlatformmaterialChange(platform, randomPlatformMaterial);

            lastPlatformEndPoint = GettingEndPointOfLastPlatform(platform);
            platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;

            position = new Vector3(0f, 0f, platfromGenerationPoint);
            platform = Instantiate(platforrmsForTwoBall[3]);
            platform.transform.position = position;

            PlatformmaterialChange(platform, randomPlatformMaterial);




            lastPlatformEndPoint = GettingEndPointOfLastPlatform(platform);
            platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;

            GeneratingEndWall(platfromGenerationPoint);
        }
        else if (levelNumber == 29)
        {
            float platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;
            Vector3 position = new Vector3(0f, 0f, platfromGenerationPoint);
            GameObject platform = Instantiate(platforrmsForTwoBall[0]);
            platform.transform.position = position;

            PlatformmaterialChange(platform, randomPlatformMaterial);

            for (int i = 1; i <= 2; i++)
            {
                lastPlatformEndPoint = GettingEndPointOfLastPlatform(platform);
                platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;

                position = new Vector3(0f, 0f, platfromGenerationPoint);
                platform = Instantiate(platforrmsForTwoBall[1]);
                platform.transform.position = position;

                PlatformmaterialChange(platform, randomPlatformMaterial);
            }

            lastPlatformEndPoint = GettingEndPointOfLastPlatform(platform);
            platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;

            position = new Vector3(0f, 0f, platfromGenerationPoint);
            platform = Instantiate(platforrmsForTwoBall[4]);
            platform.transform.position = position;

            PlatformmaterialChange(platform, randomPlatformMaterial);


            lastPlatformEndPoint = GettingEndPointOfLastPlatform(platform);
            platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;

            GeneratingEndWall(platfromGenerationPoint);
        }
        else if (levelNumber == 30)
        {
            float platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;
            Vector3 position = new Vector3(0f, 0f, platfromGenerationPoint);
            GameObject platform = Instantiate(platforrmsForTwoBall[4]);
            platform.transform.position = position;

            PlatformmaterialChange(platform, randomPlatformMaterial);

            lastPlatformEndPoint = GettingEndPointOfLastPlatform(platform);
            platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;

            position = new Vector3(0f, 0f, platfromGenerationPoint);
            platform = Instantiate(platforrmsForTwoBall[1]);
            platform.transform.position = position;

            PlatformmaterialChange(platform, randomPlatformMaterial);

            lastPlatformEndPoint = GettingEndPointOfLastPlatform(platform);
            platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;

            position = new Vector3(0f, 0f, platfromGenerationPoint);
            platform = Instantiate(platforrmsForTwoBall[0]);
            platform.transform.position = position;

            PlatformmaterialChange(platform, randomPlatformMaterial);

            lastPlatformEndPoint = GettingEndPointOfLastPlatform(platform);
            platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;

            position = new Vector3(0f, 0f, platfromGenerationPoint);
            platform = Instantiate(platforrmsForTwoBall[2]);
            platform.transform.position = position;

            PlatformmaterialChange(platform, randomPlatformMaterial);


            lastPlatformEndPoint = GettingEndPointOfLastPlatform(platform);
            platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;

            GeneratingEndWall(platfromGenerationPoint);
        }
    }

    private void GeneratePlatformAutomaticallyForTwoBall(int levelNumber)
    {
        int numberOfPlatfromGeneration = (levelNumber / 5) -1;
        int totalNumberOfPlatform = platforrmsForTwoBall.Length;

        float platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;

        for (int i = 1; i < numberOfPlatfromGeneration; i++)
        {
            int random = UnityEngine.Random.Range(0, totalNumberOfPlatform);

            Vector3 position = new Vector3(0f, 0f, platfromGenerationPoint);
            GameObject platform = Instantiate(platforrmsForTwoBall[random]);
            platform.transform.position = position;

            PlatformmaterialChange(platform, randomPlatformMaterial);

            lastPlatformEndPoint = GettingEndPointOfLastPlatform(platform);
            platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;

        }


        GeneratingEndWall(platfromGenerationPoint);
    }

    private void GeneratePlatformAutomaticallyForThreeBall(int levelNumber)
    {
        int numberOfPlatfromGeneration = (levelNumber / 5) - 7;
        int totalNumberOfPlatform = platformsForThreeBall.Length;

        float platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;


        for (int i = 1; i < numberOfPlatfromGeneration; i++)
        {
            int random = UnityEngine.Random.Range(0, totalNumberOfPlatform);

            Vector3 position = new Vector3(0f, 0f, platfromGenerationPoint);
            GameObject platform = Instantiate(platformsForThreeBall[random]);
            platform.transform.position = position;

            PlatformmaterialChange(platform, randomPlatformMaterial);

            lastPlatformEndPoint = GettingEndPointOfLastPlatform(platform);
            platfromGenerationPoint = distanceBetweenTwoPlatform + lastPlatformEndPoint;

        }


        GeneratingEndWall(platfromGenerationPoint);
    }

    private void PlatformmaterialChange(GameObject platform,int random)
    {
        foreach (var v in platform.GetComponentsInChildren<Renderer>())
        {
            if (v.tag == "Platform")
            {

                GameObject p = v.gameObject;                          // Need Optimization
                p.GetComponent<Renderer>().material = materials[random];

            }
        }
    }


}
