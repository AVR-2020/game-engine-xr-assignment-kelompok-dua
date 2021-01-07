using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class UFOSpawn : MonoBehaviour
{
    public GameObject ufo;
    public GameObject player = null;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");

        InvokeRepeating("SpawnUFO", 3.0f, 0.1f);
    }

    void SpawnUFO()
    {
        GameObject tmp = Instantiate(ufo);
        tmp.transform.position = SpawnRadius();
    }

    //Vector3 GetRandomPoint()
    //{
    //    int xRandom = 0;
    //    int zRandom = 0;


    //    xRandom = (int)Random.Range(col.bounds.min.x, col.bounds.max.x);
    //    zRandom = (int)Random.Range(col.bounds.min.z, col.bounds.max.z);

    //    return new Vector3(xRandom, 0.0f, zRandom);
    //}

    Vector3 SpawnRadius()
    {
        //Vector3 offset = Random.OnUnitSphere * Random.Range(5, 10);
        float minDistance = 10.0f;
        float maxDistance = 20.0f;
        float distance = Random.Range(minDistance, maxDistance);
        float angle = Random.Range(-Mathf.PI, Mathf.PI);

        Vector3 spawnPosition = player.transform.position;
        spawnPosition += new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * distance;
        spawnPosition.x = Mathf.Clamp(spawnPosition.x, -maxDistance, maxDistance);
        spawnPosition.y = Random.Range(2.0f, 10.0f);
        spawnPosition.z = Mathf.Clamp(spawnPosition.z, -maxDistance, maxDistance);

        return new Vector3(spawnPosition.x, spawnPosition.y, spawnPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
