using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SensSlider : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI slidertext;

    private void Start()
    {
        // referenced from youtube tuterial 
        slider.value = PlayerPrefs.GetFloat("Sens", 1.0f); // help from chatgbt
        slidertext.text = slider.value.ToString("0");
        slider.onValueChanged.AddListener((value) =>
        {
            slidertext.text = value.ToString("0");
            PlayerPrefs.SetFloat("Sens", value);

            Debug.Log(value);
        });
    }
}
