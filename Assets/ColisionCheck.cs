using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ColisionCheck : MonoBehaviour
{
    public GameObject Warning;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("building"))
        {
            Warning.SetActive(true);
        }

    }
}
