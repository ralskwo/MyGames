using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GageBar : MonoBehaviour
{
    public Slider slider;

    public void SetHP(float currentValue, float maxValue)
    {
        if (currentValue > maxValue)
            currentValue = maxValue;

        slider.value = currentValue / maxValue;
    }
}
