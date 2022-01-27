using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject camera;
    public float spawnRange;
    public int toSpawn;


    // Start is called before the first frame update
    void Start()
    {
        DynamicSpawn(toSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void DynamicSpawn(int toSpawn)
    {
        for (int i = 0; i < toSpawn; i++)
            SpawnEnemy();
    }
    void SpawnEnemy()
    {
        GameObject spawnedObject = Instantiate(enemyPrefab, SpawnPosition(), Quaternion.identity);
        camera.GetComponent<CameraController>().target.Add(spawnedObject.transform);
    }

    Vector3 SpawnPosition()
    {
        float spawnX = Random.Range(-spawnRange, spawnRange);
        float spawnZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(spawnX, 0.5f, spawnZ);
    }
}
