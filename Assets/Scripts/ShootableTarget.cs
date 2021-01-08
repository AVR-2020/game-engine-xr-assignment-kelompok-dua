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
        if (typeUFO >= 1 && typeUFO <= 6)
            currentHealth = 3;
        else if (typeUFO >= 7 && typeUFO <= 8)
            currentHealth = 5;
        else if (typeUFO >= 9 && typeUFO <= 10)
            currentHealth = 1;
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
