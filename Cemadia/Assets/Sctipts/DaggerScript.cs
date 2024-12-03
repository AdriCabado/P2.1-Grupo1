using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Elf"))
        {
            // Inicia la corutina para cambiar el color
            StartCoroutine(ChangeColorTemporarily(other));
            SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            Color color = spriteRenderer.color;
            color.a = 0f; // Establece la transparencia a 0 (invisible)
            spriteRenderer.color = color;
        }
    }

    private IEnumerator ChangeColorTemporarily(Collider2D elf)
    {
        // Obtén el SpriteRenderer del objeto colisionado
        
        
        
            // Cambia el color a rojo
            GameObject.Find("idle_1").GetComponent<SpriteRenderer>().color=Color.red;
            // Espera 1 segundo
            yield return new WaitForSeconds(0.3f);
            Debug.Log("hittt");
            // Cambia el color a blanco
           
            GameObject.Find("idle_1").GetComponent<SpriteRenderer>().color=Color.white;        
        Destroy(gameObject);        
    }
}
