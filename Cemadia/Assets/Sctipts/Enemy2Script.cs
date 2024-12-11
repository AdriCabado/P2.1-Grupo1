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
    private bool firstAttack=true;//Es para que no quede enabled la primera vez que se hace porquue si no se traba
    //Si salió volando ya no puede seguir atacando
    public bool volando=false;
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
        if(transform.position.y <= -10){
            Destroy(gameObject);
        }
         if (transform.position.x <= moveLimit){
            StartCoroutine(FirstAttack(0f));
            
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

    public void PauseAnimation()
    {
        if(!firstAttack){
            StartCoroutine(PauseRoutine(1f));
        }
        firstAttack=false;
    }
    private IEnumerator FirstAttack(float pauseTime){
        yield return new WaitForSeconds(pauseTime);
        animator.Play("Attack");
    }
    private IEnumerator PauseRoutine(float pauseTime)
    {
        animator.enabled = false; // Pausa el Animator.
        yield return new WaitForSeconds(pauseTime);
        animator.enabled = true; // Reactiva el Animator.
    }
}
