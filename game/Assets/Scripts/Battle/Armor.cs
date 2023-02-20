using UnityEngine;
using RPG.UI;

namespace RPG.Battle
{
  [RequireComponent(typeof(ArmorBar))]
  public class Armor : MonoBehaviour {
    [SerializeField] public int maxValue = 100;
    [SerializeField] private int value = 100;

    [SerializeField] bool hasArmor = true;
    public bool HasArmor { get { return hasArmor; }}

    [SerializeField] public ArmorBar AB;

    void Start()
    {
      value = maxValue;
      // AB.SetMaxArmorHealth(maxValue);

      if (value <= 0) hasArmor = false;
    }

    public void TakeDamage(Weapon weapon, int damage)
    {
      value = Mathf.Max(value - damage, 0);
      AB.SetArmorHealth(value);

      if (value <= 0) Die();
    }

    void Die()
    {
      if (hasArmor == false) return;

      hasArmor = false;
    }
  }
}