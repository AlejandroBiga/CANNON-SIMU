using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColision : MonoBehaviour
{
    public GameObject canvasObject;
    public float canvasDisplayTime = 6.0f;
    private bool collided = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("conchade la lora");
            if (!collided)
            {
                collided = true;

               
                canvasObject.SetActive(true);
                StartCoroutine(DisableCanvas());
            }
        }
    }

    private IEnumerator DisableCanvas()
    {
        yield return new WaitForSeconds(canvasDisplayTime);
        canvasObject.SetActive(false);
    }
}
