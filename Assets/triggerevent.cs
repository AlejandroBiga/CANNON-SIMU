using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerevent : MonoBehaviour
{
    private spawnEnemy enemySpawner;

    private void Start()
    {
        enemySpawner = FindObjectOfType<spawnEnemy>(); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Object"))
        {
            enemySpawner.SpawnEnemy();
            Destroy(collision.gameObject);
        }
    }
}
