using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    //Si salió volando ya no puede seguir atacando
    public bool volando=false;
   public float velocidad = 5f; // Velocidad de movimiento
    public float limiteElf; // Límite máximo para moverse a la izquierda
    public float limiteTree;
    public Animator animator;
    private SpriteRenderer spriteRendererElf;
    private bool treeAttack;
    private GameObject tree;
    private GameObject enemySpawner;
    private void Start() {
        spriteRendererElf=GameObject.Find("idle_1").GameObject().GetComponent<SpriteRenderer>();
        tree=GameObject.Find("Final Tree");
        enemySpawner=GameObject.Find("EnemySpawner");
        //Comprobando si el ataque va para el arbol o el elfo dependiendo de la altura
        if(transform.position.y>=-2){
            treeAttack=true;
        }else{
            treeAttack=false;
        }
    }
    void Update()
    {
        if(transform.position.y <= -10){
            Destroy(gameObject);
        }
        if(volando){
            animator.Play("EnemyAnimation");
        }
        // Verifica si ha llegado al límite izquierdo, si es así ataca
        if (transform.position.x <= limiteElf && !treeAttack && !volando){
            animator.Play("Attackanim");
        }else if(transform.position.x <= limiteTree && treeAttack && !volando){
            animator.Play("Attackanim");
        }else{
            transform.Translate(Vector3.left * velocidad * Time.deltaTime);
        }
        
    }
    public void Damage(){
        if(treeAttack){
            tree.GetComponent<TreeSctipt>().HitTree();
        }else{
            spriteRendererElf.color=Color.red;
            enemySpawner.GetComponent<EnemySpawner>().lifeLost();
        }
        
        
    }
    public void DamageFinish(){
        if(treeAttack){
            
        }else{
            spriteRendererElf.color=Color.white;
        }
    }
}
