using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battery : MonoBehaviour
{
    private Slider slider;

    void Start()
    {
        slider = this.GetComponent<Slider>();
    }

    public void UpdateSlider(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }
}
