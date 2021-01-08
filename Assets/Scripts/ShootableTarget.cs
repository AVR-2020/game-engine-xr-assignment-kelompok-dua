using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableTarget : MonoBehaviour
{
    public int currentHealth = 1;

    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
