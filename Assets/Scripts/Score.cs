using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Score : MonoBehaviour
{
    public GameObject scoreText;
    public static int score = 0;

    private void Start()
    {
        AddScore(0);
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.GetComponent<Text>().text = "Score: " + score.ToString();
    }
}
