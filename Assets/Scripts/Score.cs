using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Score : MonoBehaviour
{
    public GameObject scoreText;
    public static int score = 0;
    public static float spawnRate = 5.0f;
    public static int levelUp = 1;
    private int count;

    private void Start()
    {
        AddScore(0);
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        if(score > 0) count++;
        Debug.Log("UFO: " + count);
        if(count % 5 == 0 && spawnRate >= 1.5f && score > 0)
        {
            Debug.Log("Faster!");
            spawnRate -= 0.3f;
        }
        if(count % 20 == 0 && levelUp <= 2 && score > 0)
        {
            levelUp++;
            Debug.Log("Level UP!");
        }
        scoreText.GetComponent<Text>().text = "Score: " + score.ToString();
    }
}
