using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    public ghostIA enemyScript; 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            enemyScript.enabled = true;
            
            gameObject.SetActive(false);
        }
    }
}
