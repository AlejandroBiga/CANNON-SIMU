using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemeyFollow : MonoBehaviour
{
    public Transform player; // Debes asignar el jugador en el Inspector.
    public float speed = 3.0f; // Ajusta la velocidad según tus necesidades.

    private void Update()
    {
        // Sigue al jugador (transform del jugador).
        transform.LookAt(player);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
