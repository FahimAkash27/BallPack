using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManazer : MonoBehaviour
{

    public GameObject GameStartPanel;
    public GameObject levelStartPanel;
    public GameObject CongoPanel;
    public GameObject background;

    public Text levelNumberText;

    public GameObject singleInfiniteScore;


    int singleTroubleLevel;
    int doubleTroubleLevel;
    public int gameMode;

    public GameObject singlePlayer;
    public GameObject rightPlayer;


    public static GameManazer GM;

    private void Awake()
    {
        GM = this;
    }

    public void SingleInfiniteTrouble()
    {
        gameMode = 3;
        PlayerPrefs.SetInt("GameMode", gameMode);
        levelStartPanel.SetActive(false);
        GameStartPanel.SetActive(false);
        singlePlayer.SetActive(false);
        background.SetActive(false);
        CongoPanel.SetActive(false);
        singleInfiniteScore.SetActive(true);

        LevelStart();
    }

    public void DoubleTrouble()
    {
        gameMode = 2;
        PlayerPrefs.SetInt("GameMode", gameMode);

        levelStartPanel.SetActive(true);
        GameStartPanel.SetActive(false);
        singlePlayer.SetActive(false);
        background.SetActive(false);
        CongoPanel.SetActive(false);

        rightPlayer.SetActive(false);
        SetDoubleTroubleLevelNoOnPanel();

    }

    public void SingleTrouble()
    {
        
        gameMode = 1;
        PlayerPrefs.SetInt("GameMode", gameMode);

        levelStartPanel.SetActive(true);
        GameStartPanel.SetActive(false);
        singlePlayer.SetActive(false);
        //singlePlatform.SetActive(false);
        background.SetActive(false);
        CongoPanel.SetActive(false);
        SetSingleTroubleLevelNoOnPanel();
    }
    public void SetSingleTroubleLevelNoOnPanel()
    {
        if (PlayerPrefs.HasKey("SingleTroubleLevel"))
        {
            singleTroubleLevel = PlayerPrefs.GetInt("SingleTroubleLevel");
        }
        else
        {
            singleTroubleLevel = 1;
            PlayerPrefs.SetInt("SingleTroubleLevel", singleTroubleLevel);
        }
        levelNumberText.text = "Level " + singleTroubleLevel.ToString();
    }

    public void SetDoubleTroubleLevelNoOnPanel()
    {
        if (PlayerPrefs.HasKey("DoubleTroubleLevel"))
        {
            doubleTroubleLevel = PlayerPrefs.GetInt("DoubleTroubleLevel");
        }
        else
        {
            doubleTroubleLevel = 1;
            PlayerPrefs.SetInt("DoubleTroubleLevel", doubleTroubleLevel);
        }
        levelNumberText.text = "Level " + doubleTroubleLevel.ToString();
    }

    public void LevelStart()
    {

        if(gameMode == 1)
        {
            levelStartPanel.SetActive(false);
            background.SetActive(true);

            Vector3 playerPosition = new Vector3(0f, 0.925f, 3f);
            singlePlayer.transform.position = playerPosition;

            background.transform.position = Vector3.zero;
            singlePlayer.SetActive(true);
            background.SetActive(true);

            float position = 0f;

            PlatfromGenerator.PG.EnemyGeneratorForSingleTrouble(singleTroubleLevel, position);
        }else if(gameMode == 2)
        {
            levelStartPanel.SetActive(false);
            background.SetActive(true);

            Vector3 leftPlayerPosition = new Vector3(-2f, 0.925f, 3f);
            singlePlayer.transform.position = leftPlayerPosition;

            Vector3 rightPlayerPosition = new Vector3(0.0f, 0.925f, 3f);
            rightPlayer.transform.position = rightPlayerPosition;

            background.transform.position = Vector3.zero;

            singlePlayer.SetActive(true);
            rightPlayer.SetActive(true);
            background.SetActive(true);

            float leftPosition = -2f;
            float rightPosition = 0f;

            PlatfromGenerator.PG.EnemyGenerationForDoubleTrouble(doubleTroubleLevel, rightPosition, leftPosition);

        }else if(gameMode == 3)
        {
            background.SetActive(true);

            Vector3 playerPosition = new Vector3(0f, 0.925f, 3f);
            singlePlayer.transform.position = playerPosition;

            background.transform.position = Vector3.zero;
            singlePlayer.SetActive(true);
            background.SetActive(true);

            float Playerposition = 0f;
            float platformPosition = 146f;
            float enemyPosition = 35f;

            PlatfromGenerator.PG.EnemyGenerationForSingleInfiniteTrouble(platformPosition, enemyPosition, Playerposition);
        }

        

    }
}
