using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    public ghostIA enemyScript; // Arrastra el objeto con el script ghostIA aqu� en el Inspector.

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Colisi�n con el jugador detectada.
            // Activa el enemigo.
            enemyScript.enabled = true;
            // Desactiva este objeto para que no se pueda recoger nuevamente.
            gameObject.SetActive(false);
        }
    }
}
