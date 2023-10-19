using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;

    

    public void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    


}
