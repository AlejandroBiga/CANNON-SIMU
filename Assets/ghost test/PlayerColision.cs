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
            Destroy(other.gameObject);
            Invoke("HideCanvas", 2f);
        }
    }

    private void ShowCanvas()
    {
        canvas.SetActive(true); 
    }

    private void HideCanvas()
    {
        canvas.SetActive(false); 
    }
}
