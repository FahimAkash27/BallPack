using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleInfiniteScore : MonoBehaviour
{
    public Text singleInfiniteScoreText;
    float score;
    float pointIncreasePerSecond;

    void Start()
    {
        score = 0f;
        pointIncreasePerSecond = 1f;
    }

    void Update()
    {
        score += pointIncreasePerSecond * Time.deltaTime;
        singleInfiniteScoreText.text = score.ToString();
    }
}
