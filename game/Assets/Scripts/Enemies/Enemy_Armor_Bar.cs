using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// To Be Removed
// Refactored to Armor.cs
public class Enemy_Armor_Bar : MonoBehaviour
{
    public Slider slider;
  //  public Gradient gradient;
    public Image fill;
    

    public int maxHealth;
    public void SetMaxArmorHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

     //  fill.color =  gradient.Evaluate(1f);
    }

    public void SetArmorHealth(int health)
    {
        slider.value = health;

      //  fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
