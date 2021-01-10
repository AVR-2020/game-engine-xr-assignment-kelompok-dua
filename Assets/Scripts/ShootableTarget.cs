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
    private int rewardPoints;

    private GameObject UFODestroyed;

    void Start()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
        typeUFO = Random.Range(1, 10);
        var matcolor = gameObject.GetComponent<Renderer>();
        if (typeUFO >= 1 && typeUFO <= 6) // Normal UFO (60%)
        {
            currentHealth = 3 * Score.levelUp;
            rewardPoints = 1;
            MoveSpeed = 0.03f;
            matcolor.material.color = Color.yellow;
        }
        else if (typeUFO == 7) // Tanky UFO (10%)
        {
            currentHealth = 5 * Score.levelUp;
            rewardPoints = 3;
            MoveSpeed = 0.01f;
            matcolor.material.color = Color.blue;
        }
        else if (typeUFO >= 8 && typeUFO <= 10) // Speedy UFO (30%)
        {
            currentHealth = 1 * Score.levelUp;
            rewardPoints = 2;
            MoveSpeed = 0.05f;
            matcolor.material.color = Color.red;
        }
    }

    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            GameObject scoreObj = GameObject.Find("Score");
            scoreObj.GetComponent<Score>().AddScore(rewardPoints);
            
            UFODestroyed = GameObject.Find("UFODestroyed");
            UFODestroyed.GetComponent<AudioSource>().Play();

            Destroy(gameObject);
        }
    }

    void Update()
    {
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = new Vector3(player.transform.position.x, player.transform.position.y + 1.0f, player.transform.position.z);

        transform.position = Vector3.MoveTowards(currentPosition, targetPosition, MoveSpeed);
        transform.Rotate(0, 0, 90 * Time.deltaTime);
        //transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        if (UFOSpawn.isFinished){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player")){
            GameObject healthObj = GameObject.Find("Health");
            healthObj.GetComponent<Health>().ReduceHealth(1);
            Destroy(gameObject);
        }
    }
}
