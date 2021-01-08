using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShootableTarget : MonoBehaviour
{
    public int currentHealth = 1;
    public int typeUFO;

    public float MoveSpeed = 1.0f;
    public GameObject player = null;

    void Start()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
        typeUFO = Random.Range(1, 10);
        var matcolor = gameObject.GetComponent<Renderer>();
        if (typeUFO >= 1 && typeUFO <= 6) // Normal UFO (60%)
        {
            currentHealth = 3;
            MoveSpeed = 0.03f;
            matcolor.material.color = Color.yellow;
        }
        else if (typeUFO >= 7 && typeUFO <= 8) // Tanky UFO (20%)
        {
            currentHealth = 5;
            MoveSpeed = 0.01f;
            matcolor.material.color = Color.blue;
        }
        else if (typeUFO >= 9 && typeUFO <= 10) // Speedy UFO (20%)
        {
            currentHealth = 1;
            MoveSpeed = 0.05f;
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

    void Update()
    {
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = new Vector3(player.transform.position.x, player.transform.position.y + 1.0f, player.transform.position.z);

        transform.position = Vector3.MoveTowards(currentPosition, targetPosition, MoveSpeed);
        //transform.position += transform.forward * MoveSpeed * Time.deltaTime;
    }
}
