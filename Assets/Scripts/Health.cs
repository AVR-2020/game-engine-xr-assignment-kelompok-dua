using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    public GameObject healthText;
    public GameObject gameOverObj;
    public static int health = 3;

    private void Start()
    {
        DisplayHealth(3);
    }

    public void ReduceHealth(int healthToReduce)
    {
        health -= healthToReduce;
        if (health <= 0){
            // Game Over Logic Implement disini
            Debug.Log("Game Over");
            health = 0;
            UFOSpawn.isFinished = true;
            gameOverObj.SetActive(true);
            GameObject scoreFinalObj = GameObject.Find("ScoreFinal");
            scoreFinalObj.GetComponent<TextMeshPro>().text = "Skor: " + Score.score.ToString();
            GameObject scoreObj = GameObject.Find("Score");
            scoreObj.SetActive(false);
            GameObject healthObj = GameObject.Find("Health");
            healthObj.SetActive(false);
            GameObject bulletNumberObj = GameObject.Find("Bulletnumber");
            bulletNumberObj.SetActive(false);
        }
       DisplayHealth(health);
    }

    public void DisplayHealth(int healthToDisplay)
    {
        healthText.GetComponent<TextMeshProUGUI>().text = "Nyawa: " + healthToDisplay.ToString();
    }
}
