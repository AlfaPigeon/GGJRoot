using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealBar : MonoBehaviour
{


    private Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
        target_value=slider.maxValue;
    }

    private void Update()
    {
        if(slider.value > target_value)
        {
            slider.value = Mathf.Lerp(slider.value, target_value, Time.deltaTime);
        }
    }
    public void SetMaxHealth(float value)
    {
        slider.maxValue = value;
        slider.value = value;
        target_value = value;
    }

    private float target_value;
    public void SetHealth(float value)
    {
        if(target_value != slider.maxValue)
        {
            slider.value = target_value;
     
        }

            target_value = value;
       
    }

}
