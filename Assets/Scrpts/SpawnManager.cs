using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject[] powerupPrefabs;
    
    private int enemiesInScene;
    private float spawnRange = 9f;  // Límite de la plataforma
    private int enemiesPerWave = 1;

    private void Start()
    {
        SpawnEnemyWave(enemiesPerWave);  // El numero de entre los parentesis indica cuantos enemigos se crearán
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

        int randomIndex = Random.Range(0, powerupPrefabs.Length);
        Instantiate(powerupPrefabs[randomIndex], RandomSpawnPosition(), Quaternion.identity);
    }

    private void Update()
    {
        // Buscamos la cantidad de enemigos que hay por escena
        enemiesInScene = FindObjectsOfType<Enemy>().Length;
        
        if(enemiesInScene <= 0)
        {
            // Si me quedo sin enemigos en escena aunemto en uno los enemigos por oleada
            enemiesPerWave++;
            // Llamo a una nueva oleada
            SpawnEnemyWave(enemiesPerWave);
        }

    }
}
