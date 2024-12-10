using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class elfMovement : MonoBehaviour
{
    
    //[SerializeField] private Animator animator;
    [SerializeField] GameObject enemySpawner;
    [SerializeField] private float radioAttackMelee;
    [SerializeField] private float radioAttackArrow;
    [SerializeField] private Transform meleeController;

    [SerializeField] private Transform arrowController;
    
    public void ArrowAttack(){
        Collider2D[] objetos=Physics2D.OverlapCircleAll(arrowController.position, radioAttackArrow);
        HitAttack(objetos);
    }
    public void SwordAttack(){
        Collider2D[] objetos=Physics2D.OverlapCircleAll(meleeController.position, radioAttackMelee);
        meleeController.gameObject.GetComponent<meleeScript>().MoverHitPoint();
        HitAttack(objetos);
    }
    private void HitAttack(Collider2D[] objetos){
        foreach(Collider2D collider in objetos){
            Debug.Log("asdfas");
            if(collider.CompareTag("Enemy")){
                GameObject.Find("idle_1").GetComponent<SpriteRenderer>().color=Color.white;
                enemySpawner.GetComponent<EnemySpawner>().addScore(150);
                Destroy(collider.gameObject);
                Debug.Log("Muerto");
            }
        }
    }
    private void OnDrawGizmos() {
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(meleeController.position, radioAttackMelee);
        Gizmos.color=Color.blue;
        Gizmos.DrawWireSphere(arrowController.position, radioAttackArrow);
    }
    

}
