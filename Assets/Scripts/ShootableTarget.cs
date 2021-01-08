using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShootableTarget : MonoBehaviour
{
    public int currentHealth = 1;
    public int typeUFO;
    void Start()
    {
        typeUFO = Random.Range(1, 10);
        var matcolor = gameObject.GetComponent<Renderer>();
        if (typeUFO >= 1 && typeUFO <= 6) // Normal UFO (60%)
        {
            currentHealth = 3;
            matcolor.material.color = Color.yellow;
        }
        else if (typeUFO >= 7 && typeUFO <= 8) // Tanky UFO (20%)
        {
            currentHealth = 5;
            matcolor.material.color = Color.blue;
        }
        else if (typeUFO >= 9 && typeUFO <= 10) // Speedy UFO (20%)
        {
            currentHealth = 1;
            matcolor.material.color = Color.red;
        }
    }

    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
