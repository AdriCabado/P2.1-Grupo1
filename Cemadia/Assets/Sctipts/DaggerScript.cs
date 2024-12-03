using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Elf"))
        {
            StartCoroutine(ChangeColorTemporarily(other.gameObject));
            
        }
       
    }
      private IEnumerator ChangeColorTemporarily(GameObject elf)
    {
        // Cambiar el color a rojo
        SpriteRenderer spriteRenderer = elf.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.red;
        }

        // Esperar 1 segundo
        yield return new WaitForSeconds(1f);

        // Cambiar el color a blanco
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.white;
        }
    }
}
