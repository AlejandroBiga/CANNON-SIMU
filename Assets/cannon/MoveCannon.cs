using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCannon : MonoBehaviour
{
    
    public Slider CannonSlider;
    public Transform Cannon;

    
    void Update()
    {
        
        float CannonRotate = CannonSlider.value;
        Cannon.rotation = Quaternion.Euler(CannonRotate, 0f, 0f);


    }
}
