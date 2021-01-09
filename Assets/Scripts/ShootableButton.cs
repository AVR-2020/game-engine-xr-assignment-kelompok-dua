using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableButton : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject gameOver;

    public GameObject healthObj;
    public GameObject scoreObj;
    public int buttonType;

    public int getButtonType(){
        return buttonType;
    }

    public void hitStart()
    {
        mainMenu.SetActive(false);
        Health.health = 3;
        healthObj.GetComponent<Health>().DisplayHealth(Health.health);
        healthObj.SetActive(true);
        Score.score = 0;
        scoreObj.GetComponent<Score>().DisplayScore(Score.score);
        scoreObj.SetActive(true);

        // Start Spawn
        UFOSpawn.isStarted = true;

    }

    public void hitQuit()
    {
        Debug.Log("Quitting Application");
        Application.Quit();

    }

    public void hitRetry()
    {
        gameOver.SetActive(false);
        Health.health = 3;
        healthObj.GetComponent<Health>().DisplayHealth(Health.health);
        healthObj.SetActive(true);
        Score.score = 0;
        scoreObj.GetComponent<Score>().DisplayScore(Score.score);
        scoreObj.SetActive(true);

        // Start Spawn
        UFOSpawn.isFinished = false;
        UFOSpawn.isStarted = true;

    }

    public void hitMenu()
    {
        gameOver.SetActive(false);
        mainMenu.SetActive(true);
        Health.health = 3;
        healthObj.GetComponent<Health>().DisplayHealth(Health.health);
        Score.score = 0;
        scoreObj.GetComponent<Score>().DisplayScore(Score.score);

        // Start Spawn
        UFOSpawn.isFinished = false;
        UFOSpawn.isStarted = false;
    }
}
