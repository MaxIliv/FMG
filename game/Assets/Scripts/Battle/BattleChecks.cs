using System.Collections;
using UnityEngine;
using RPG.Battle;

// this file calculates different special checks for battle
namespace RPG.Battle
{
  public class BattleChecks : MonoBehaviour {
    [Header("Critical Attack")]
    [SerializeField] int criticalDamageTreshold = 20; // How many points needed to activate Critical Attack

    // refs
    BattleCharacter battleCharacter;
    Fighter fighter;

    // getters
    Weapon CurrentWeapon { get { return fighter.CurrentWeapon; }}
    Text_Effects TextEffects { get { return battleCharacter.TextEffects; }}

    void Awake()
    {
      battleCharacter = GetComponent<BattleCharacter>();
      fighter = GetComponent<Fighter>();
    }

    // check if critical damage
    public bool IsCriticalDamage()
    {
      float criticalDamage = Random.Range(1, 21);
      criticalDamage += CurrentWeapon.criticalAttackChance;
      criticalDamage += Mathf.Round(battleCharacter.Luck * 0.1f);

      if (criticalDamage >= criticalDamageTreshold)
      {
        Debug.Log("Critical damage!");
        TextEffects.Critical();
        return true;
      }

      return false;
    }
    
    // check if Character made a successful attack / hit
    // based on Weapon
    public bool IsSuccessfulHit(BattleChecks target)
    {
      float defencePoints = target.HitDefencePoints();
      float attackPoints = HitAtackPoints();

      Debug.Log($"Attack pts is {attackPoints}. Defence pts is {defencePoints}");

      if (attackPoints > defencePoints)
      {
        Debug.Log("Hit successful!");

        return true;
      }

      TextEffects.Missed();
      Debug.Log("Hit Missed!");

      return false;
    }

    // Calculate Hit Points for Attack
    public float HitAtackPoints()
    {
      float points = Random.Range(1, 21);

      points += battleCharacter.Dexterity * 0.1f;
      points += battleCharacter.Luck * 0.1f;
      points += CurrentWeapon.Precision;

      return points;
    }

    // Calculate Hit Points for Defence
    public float HitDefencePoints()
    {
      float points = Random.Range(1, 21);

      points += battleCharacter.Dexterity * 0.25f;
      points += battleCharacter.Luck * 0.10f;

      return points;
    }

    // Calculate whether Hit was Blocked ot Not
    public bool IsHitBlocked(BattleChecks opponent)
    {
      if (!CurrentWeapon.canBlock) return false;

      float attackPoints = opponent.BlockAttackPoints();
      float defencePoints = BlockDefencePoints();

      Debug.Log($"Block: Defence pts {defencePoints}. Attack pts {attackPoints}");
      if (defencePoints > attackPoints)
      {
        TextEffects.Blocked();
        Debug.Log("Blocked");

        return true;
      }

      Debug.Log("Block Crashed ");
      return false;
    }

    // Calculate Block Points for Defence
    public float BlockDefencePoints()
    {
      float points = Random.Range(1, 21);

      points += battleCharacter.Dexterity * 0.2f;
      points += battleCharacter.Luck * 0.1f;
      points += battleCharacter.Strength * 0.1f;

      return points;
    }

    // Calculate Block Break Points for Attack
    public float BlockAttackPoints()
    {
      float points = Random.Range(1, 21);

      points += battleCharacter.Dexterity * 0.1f;
      points += battleCharacter.Luck * 0.1f;
      points += battleCharacter.Strength * 0.2f;
      points += CurrentWeapon.blockBreakingPoints;

      return points;
    }

    // Calculate Character First Turn Initiative
    public float InitiativePoints()
    {
      float points = Random.Range(1, 21);
      points += battleCharacter.attributes.initiative;

      return points;
    }

    // Calculate Character Luck Points before Turn
    public double TurnLuckPoints()
    {
      double points = Random.Range(1, 21);
      points += battleCharacter.Luck * 0.25;

      return points;
    }
  }
}