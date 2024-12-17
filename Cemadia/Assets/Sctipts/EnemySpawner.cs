using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject gameOver;
    private int score=0;
    [SerializeField] Text text;
    public GameObject enemyPrefab1; // Enemigo que spawnea desde un solo punto
    public GameObject enemySign1;
    public GameObject enemyPrefab2; // Enemigo que spawnea desde dos puntos
    public Transform spawnPoint1; // Punto de spawn para el primer enemigo
    public Transform spawnPoint2A; // Primer punto de spawn para el segundo enemigo
    public Transform spawnPoint2B; // Segundo punto de spawn para el segundo enemigo
    public Transform enemy1ArrowPoint;
    [SerializeField] private GameObject fire;
    public GameObject[] lifeBoard;
    private int spareLives=3;
    public float spawnInterval = 2f; // Intervalo entre cada spawn (en segundos)

    void Start() {
        InvokeRepeating("SpawnEnemies", 0f, spawnInterval);
    }


    public void addScore(int points)
    {
        score+=points;
        text.text=score.ToString("D6");
    }
    public void lifeLost(){
        spareLives--;

        //Comprobamos si spareLives es menor que 0
        //por si se da el caso raro de que dos fantasmas llamen en el mismo 
        //frame a esta función y spareLives es 1
        if(spareLives <= 0) {
            if(spareLives==0){
                lifeBoard[spareLives].SetActive(false);
            }else{
                SceneManager.LoadScene("MenuInicio");
            }
            gameOver.SetActive(true);
            GameObject.Find("idle_1").GetComponent<Animator>().Play("Death");
            fire.SetActive(true);
            Debug.Log("Perdichessssss");
        }else{
            lifeBoard[spareLives].SetActive(false);
        }
    }

    void SpawnEnemies()
    {
        if(Random.value<0.3){
        // Spawnear el primer enemigo desde un solo punto
        Instantiate(enemyPrefab1, spawnPoint1.position, Quaternion.identity);
        GameObject gb= Instantiate(enemySign1, enemy1ArrowPoint.position, Quaternion.identity);
        Destroy(gb, 4f);
        }
        

        // Determinar aleatoriamente desde qué punto spawnear el segundo enemigo
        Transform randomSpawnPoint = (Random.value > 0.5f) ? spawnPoint2A : spawnPoint2B;

        // Spawnear el segundo enemigo desde uno de los dos puntos
        Instantiate(enemyPrefab2, randomSpawnPoint.position, Quaternion.identity);
    }
}