using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaScript : MonoBehaviour
{
   void Update(){
    if(transform.position.x>=9.5){
        Destroy(gameObject);
    }
   }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("golpe flecha");
            GameObject.Find("idle_1").GetComponent<SpriteRenderer>().color=Color.white;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
       
    }
    
}
