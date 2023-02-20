using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RPG.UI;

// To Be Removed
// Refactored to BattleCharacter.cs, Health.cs, Fighter.cs
public class Enemy_Handler : MonoBehaviour
{

    [Header("Characterisitcs")]

    public int MaxHealth;
    public int MaxArmor;
   // public int MaxManna;

    public int health;
    public int armor;
    //public int manna;



    [Header("Attributes")]

    public int initiative;
    public int strength;
    public int dexterity;
    public int intelligence;
    public int luck;



    [Header("Vulnerabilities")]

    public int toPiercing;
    public int toSlashing;
    public int toMagic;

    public int toBludgeoning;

    [Header("Ignor damage")]

    public int to_Piercing;
    public int to_Slashing;
    public int to_Magic;

    public int to_Bludgeoning;


    [Header("Enemy specific")]

    public bool useMagic; // not implemented yet

    public bool hasArmor;
    public bool canBlock;

    public int blockChance;

    [Header("Enemy Attack Type")]

    public bool Piercing;
    public bool Slashing;
    public bool Bludgeoning;
    public bool Magic;

    [Header("Checks")]
    public int onLuck;

    [Header("References")]

    private Animator anim;
    private GameObject GameMaster;
    private Text_Effects textEffects;
    private GameObject _Player;
    private GameObject _WeaponPLayer;

    public HealthBar HB;
    public Enemy_Armor_Bar AB;
    public Checks_Atributes onCheck;
    //public DiceRoll dice_roll;
    public Turn_Manager TM;
    public Player_Battle Player;
    public PlayerAttack P_Attack;
    public WeaponHandler P_Weapon;
    public FinishBattleHandler BattleFinish;
    public BattleSceneController BSC;

    private int BonusDamage;
    private int IgnoreDamage;
    public int totalDamage;


    public bool setTimerActive;
    public float Timer;
    public float Delay;

    private bool isDead;


    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();

        GameMaster = GameObject.FindGameObjectWithTag("GM");
        _Player = GameObject.FindGameObjectWithTag("Player");
        _WeaponPLayer = GameObject.FindGameObjectWithTag("Weapon");

