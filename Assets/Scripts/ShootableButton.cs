using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableButton : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject gameOver;

    public GameObject healthObj;
    public GameObject scoreObj;
    public GameObject bulletNumberObj;
    public GameObject gunObj;
    public int buttonType;

    public GameObject bgmStart;

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

        RaycastShoot.numberOfBullet = 10;
        gunObj.GetComponent<RaycastShoot>().DisplayBullet();
        bulletNumberObj.SetActive(true);

        // BGM Start
        bgmStart.GetComponent<AudioSource>().Play();

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
        
        // BGM Start
        bgmStart.GetComponent<AudioSource>().Play();

        Health.health = 3;
        healthObj.GetComponent<Health>().DisplayHealth(Health.health);
        healthObj.SetActive(true);
        
        Score.score = 0;
        scoreObj.GetComponent<Score>().DisplayScore(Score.score);
        scoreObj.SetActive(true);
        
        RaycastShoot.numberOfBullet = 10;
        gunObj.GetComponent<RaycastShoot>().DisplayBullet();
        bulletNumberObj.SetActive(true);

        // Start Spawn
        UFOSpawn.isFinished = false;
        UFOSpawn.isStarted = true;

    }

    public void hitMenu()
    {
        gameOver.SetActive(false);
        mainMenu.SetActive(true);

        // Start Spawn
        UFOSpawn.isFinished = false;
        UFOSpawn.isStarted = false;
    }
}
