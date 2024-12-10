using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
   public float velocidad = 5f; // Velocidad de movimiento
    public float limiteElf; // Límite máximo para moverse a la izquierda
    public float limiteTree;
    [SerializeField] GameObject tree;
    public Animator animator;
    private SpriteRenderer spriteRendererElf;
    private SpriteRenderer spriteRendererTree;
    private bool treeAttack;

    private GameObject enemySpawner;
    private void Start() {
        spriteRendererElf=GameObject.Find("idle_1").GameObject().GetComponent<SpriteRenderer>();
        spriteRendererTree=GameObject.Find("tree5").GameObject().GetComponent<SpriteRenderer>();
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
        // Verifica si ha llegado al límite izquierdo, si es así ataca
        if (transform.position.x <= limiteElf && !treeAttack){
            animator.Play("Attackanim");
        }else if(transform.position.x <= limiteTree && treeAttack){
            animator.Play("Attackanim");
        }else{
            transform.Translate(Vector3.left * velocidad * Time.deltaTime);
        }
        
    }
    public void Damage(){
        if(treeAttack){
            spriteRendererTree.color=Color.red;
        }else{
            spriteRendererElf.color=Color.red;
            enemySpawner.GetComponent<EnemySpawner>().lifeLost();
        }
        
        
    }
    public void DamageFinish(){
        if(treeAttack){
            spriteRendererTree.color=Color.white;
        }else{
            spriteRendererElf.color=Color.white;
        }
    }
}
