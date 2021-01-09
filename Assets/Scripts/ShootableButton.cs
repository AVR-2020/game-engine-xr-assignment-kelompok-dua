using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableButton : MonoBehaviour
{
    public int currentHealth = 1;
    public GameObject mainMenu;
    public GameObject scoreUI;
    public GameObject healthUI;

    public void DamageStart(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            mainMenu.SetActive(false);
            scoreUI.SetActive(true);
            healthUI.SetActive(true);

            // Start Spawn
            UFOSpawn.isStarted = true;

        }
    }
}
