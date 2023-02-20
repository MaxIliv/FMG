using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.UI
{
  public class ArmorBar : MonoBehaviour
  {
      public Slider slider;
    //  public Gradient gradient;
      public Image fill;
      

      public int maxHealth;
      public void SetMaxArmorHealth(int health)
      {
        return;
          slider.maxValue = health;
          slider.value = health;

      //  fill.color =  gradient.Evaluate(1f);
      }

      public void SetArmorHealth(int health)
      {
        return;
          slider.value = health;

        //  fill.color = gradient.Evaluate(slider.normalizedValue);
      }
  }
}
