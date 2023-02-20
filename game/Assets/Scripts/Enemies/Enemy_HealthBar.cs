using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_HealthBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;

    public Gradient gradient;


    public int maxHealth;
    public void SetMaxHealth(int armor)
    {
        slider.maxValue = armor;
        slider.value = armor;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int armor)
    {
        slider.value = armor;

        fill.color = gradient.Evaluate(slider.normalizedValue);

    }
}
