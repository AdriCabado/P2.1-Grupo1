using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerScript : MonoBehaviour
{
    private GameObject enemySpawner;
    private GameObject elf;
    private void Start() {
        enemySpawner=GameObject.Find("EnemySpawner");
        elf =GameObject.Find("idle_1");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Elf"))
        {
            enemySpawner.GetComponent<EnemySpawner>().lifeLost();
            // Inicia la corutina para cambiar el color
            StartCoroutine(ChangeColorTemporarily());
            SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            Color color = spriteRenderer.color;
            color.a = 0f; // Establece la transparencia a 0 (invisible)
            spriteRenderer.color = color;

        }
    }

    private IEnumerator ChangeColorTemporarily()
    {
        // Obtén el SpriteRenderer del objeto colisionado
            if (elf!=null){
                // Cambia el color a rojo
                elf.GetComponent<SpriteRenderer>().color=Color.red;
                // Espera 1 segundo
                yield return new WaitForSeconds(0.3f);
                Debug.Log("hittt");
                // Cambia el color a blanco
                 elf.GetComponent<SpriteRenderer>().color=Color.white;     
            }
            

              
        Destroy(gameObject);        
    }
}
