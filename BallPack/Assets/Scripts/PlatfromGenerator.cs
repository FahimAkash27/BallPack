using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlatfromGenerator : MonoBehaviour
{
    public int level;
    public GameObject levelStartPanel;
    public GameObject player;
    public GameObject background;
    public Text levelNumberText;
    float platfromGenerationPoint = 146f;

    public GameObject platform;
    public GameObject[] enemies;
    public GameObject finishZone;

    public GameObject nextReswapningTrigger;


    public float nextPlatformGenerationPosition;
    public float nextEnemyGenerationPosition;

    public static PlatfromGenerator PG;

    private void Awake()
    {
        PG = this;
    }


    public void EnemyGeneratorForSingleTrouble(int level,float positionX)
    {
        Vector3 initialPos = new Vector3(positionX, 0f, 46f);
        GameObject initialPlatform = Instantiate(platform);
        initialPlatform.transform.position = initialPos;

        int randomMaxLimit;
        float distanceBetweenEnemyGeneration = 35f;

        if(level < 5)
        {
            randomMaxLimit = 3;
        }
        else
        {
            randomMaxLimit = enemies.Length;
        }
        for(int i = 0; i<level; i++)
        {
            int random = Random.Range(0, randomMaxLimit);
            GameObject enemy = Instantiate(enemies[random]);
            Vector3 pos = new Vector3(positionX, enemy.transform.position.y, distanceBetweenEnemyGeneration);
            enemy.transform.position = pos;
            distanceBetweenEnemyGeneration = distanceBetweenEnemyGeneration + 70f;

            Vector3 pPos = new Vector3(positionX, 0f, platfromGenerationPoint);
            GameObject p = Instantiate(platform);
            p.transform.position = pPos;
            platfromGenerationPoint = platfromGenerationPoint + 100f;
            
        }

        GameObject finish = Instantiate(finishZone);
        Vector3 position = new Vector3(positionX, 1.32f, distanceBetweenEnemyGeneration);
        finish.transform.position = position;

        platfromGenerationPoint = 146f;

    }

    public void EnemyGenerationForDoubleTrouble(int level,float rightPosition,float leftPosition)
    {
        Vector3 initialLeftPlatformPos = new Vector3(leftPosition, 0f, 46f);
        GameObject initialLeftPlatform = Instantiate(platform);
        initialLeftPlatform.transform.position = initialLeftPlatformPos;

        

        Vector3 initialRightPlatformPos = new Vector3(rightPosition, 0f, 46f);
        GameObject initialRightPlatform = Instantiate(platform);
        initialRightPlatform.transform.position = initialRightPlatformPos;

        int randomMaxLeftLimit;
        int randomMaxRightLimit;
        float distanceBetweenLeftEnemyGeneration = 35f;
        float distanceBetweenRightEnemyGeneration = 30f;

        if (level < 5)
        {
            randomMaxLeftLimit = 3;
            randomMaxRightLimit = 4;
        }
        else
        {
            randomMaxLeftLimit = enemies.Length;
            randomMaxRightLimit = enemies.Length;
        }

        for (int i = 0; i < level; i++)
        {
            int randomLeft = Random.Range(0, randomMaxLeftLimit);
            int randomRight = Random.Range(0, randomMaxRightLimit);

            GameObject leftEnemy = Instantiate(enemies[randomLeft]);
            Vector3 leftPos = new Vector3(leftPosition, leftEnemy.transform.position.y, distanceBetweenLeftEnemyGeneration);
            leftEnemy.transform.position = leftPos;
            distanceBetweenLeftEnemyGeneration = distanceBetweenLeftEnemyGeneration + 70f;

            GameObject rightEnemy = Instantiate(enemies[randomRight]);
            Vector3 rightPos = new Vector3(rightPosition, rightEnemy.transform.position.y, distanceBetweenRightEnemyGeneration);
            rightEnemy.transform.position = rightPos;
            distanceBetweenRightEnemyGeneration = distanceBetweenRightEnemyGeneration + 60f;

            Vector3 leftPlatformPos = new Vector3(leftPosition, 0f, platfromGenerationPoint);
            GameObject leftPlatform = Instantiate(platform);
            leftPlatform.transform.position = leftPlatformPos;

            Vector3 rightPlatformPos = new Vector3(rightPosition, 0f, platfromGenerationPoint);
            GameObject rightPlatform = Instantiate(platform);
            rightPlatform.transform.position = rightPlatformPos;

            platfromGenerationPoint = platfromGenerationPoint + 100f;

        }

        GameObject finish = Instantiate(finishZone);
        Vector3 position = new Vector3(-1f, 1.32f, distanceBetweenLeftEnemyGeneration);
        finish.transform.position = position;

        platfromGenerationPoint = 146f;


    }

    public void EnemyGenerationForSingleInfiniteTrouble(float platfromPosition,float enemyPosition,float positionX)
    {

        Vector3 initialPlatfromPos = new Vector3(positionX, 0f, 46f);
        GameObject initialPlatform = Instantiate(platform);
        initialPlatform.transform.position = initialPlatfromPos;


        for (int i = 1; i <= 10; i++)
        {
            int random = Random.Range(0, enemies.Length);
            GameObject enemy = Instantiate(enemies[random]);
            Vector3 pos = new Vector3(positionX, enemy.transform.position.y, enemyPosition);
            enemy.transform.position = pos;
            enemyPosition = enemyPosition + 70f;

            Vector3 pPos = new Vector3(positionX, 0f, platfromPosition);
            GameObject p = Instantiate(platform);
            p.transform.position = pPos;
            platfromPosition = platfromPosition + 100f;

            if(i == 8)
            {
                GameObject nextReswapningZone = Instantiate(nextReswapningTrigger);
                Vector3 position = new Vector3(positionX, 1.32f, enemyPosition);
                nextReswapningZone.transform.position = position;
            }

        }

        nextPlatformGenerationPosition = platfromPosition;
        nextEnemyGenerationPosition = enemyPosition;
    }

}
