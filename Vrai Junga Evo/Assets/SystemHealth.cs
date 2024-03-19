using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemHealth : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public void VieMax(int vie)
    {
        slider.maxValue = vie;
        slider.value = vie;
        fill.color = gradient.Evaluate(1f);
    }

    public void UpdateVie(int vie)
    {
        slider.value = vie;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
