using UnityEngine;
using RPG.UI;

namespace RPG.Battle
{
  [RequireComponent(typeof(HealthBar))]
  public class Health : MonoBehaviour {
    [SerializeField] public int maxValue = 100;
    [SerializeField] public int value;

    [SerializeField] public HealthBar healthBar;
    [SerializeField] public BattleCharacter battleCharacter;
    [SerializeField] public VulnerabilityManager vulnerabilityManager;
    [SerializeField] public IgnoreManager ignoreManager;

    void Awake()
    {
      battleCharacter = GetComponent<BattleCharacter>();
      vulnerabilityManager = GetComponent<VulnerabilityManager>();
      ignoreManager = GetComponent<IgnoreManager>();
      healthBar = GetComponent<HealthBar>();
    }

    void Start()
    {
      value = maxValue;
      healthBar.SetMaxHealth(maxValue);
    }

    public void TakeDamage(Weapon weapon, int initialDamage)
    {
      int damage = initialDamage;
      damage += vulnerabilityManager.Damage(weapon);
      damage -= ignoreManager.Ignore(weapon);

      battleCharacter.TextEffects.DamageValue(damage);

      Debug.Log($"Damage get {damage}");

      value = Mathf.Max(value - damage, 0);
      healthBar.SetHealth(value);

      if (value <= 0) Die();
    }

    void Die()
    {
      if (battleCharacter.IsDead) return;

      battleCharacter.IsDead = true;
      CharacterDie();
    }

    void CharacterDie()
    {
      battleCharacter.OnDead();
      Destroy(gameObject, 5f);
    }
  }
}