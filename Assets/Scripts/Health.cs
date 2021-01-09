using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Health : MonoBehaviour
{
    public GameObject healthText;
    public static int health = 3;

    private void Start()
    {
        ReduceHealth(0);
    }

    public void ReduceHealth(int healthToReduce)
    {
        health -= healthToReduce;
        if (health <= 0){
            // Game Over Logic Implement disini
            Debug.Log("Game Over");
            health = 0;
        }
        healthText.GetComponent<Text>().text = "Nyawa: " + health.ToString();
    }
}
