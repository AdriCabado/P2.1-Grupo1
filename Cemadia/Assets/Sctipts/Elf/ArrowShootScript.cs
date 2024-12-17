using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShootScript : MonoBehaviour
{
   public GameObject arrowPrefab; // El prefab de la flecha
    public Transform arrowSpawnPoint; // Punto de salida de la flecha
    public float arrowSpeed = 15f; // Velocidad de la flecha

   
    public void Shoot()
    {
        // Crear la flecha en la posición y rotación del punto de salida
        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
        
        // Aplicar movimiento a la flecha
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = arrowSpawnPoint.right * arrowSpeed; 
        }
       
    }
}