        textEffects = GameMaster.GetComponent<Text_Effects>();

    }
    void Start()
    {
        textEffects = GameMaster.GetComponent<Text_Effects>();
        onCheck = GameMaster.GetComponent<Checks_Atributes>();
        TM = GameMaster.GetComponent<Turn_Manager>();
        BattleFinish = GameMaster.GetComponent<FinishBattleHandler>();
        BSC = GameMaster.GetComponent<BattleSceneController>();

        Player = _Player.GetComponent<Player_Battle>();
        P_Attack = _Player.GetComponent<PlayerAttack>();

        P_Weapon = _WeaponPLayer.GetComponent<WeaponHandler>();


        health = MaxHealth;
        HB.SetMaxHealth(MaxHealth);

        armor = MaxArmor;
        AB.SetMaxArmorHealth(MaxArmor);

        // playerCharacteristicBonus();

        


    }

    // Update is called once per frame
    void Update()
    {
        if (!TM.playerTurn)
        {
            EnemyTurn();
            Timer -= Time.deltaTime;
        }


        // Dead();


    }


         

    public bool GetDamage()
    {
        totalDamage = 0;
        BonusDamage = 0;
        IgnoreDamage = 0;

        if (!isDead)
        {
            if (armor <= 0)
            {
                anim.SetTrigger("Troll_Damaged");

                hasArmor = false;

                // Enemy_Vulnerabilities();
                // Enemy_IgnoreDamage();

                totalDamage = P_Attack.damage;
                totalDamage += BonusDamage;
                totalDamage -= IgnoreDamage;

                health -= totalDamage;

                HB.SetHealth(health);

                int total_damage = P_Attack.damage + BonusDamage;
                textEffects.DamageValue(total_damage);
                Debug.Log("Total Damage is " + total_damage);
            }

            if (armor > 0)
            {
                hasArmor = true;

                float damageIncreaseArmor;

                damageIncreaseArmor = P_Attack.damage;
                damageIncreaseArmor = damageIncreaseArmor / 100 * P_Weapon.armorPiercing;
                damageIncreaseArmor = Mathf.Round(damageIncreaseArmor);

                BonusDamage += (int)damageIncreaseArmor;

                totalDamage = P_Attack.damage + BonusDamage;

                textEffects.damage = totalDamage;
                textEffects.DamageArmorValue();
                Debug.Log(" Damage is " + P_Attack.damage);




                Debug.Log("armorDamageBonus is " + damageIncreaseArmor);
                Debug.Log("Total Damage is " + totalDamage);

                armor -= totalDamage;
                AB.SetArmorHealth(armor);
            }
        }

        Dead();

        return isDead;
    }

    public void EnemyTurn()
    {
        if (TM.state != TurnState.ENEMY_TURN) return;

        if (Timer <= 0)
        {
            Attack();
            TM.currentActionNumber -= 1;

            Timer = Delay;
        }



        if (TM.currentActionNumber <= 0)
        {
            TM.FinishTurn();
            TM.newTurn();

            Debug.Log("Enemy turn finished!");
        }



    }

    public void Attack()
    {
        if (!isDead)
        {
            anim.SetTrigger("Attack_1");
            Player.GetDamage();
        }

    }

    public void Dead()
    {
        if (health <= 0)
        {
            isDead = true;
            anim?.SetBool("Dead", true);
            //BattleFinish.youWin();
            TM.EnemyDied();
            Destroy(gameObject, 5f);
        }
        
    }

    // // +
    // public void playerCharacteristicBonus()
    // {
    //     float attackBonusSTR;
    //     float attackBonusDEX;

    //     if (P_Weapon.LongSword)
    //     {
    //         attackBonusSTR = Player.strength;
    //         attackBonusSTR = attackBonusSTR / 100 * 50;
    //         attackBonusSTR = Mathf.Round(attackBonusSTR);
    //         P_Weapon.basicAttack += (int)attackBonusSTR;
    //         P_Weapon.criticalAttack += (int)attackBonusSTR * 2;

    //         attackBonusDEX = Player.strength;
    //         attackBonusDEX = attackBonusDEX / 100 * 25;
    //         attackBonusDEX = Mathf.Round(attackBonusDEX);
    //         P_Weapon.basicAttack += (int)attackBonusDEX;
    //         P_Weapon.criticalAttack += (int)attackBonusDEX * 2;

    //         Debug.Log("Bonus to your wapon from your STR characteristic is "  + attackBonusSTR);
    //         Debug.Log("Bonus to yuor weapon from your DEX characteristic is " + attackBonusDEX);

    //     }

    //     if (P_Weapon.Sword)
    //     {
    //         attackBonusSTR = Player.strength;
    //         attackBonusSTR = attackBonusSTR / 100 * 25;
    //         attackBonusSTR = Mathf.Round(attackBonusSTR);
    //         P_Weapon.basicAttack += (int)attackBonusSTR;
    //         P_Weapon.criticalAttack += (int)attackBonusSTR * 2;

    //         attackBonusDEX = Player.strength;
    //         attackBonusDEX = attackBonusDEX / 100 * 10;
    //         attackBonusDEX = Mathf.Round(attackBonusDEX);
    //         P_Weapon.basicAttack += (int)attackBonusDEX;
    //         P_Weapon.criticalAttack += (int)attackBonusDEX * 2;

    //     }

    //     if (P_Weapon.Axe || P_Weapon.Mace)
    //     {
    //         attackBonusSTR = Player.strength;
    //         attackBonusSTR = attackBonusSTR / 100 * 50;
    //         attackBonusSTR = Mathf.Round(attackBonusSTR);
    //         P_Weapon.basicAttack += (int)attackBonusSTR;
    //         P_Weapon.criticalAttack += (int)attackBonusSTR * 2;
    //     }




    // }

    // // +
    // public void Enemy_Vulnerabilities()
    // {


    //     if (P_Weapon.Piercing)
    //     {
    //         if (toPiercing > 0)
    //         {
    //             float damageIncrease;

    //             damageIncrease = P_Attack.damage;
    //             damageIncrease = damageIncrease / 100 * toPiercing;
    //             damageIncrease = Mathf.Round(damageIncrease);

    //             BonusDamage += (int)damageIncrease;

    //             Debug.Log(" Monster is vulnarable to Piercing attack! - Damage bonus is " + damageIncrease);

    //         }
    //     }

    //     if (P_Weapon.Slashing)
    //     {
    //         if (toSlashing > 0)
    //         {
    //             float damageIncrease;

    //             damageIncrease = P_Attack.damage;
    //             damageIncrease = damageIncrease / 100 * toSlashing;
    //             damageIncrease = Mathf.Round(damageIncrease);

    //             BonusDamage += (int)damageIncrease;

    //             Debug.Log(" Monster is vulnarable to slashing attack! - Damage bonus is " + damageIncrease);

    //         }
    //     }

    //     if (P_Weapon.Bludgeoning)
    //     {
    //         if (toBludgeoning > 0)
    //         {
    //             float damageIncrease;

    //             damageIncrease = P_Attack.damage;
    //             damageIncrease = damageIncrease / 100 * toBludgeoning;
    //             damageIncrease = Mathf.Round(damageIncrease);

    //             BonusDamage += (int)damageIncrease;

    //             Debug.Log(" Monster is vulnarable to Bludgeoning attack! - Damage bonus is " + damageIncrease);

    //         }
    //     }

    //     if (P_Weapon.Magic)
    //     {
    //         if (toMagic > 0)
    //         {
    //             float damageIncrease;

    //             damageIncrease = P_Attack.damage;
    //             damageIncrease = damageIncrease / 100 * toMagic;
    //             damageIncrease = Mathf.Round(damageIncrease);

    //             BonusDamage += (int)damageIncrease;

    //             Debug.Log(" Monster is vulnarable to Magic attack! - Damage bonus is " + damageIncrease);

    //         }
    //     }

    // }

    // // +
    // public void Enemy_IgnoreDamage()
    // {


    //     if (P_Weapon.Piercing)
    //     {
    //         if (to_Piercing > 0)
    //         {
    //             float damageIncrease;

    //             damageIncrease = P_Attack.damage;
    //             damageIncrease = damageIncrease / 100 * to_Piercing;
    //             damageIncrease = Mathf.Round(damageIncrease);

    //             IgnoreDamage += (int)damageIncrease;

    //             Debug.Log(" Monster IGNORS Piercing attack! - Damage ignored is " + damageIncrease);

    //         }
    //     }

    //     if (P_Weapon.Slashing)
    //     {
    //         if (to_Slashing > 0)
    //         {
    //             float damageIncrease;

    //             damageIncrease = P_Attack.damage;
    //             damageIncrease = damageIncrease / 100 * to_Slashing;
    //             damageIncrease = Mathf.Round(damageIncrease);

    //             IgnoreDamage += (int)damageIncrease;

    //             Debug.Log(" Monster IGNORS to slashing attack! - Damage ignored is " + damageIncrease);

    //         }
    //     }

    //     if (P_Weapon.Bludgeoning)
    //     {
    //         if (to_Bludgeoning > 0)
    //         {
    //             float damageIncrease;

    //             damageIncrease = P_Attack.damage;
    //             damageIncrease = damageIncrease / 100 * to_Bludgeoning;
    //             damageIncrease = Mathf.Round(damageIncrease);

    //             IgnoreDamage += (int)damageIncrease;

    //             Debug.Log(" Monster IGNORS to Bludgeoning attack! - Damage ignored is " + damageIncrease);

    //         }
    //     }

    //     if (P_Weapon.Magic)
    //     {
    //         if (to_Magic > 0)
    //         {
    //             float damageIncrease;

    //             damageIncrease = P_Attack.damage;
    //             damageIncrease = damageIncrease / 100 * to_Magic;
    //             damageIncrease = Mathf.Round(damageIncrease);

    //             IgnoreDamage += (int)damageIncrease;

    //             Debug.Log(" Monster IGNORS Magic attack! - Damage ignored is  " + damageIncrease);

    //         }
    //     }

    // }

    public void UseAbilities()
    {

    }
}
