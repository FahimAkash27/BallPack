using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCanvasScript : MonoBehaviour
{

    public void GameStart()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
