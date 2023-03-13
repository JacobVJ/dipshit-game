using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSprint : MonoBehaviour
{
    public bool Sprint = false;
    public float Value = 0;
    public Slider slider;
    // maxvalue
    //minvalue

    void Start()
    {
        slider.value = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Sprint == true)
        {
            
        }


    }
}
