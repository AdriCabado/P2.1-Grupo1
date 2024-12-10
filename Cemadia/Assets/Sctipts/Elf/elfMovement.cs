using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elfMovement : MonoBehaviour
{
    
    //[SerializeField] private Animator animator;
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
            
            if(collider.CompareTag("Enemy")){
                GameObject.Find("tree5").GetComponent<SpriteRenderer>().color=Color.white;
                GameObject.Find("idle_1").GetComponent<SpriteRenderer>().color=Color.white;
                Destroy(collider.gameObject);
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
