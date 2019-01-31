using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class SliderScript : MonoBehaviour
{
    public Slider mainSlider;
    public Text sliderText;
    public TextMeshProUGUI sliderMeshText;
    public void Start()
    {
        //Adds a listener to the main slider and invokes a method when the value changes.
        mainSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
        if(mainSlider.value == 0)
        {
            sliderMeshText.text = "Slow";
            SavedSettings.RunSpeed = 40;
        }else if(mainSlider.value == 1)
        {
            sliderMeshText.text = "Medium";
            SavedSettings.RunSpeed = 80;
        }
        else
        {
            sliderMeshText.text = "Fast";
            SavedSettings.RunSpeed = 120;
        }
        
    }
}
