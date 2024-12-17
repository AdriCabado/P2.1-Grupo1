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
                other.GetComponent<Enemy2Script>().volando=true;
            }else{
                other.GetComponent<EnemyMove>().volando=true;
            }
            enemySpawner.GetComponent<EnemySpawner>().addScore(150);
            Debug.Log("golpe flecha");
            GameObject.Find("idle_1").GetComponent<SpriteRenderer>().color=Color.white;
            
            Rigidbody2D rb=other.GetComponent<Rigidbody2D>();
            rb.constraints =RigidbodyConstraints2D.None;
            Vector2 impactDirection = new Vector2(0.6f, 0.5f);
            rb.AddForce(impactDirection.normalized * 10f, ForceMode2D.Impulse); 
            rb.AddTorque(19, ForceMode2D.Impulse);
            Destroy(gameObject);
        }
       
    }
    
}
