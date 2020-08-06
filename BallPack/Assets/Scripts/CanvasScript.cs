using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{

    public static CanvasScript canvasScript; 
    public Text levelNo;
    public GameObject levelNoPanel;

    public GameObject restartPanel;
    public GameObject levelCompletePanel;
    void Start()
    {
        canvasScript = this;
        int level = PlayerPrefs.GetInt("LevelNumber");
        levelNo.text = "Level " + level.ToString();

        restartPanel.SetActive(false);
        levelCompletePanel.SetActive(false);

    }

    public void DisableLevelNoText()
    {
        levelNoPanel.SetActive(false);
    }

    public void ShowRestartPanel()
    {
        StartCoroutine("RestartWait");
        
    }

    IEnumerator RestartWait()
    {
        yield return new WaitForSeconds(1);
        restartPanel.SetActive(true);

    }

    public void Restart()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void ShowLevelCompletePanel()
    {
        if(levelCompletePanel.activeSelf == false)
        {
            int levelNumber = PlayerPrefs.GetInt("LevelNumber");
            levelNumber++;
            PlayerPrefs.SetInt("LevelNumber", levelNumber);
        }
        restartPanel.SetActive(false);
        levelCompletePanel.SetActive(true);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
