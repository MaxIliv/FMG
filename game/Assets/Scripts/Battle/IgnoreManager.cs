using UnityEngine;

namespace RPG.Battle
{

  // This class is used for Character Ignored Damage Calculations
  public class IgnoreManager : MonoBehaviour {
  [SerializeField] public BattleCharacter battleCharacter;
    
    void Awake()
    {
      battleCharacter = GetComponent<BattleCharacter>();
    }


    // Calculate How many Damage Points Ignored
    public int Ignore(Weapon weapon)
    {
      int damageIgnored = 0;
      damageIgnored += IgnorePiercing(weapon);
      damageIgnored += IgnoreSlashing(weapon);
      damageIgnored += IgnoreBludgeoning(weapon);
      damageIgnored += IgnoreMagic(weapon);

      return damageIgnored;
    }

    int IgnorePiercing(Weapon weapon)
    {
      int toPiercing = battleCharacter.ignoredDamage.toPiercing;

      if (weapon.Piercing && toPiercing > 0)
      {
        int damageIgnored = CalculateIgnoredDamage(weapon, toPiercing);
        Debug.Log("Ignored Piercing attack! - Damage ignored is " + damageIgnored);
        return (int)damageIgnored;
      }

      return 0;
    }

    int IgnoreSlashing(Weapon weapon)
    {
      int toSlashing = battleCharacter.ignoredDamage.toSlashing;

      if (weapon.Slashing && toSlashing > 0)
      {
        int damageIgnored = CalculateIgnoredDamage(weapon, toSlashing);
        Debug.Log("Ignored slashing attack! - Damage ignored is " + damageIgnored);

        return (int)damageIgnored;
      }

      return 0;
    }

    int IgnoreBludgeoning(Weapon weapon)
    {
      int toBludgeoning = battleCharacter.ignoredDamage.toBludgeoning;

      if (weapon.Bludgeoning && toBludgeoning > 0)
      {
        int damageIgnored = CalculateIgnoredDamage(weapon, toBludgeoning);
        Debug.Log(" Ignored Bludgeoning attack! - Damage ignored is " + damageIgnored);

        return (int)damageIgnored;
      }

      return 0;
    }

    int IgnoreMagic(Weapon weapon)
    {
      int toMagic = battleCharacter.ignoredDamage.toMagic;

      if (weapon.Magic && toMagic > 0)
      {
        int damageIgnored = CalculateIgnoredDamage(weapon, toMagic);
        Debug.Log(" Ignored Magic attack! - Damage ignored is " + damageIgnored);

        return (int)damageIgnored;
      }

      return 0;
    }

    int CalculateIgnoredDamage(Weapon weapon, int ignorePercentage)
    {
      float damage = weapon.WeaponDamage;
      damage = damage / 100 * ignorePercentage;
      damage = Mathf.Round(damage);

      return (int)damage;
    }
  }
}