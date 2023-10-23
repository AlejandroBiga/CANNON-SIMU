using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColision : MonoBehaviour
{
    public GameObject canvas; 


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            ShowCanvas();
        }
    }

    private void ShowCanvas()
    {
        canvas.SetActive(true); 
    }
}
