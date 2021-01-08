using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class UFOSpawn : MonoBehaviour
{
    public GameObject ufo;
    public GameObject player = null;
    private float spawnRate = 5.0f;

    //public int speed = 1;

    // Start is called before the first frame update
    void Start()
    {       
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");

        InvokeRepeating("SpawnUFO", 3.0f, spawnRate);
    }

    void SpawnUFO()
    {
        Debug.Log("Spawn Rate: " + spawnRate);
        
        GameObject tmp = Instantiate(ufo);
        tmp.transform.position = SpawnRadius();

        //try to only enable scripts for clone
        tmp.AddComponent<ShootableTarget>();
        //tmp.gameObject.addComponent< ShootableTarget >(); 

        if (spawnRate > 1.0f) spawnRate -= 0.1f;
    }

    Vector3 SpawnRadius()
    {
        //Determine the spawn position (outside radius of player, but not too far)
        float minDistance = 10.0f;
        float maxDistance = 20.0f;
        float distance = Random.Range(minDistance, maxDistance);
        float angle = Random.Range(-Mathf.PI, Mathf.PI);

        Vector3 spawnPosition = player.transform.position;
        spawnPosition += new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * distance;
        spawnPosition.x = Mathf.Clamp(spawnPosition.x, -maxDistance, maxDistance);
        spawnPosition.y = Random.Range(2.0f, 7.0f);
        spawnPosition.z = Mathf.Clamp(spawnPosition.z, -maxDistance, maxDistance);

        return new Vector3(spawnPosition.x, spawnPosition.y, spawnPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(player.transform);

        //transform.position += transform.forward * MoveSpeed * Time.deltaTime;
    }
}