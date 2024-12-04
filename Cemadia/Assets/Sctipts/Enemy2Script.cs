using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy2Script : MonoBehaviour
{
    public GameObject daggerPrefac; // El prefab de la daga
    public Transform daggerSpawnPoint; // Punto de salida de la daga
    public float daggerSpeed = 10f; // Velocidad de la daga
    public float velocidad = 5f; // Velocidad de movimiento
    public float moveLimit; // Límite máximo para moverse a la izquierda
    private SpriteRenderer spriteRendererElf;
    [SerializeField]private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        spriteRendererElf=GameObject.Find("idle_1").GameObject().GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
         if (transform.position.x <= moveLimit){
            animator.Play("Attack");
         }else{
            transform.Translate(Vector3.left * velocidad * Time.deltaTime);
        }
    }
    private void DaggerAttack(){
        GameObject arrow = Instantiate(daggerPrefac, daggerSpawnPoint.position, daggerSpawnPoint.rotation);
        
        // Aplicar movimiento a la flecha
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = -daggerSpawnPoint.right * daggerSpeed; 
        }
    }
}
