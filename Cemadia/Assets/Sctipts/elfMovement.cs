using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elfMovement : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float radioAttackMelee;
    [SerializeField] private Transform meleeController;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("atacaaa "+animator.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Activa el trigger 'Golpear'
            Debug.Log("atacaaa "+animator.name);
            animator.SetTrigger("Ataca");
            SwordAttack();

        }
    }

    private void SwordAttack(){
        Collider2D[] objetos=Physics2D.OverlapCircleAll(meleeController.position, radioAttackMelee);
        foreach(Collider2D collider in objetos){
            //collider.transform.GetComponent<GameObject>();
            if(collider.CompareTag("Enemy")){
                Debug.Log("Daño");
            }
        }
    }
    private void OnDrawGizmos() {
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(meleeController.position, radioAttackMelee);
    }
    public void FinishHit()
{
    Debug.Log("La animación ha terminado.");
    // Aquí puedes desbloquear la acción de golpear nuevamente
}

}
