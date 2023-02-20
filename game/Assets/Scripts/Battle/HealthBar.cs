using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.UI
{
  public class HealthBar : MonoBehaviour
  {
      public Slider slider;
      public Image fill;

      public Gradient gradient;

      public int maxHealth;
      public void SetMaxHealth(int health)
      {
        return; // FIX
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
      }

      public void SetHealth(int health)
      {
        return; // FIX
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
      }
  }
}
