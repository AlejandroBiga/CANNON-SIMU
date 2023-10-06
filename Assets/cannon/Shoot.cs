using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;
public class Shoot : MonoBehaviour
{
    
    
    public Transform Cannon;
    public float bulletForce;
    public float objectLifetime = 3;
    public Rigidbody ballPrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootBall();
        }
    }

    void ShootBall()
    {
        Rigidbody spawnedObject = Pooling.SharedInstance.GetPooledObject().GetComponent<Rigidbody>();

        if (spawnedObject != null)
        {
            spawnedObject.transform.position = Cannon.position;
            spawnedObject.transform.rotation = Quaternion.identity;
            spawnedObject.gameObject.SetActive(true);
            spawnedObject.velocity = Cannon.forward * bulletForce;

            StartCoroutine(DeactivateObject(spawnedObject.gameObject));
        }
    }
    IEnumerator DeactivateObject(GameObject objToDeactivate)
    {
        yield return new WaitForSeconds(objectLifetime);


        objToDeactivate.SetActive(false);
    }

}
    
        

