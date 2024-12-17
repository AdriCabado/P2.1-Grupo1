
using UnityEngine;


public class elfMovement : MonoBehaviour
{
    
    //[SerializeField] private Animator animator;
    [SerializeField] GameObject enemySpawner;
    [SerializeField] private float radioAttackMelee;
    [SerializeField] private float radioAttackArrow;
    [SerializeField] private Transform meleeController;

    [SerializeField] private Transform arrowController;
    
    private void Start() {
        
    }
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
                collider.GetComponent<EnemyMove>().volando=true;
                Rigidbody2D rb=collider.GetComponent<Rigidbody2D>();
                rb.constraints =RigidbodyConstraints2D.None;
                Vector2 impactDirection = new Vector2(0.6f, 0.5f);
                rb.AddForce(impactDirection.normalized * 10f, ForceMode2D.Impulse); 
                rb.AddTorque(19, ForceMode2D.Impulse);
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
