using UnityEngine;

namespace RPG.Battle
{
  [CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Make New Weapon", order = 0)]
  public class Weapon : ScriptableObject {
    [SerializeField] GameObject equippedPrefab = null;
    [SerializeField] bool isRightHanded = true;

    [SerializeField] Projectile projectile = null;
    [SerializeField] public bool HasProjectile { get { return projectile != null; } }

    [SerializeField] int weaponDamage = 10;
    [SerializeField] public int WeaponDamage { get { return weaponDamage; } }
    [SerializeField] public int criticalAttackChance = 1;

    [Header("Bonus")]
    // Used for player attack and critial attack bonus
    [Range(0, 1)]
    [SerializeField] public float strengthPercentage = 0.5f;
    [Range(0, 1)]
    [SerializeField] public float dexterityPercentage = 0.5f;

    [Header("Attack Type")]
    public bool Piercing;
    public bool Slashing;
    public bool Bludgeoning;
    public bool Magic;

    [Header("Block Specifics")]
    public bool canBlock;
    public int blockBreakingPoints = 5;
    public int Precision;

    // used for 
    // [SerializeField] int weaponRange = 10; ?

    // Used to change attack/hit character animation
    // [SerializeField] AnimatorOverrideController animatorOverride = null;

    public void Spawn(Transform rightHand, Transform leftHand, Animator animation)
    {
      if (equippedPrefab)
      {
        Transform handTransform = GetTransform(rightHand, leftHand);

        Instantiate(equippedPrefab, handTransform);
      }

      // animator.runtimeAnimatorController = animatorOverride;
    }

    public void LaunchProjectile(Transform rightHand, Transform leftHand, Health target)
    {
      Vector3 pos = GetTransform(rightHand, leftHand).position;
      Projectile projectileInstance = Instantiate(projectile, pos, Quaternion.identity);
      projectileInstance.SetTarget(target);
    }

    private Transform GetTransform(Transform rightHand, Transform leftHand)
    {
      Transform handTransform;

      if (isRightHanded) handTransform = rightHand;
      else handTransform = leftHand;

      return handTransform;
    }

  }
}