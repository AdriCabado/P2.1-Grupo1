using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaScript : MonoBehaviour
{
    private GameObject enemySpawner;
    private void Start() {
        enemySpawner=GameObject.Find("EnemySpawner");
    }
    void Update(){
        if(transform.position.x>=9.5){
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy"))
        {
            if(other.name.Equals("Enemy2(Clone)")){
                enemySpawner.GetComponent<EnemySpawner>().addScore(150);
            }
            enemySpawner.GetComponent<EnemySpawner>().addScore(150);
            Debug.Log("golpe flecha");
            GameObject.Find("idle_1").GetComponent<SpriteRenderer>().color=Color.white;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
       
    }
    
}
