using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moveBase : MonoBehaviour
{
    public Slider BaseSlider;
    public Transform Base;
  
    void Update()
    {
        float BaseRotation = BaseSlider.value;
        Base.rotation = Quaternion.Euler(0f, BaseRotation, 0f);

    }
}
