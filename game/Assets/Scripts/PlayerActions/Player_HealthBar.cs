using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// To Be Removed - Health.cs
public class Player_HealthBar : MonoBehaviour
{
    public Slider slider;
   // public Gradient gradient;
    public Image fill;


    public int maxHealth;
    public void SetMaxHealth(int health)
    {
        // slider.maxValue = health;
        // slider.value = health;

        //fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        // slider.value = health;

       // fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
