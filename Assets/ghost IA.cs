using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ghostIA : MonoBehaviour
{
    public Transform player;
    public float speedChase;

    private void Update()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
        transform.Translate(direction * speedChase * Time.deltaTime);   
        
    }
}
