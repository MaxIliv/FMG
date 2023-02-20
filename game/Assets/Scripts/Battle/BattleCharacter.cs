using UnityEngine;
using RPG.Battle;

namespace RPG.Battle
{
  [RequireComponent(typeof(Health))]
  [RequireComponent(typeof(Fighter))]
  [RequireComponent(typeof(CharacteristicBonus))]
  [RequireComponent(typeof(VulnerabilityManager))]
  [RequireComponent(typeof(IgnoreManager))]
  [RequireComponent(typeof(BattleChecks))]
  public class BattleCharacter : MonoBehaviour {
    [Header("Characterisitcs")]
    [SerializeField] public CharacterAttributes attributes;
    [SerializeField] public CharacterIgnoreDamage ignoredDamage;
    [SerializeField] public CharacterVulnerabilities vulnerabilities;

    private bool isDead = false;
    public bool IsDead {
      get { return isDead; }
      set { isDead = value; }
    }

    public int onLuck;

    public int Luck { get { return attributes.luck; }}
    public int Dexterity { get { return attributes.dexterity; }}
    public int Strength { get { return attributes.strength; }}

    // General References
    public TurnManager TurnManager;
    private GameObject GameMaster;
    public Text_Effects TextEffects;
    public Health health;
    public Armor armor;
    public Fighter fighter;

    // Character Refs
    private Animator anim;

    void Awake()
    {
      GameMaster = GameObject.FindGameObjectWithTag("GM");
      TextEffects = GameMaster.GetComponent<Text_Effects>();
      TurnManager = GameMaster.GetComponent<TurnManager>();

      health = GetComponent<Health>();
      armor = GetComponent<Armor>();
      fighter = GetComponent<Fighter>();
    }

    public void TakeDamage(Weapon weapon, int initialDamage)
    {
      // Check Armor
      if (armor && armor.HasArmor) {
        armor.TakeDamage(weapon, initialDamage);
        return;
      }

      health.TakeDamage(weapon, initialDamage);
    }

    public void MakeAction()
    {
      TurnManager.MakeAction();
    }

    public void OnDead()
    {
      TurnManager.OnCharacterDie(gameObject);
    }

    public void StopBattle()
    {
      fighter.Cancel();
    }
  }
}