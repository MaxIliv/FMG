using System.Collections;
using UnityEngine;
using RPG.Battle;

namespace RPG.Battle
{
  [RequireComponent(typeof(Health))]
  public class Fighter : MonoBehaviour {
    [SerializeField] Weapon defaultWeapon = null;
    [SerializeField] Transform rightHandTransform = null;
    [SerializeField] Transform leftHandTransform = null;

    Weapon currentWeapon = null;
    public Weapon CurrentWeapon { get { return currentWeapon; } }

    BattleCharacter target;
    BattleCharacter battleCharacter;
    BattleChecks battleChecks;
    CharacteristicBonus characteristicBonus;

    void Awake()
    {
      battleCharacter = GetComponent<BattleCharacter>();
      battleChecks = GetComponent<BattleChecks>();
      characteristicBonus = GetComponent<CharacteristicBonus>();
      EquipWeapon(defaultWeapon);
    }

    // Perform Hit Action
    public void Hit()
    {
      if (battleCharacter.IsDead) return;
      if (target == null || target.IsDead) return;

      battleCharacter.MakeAction();

      BattleChecks targetBattleChecks = target.transform.GetComponent<BattleChecks>();

      bool isHitSuccess = battleChecks.IsSuccessfulHit(targetBattleChecks);

      if (isHitSuccess == false) return;

      bool isHitBlocked = targetBattleChecks.IsHitBlocked(battleChecks);

      if (isHitBlocked == true) return;

      target.TakeDamage(currentWeapon, CalculatedAttackDamage());
    }

    // Define target to Attack
    public void Attack(GameObject _target)
    {
      target = _target.GetComponent<BattleCharacter>();
    }

    // Stop Attacking
    public void Cancel()
    {
      target = null;
    }

    // Equip some weapon on Fighter
    public void EquipWeapon(Weapon weapon)
    {
      currentWeapon = weapon;
      // Animator animator = GetComponent<Animator>();
      weapon.Spawn(rightHandTransform, leftHandTransform, null);
    }

    // this method calculates current Fighter attack damage
    // based on character and weapon
    public int CalculatedAttackDamage()
    {
      bool isCriticalDamage = battleChecks.IsCriticalDamage();

      int criticalDamage = characteristicBonus.criticalAttackBonus;
      int basicDamage = characteristicBonus.attackBonus;
      int damage = currentWeapon.WeaponDamage;

      damage += isCriticalDamage ? criticalDamage : basicDamage;

      return damage;
    }
  }
}