using UnityEngine;
using RPG.Battle;

namespace RPG.Battle
{
  public class CharacteristicBonus : MonoBehaviour {
    Fighter fighter;
    BattleCharacter battleCharacter;

    public int attackBonus;
    public int criticalAttackBonus;

    void Awake()
    {
      fighter = GetComponent<Fighter>();
      battleCharacter = GetComponent<BattleCharacter>();
    }
    void Start()
    {
      CalculateBonus();
    }

    // Calculate Attack Bonus
    void CalculateBonus()
    {
      float attackBonusSTR;
      float attackBonusDEX;

      Weapon P_Weapon = fighter.CurrentWeapon;
      int PStrength = battleCharacter.Strength;
      int PDexterity = battleCharacter.Dexterity;

      float STRPercentage = P_Weapon.strengthPercentage;
      float DEXPercentage = P_Weapon.dexterityPercentage;

      attackBonusSTR = PStrength * STRPercentage;
      attackBonusSTR = attackBonusSTR;

      attackBonus += (int)attackBonusSTR;
      criticalAttackBonus += (int)attackBonusSTR * 2;

      attackBonusDEX = PDexterity * DEXPercentage;
      attackBonusDEX = attackBonusDEX;

      attackBonus += (int)attackBonusDEX;
      criticalAttackBonus += (int)attackBonusDEX * 2;

      Debug.Log("Bonus to your weapon from your STR characteristic is "  + attackBonusSTR);
      Debug.Log("Bonus to yuor weapon from your DEX characteristic is " + attackBonusDEX);
    }
  }
}