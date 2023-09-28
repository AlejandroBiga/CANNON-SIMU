using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shoot : MonoBehaviour
{
    public GameObject Ball;
    public Transform Cannon;
    public float bulletForce;
   
     void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootBall();
        }
    }

    void ShootBall()
    {
        GameObject bulletClone = Instantiate(Ball, Cannon.position, Cannon.rotation);
        Rigidbody rb = bulletClone.GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.up * bulletForce, ForceMode.Impulse);
        Destroy(bulletClone, 5f);
    }
    
        
}
