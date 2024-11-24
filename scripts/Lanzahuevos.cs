using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzahuevos : MonoBehaviour
{
    // Velocidad de movimiento
    public float velocidad = 5f;

    // Prefabricado que se instanciará al hacer clic
    public GameObject objetoPrefab;

    void Update()
    {
        // Movimiento con teclas WASD
        float movimientoHorizontal = Input.GetAxis("Horizontal"); // A/D o Flechas Izquierda/Derecha
        float movimientoVertical = Input.GetAxis("Vertical"); // W/S o Flechas Arriba/Abajo

        // Movimiento en las coordenadas X y Z
        Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical) * velocidad * Time.deltaTime;
        transform.Translate(movimiento);

        // Detectar clic izquierdo para generar un objeto en las coordenadas del jugador
        if (Input.GetMouseButtonDown(0)) // 0 es el clic izquierdo
        {
            InstanciarObjetoEnPosicion();
        }
    }

    void InstanciarObjetoEnPosicion()
    {
        // Instanciamos el objeto en la posición del jugador
        if (objetoPrefab != null)
        {
            Instantiate(objetoPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("No se ha asignado un objetoPrefab.");
        }
    }
}
