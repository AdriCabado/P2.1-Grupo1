using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeScript : MonoBehaviour
{
    public Transform hitPoint; // Asigna el objeto HitPoint en el Inspector
    public Transform hitPointArrived; // El punto final al que se moverá
    private Vector3 originalPosition; // Guarda la posición original

    [SerializeField] float timeAction = 0.5f; // Tiempo para mover el HitPoint, ajusta según necesites
    private bool isMoving = false; // Para evitar iniciar múltiples movimientos a la vez

    private void Start()
    {
        originalPosition = hitPoint.localPosition; // Guarda la posición original local
    }

    // Método para iniciar el movimiento
    public void MoverHitPoint()
    {
        if (!isMoving) // Solo inicia el movimiento si no está en curso otro
        {
            StartCoroutine(MoverHitboxCoroutine()); // Inicia la Coroutine para mover el HitPoint
        }
    }

    private IEnumerator MoverHitboxCoroutine()
    {
        isMoving = true; // Marca como en movimiento

        float timePass = 0f; // Tiempo transcurrido

        // Mueve el hitPoint de su posición inicial a la posición de destino
        while (timePass < timeAction)
        {
            timePass += Time.deltaTime; // Aumenta el tiempo transcurrido
            float t = Mathf.SmoothStep(0f, 1f, timePass / timeAction); // Uso de SmoothStep para suavizar el movimiento
            hitPoint.localPosition = Vector3.Lerp(originalPosition, hitPointArrived.localPosition, t); // Interpola entre A y B (en espacio local)
            yield return null; // Espera un frame antes de continuar
        }

        hitPoint.localPosition = hitPointArrived.localPosition; // Asegura que llegue exactamente a la posición de destino
        hitPoint.localPosition = originalPosition; // Vuelve inmediatamente a la posición original

        isMoving = false; // Marca el fin del movimiento
    }
}