using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SensSlider : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI slidertext;

    public static float sens = 1;

    private void Start()
    {
        slider.value = sens;
        slidertext.text = sens.ToString("0.00");
        slider.onValueChanged.AddListener((v) => {
            slidertext.text = v.ToString("0.00");
            sens = slider.value;
        });
    }
}
