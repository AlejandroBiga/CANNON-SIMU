using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ghostIA : MonoBehaviour
{
    private GameObject player;
    public float speedChase;
    public GameObject canvasObject;
    public float canvasDisplayTime = 6.0f;

    private bool collided = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); 
    }

    private void Update()
    {
        if (!collided)
        {
            if (player != null)
            {
                Vector3 direction = player.transform.position - transform.position;
                direction.Normalize();
                Quaternion rotation = Quaternion.LookRotation(direction);
                transform.rotation = rotation;
                transform.Translate(direction * speedChase * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
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
        
        Destroy(gameObject);
    }
}
