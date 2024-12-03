using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab1; // Enemigo que spawnea desde un solo punto
    public GameObject enemyPrefab2; // Enemigo que spawnea desde dos puntos
    public Transform spawnPoint1; // Punto de spawn para el primer enemigo
    public Transform spawnPoint2A; // Primer punto de spawn para el segundo enemigo
    public Transform spawnPoint2B; // Segundo punto de spawn para el segundo enemigo

    public float spawnInterval = 2f; // Intervalo entre cada spawn (en segundos)

    void Start() {
        InvokeRepeating("SpawnEnemies", 0f, spawnInterval);
    }
        


    void SpawnEnemies()
    {
        if(Random.value<0.2){
        // Spawnear el primer enemigo desde un solo punto
        Instantiate(enemyPrefab1, spawnPoint1.position, Quaternion.identity);
        }
        

        // Determinar aleatoriamente desde qué punto spawnear el segundo enemigo
        Transform randomSpawnPoint = (Random.value > 0.5f) ? spawnPoint2A : spawnPoint2B;

        // Spawnear el segundo enemigo desde uno de los dos puntos
        Instantiate(enemyPrefab2, randomSpawnPoint.position, Quaternion.identity);
    }
}