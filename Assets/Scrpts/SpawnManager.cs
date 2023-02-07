using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    private float spawnRange = 9f;

    public int enemiesInScene;
    public int enemiesPerWave = 1;
    public GameObject powerupPrefab;
    public GameObject ultraPowerupPrefab;

    private void Start()
    {
        SpawnEnemyWave(enemiesPerWave);  // El numero de entre los parentesis indica cuantos enemigos se crearan
        Instantiate(powerupPrefab, RandomSpawnPosition(), Quaternion.identity);
        Instantiate(ultraPowerupPrefab, RandomSpawnPosition(), Quaternion.identity);
    }

    private Vector3 RandomSpawnPosition()
    {
        float randX = Random.Range(-spawnRange, spawnRange);
        float randZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(randX, 0, randZ);
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, RandomSpawnPosition(), Quaternion.identity);
        }
    }

    private void Update()
    {
        enemiesInScene = FindObjectsOfType<Enemy>().Length;
        
        if(enemiesInScene <= 0)
        {
            enemiesPerWave++;
            SpawnEnemyWave(enemiesPerWave);
            Instantiate(powerupPrefab, RandomSpawnPosition(), Quaternion.identity);
            Instantiate(ultraPowerupPrefab, RandomSpawnPosition(), Quaternion.identity);
        }

    }
}
