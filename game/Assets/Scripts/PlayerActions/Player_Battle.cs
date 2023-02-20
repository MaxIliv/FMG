using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// To Be Removed
// Refactored to BattleCharacter.cs, Health.cs, Fighter.cs
public class Player_Battle : MonoBehaviour
{
    [Header("characterisitcs")]
    public int MaxHealth;
    public int MaxArmor;
    public int MaxManna;

    public int health;
    public int armor;
    public int manna;



    
    [Header("Atributes")]
    public int initiative;
    public int strength;
    public int dexterity;
    public int intelligence;
    public int luck;


    public bool useMagic;
    public bool hasArmor;



    
    public bool actionMade;// activated from MakeActionPlayer script.
    
    public bool skillActivated;
    public string skillName; // get skill name depending on activated button (Button_Visual script)


    [Header("Checks")]
    public int onLuck;


    [Header("References")]
    
    private GameObject GM;
    public Animator anim;
   // public Animator effectAnim;

    public Enemy_Handler Enemy;
    public Player_HealthBar HB;
    //public Turn_Manager TM;
   // public DiceRoll dice_roll;
    public PlayerAttack playerAttack;

    public BattleSceneController BSC;

    //public GameObject clickingArea;
    void Awake()
    {
        // GM = GameObject.FindGameObjectWithTag("GM");
        // BSC = GM.GetComponent<BattleSceneController>();

    }
    void Start()
    {


        health = MaxHealth;
        HB.SetMaxHealth(MaxHealth);

        // UpdateEnemy();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetDamage()
    {
        // effectAnim.SetTrigger("damage");
        health -= 10;
        HB.SetHealth(health);
        Debug.Log("Player got damage");

    }

    public void Attack()
    {
        playerAttack.Attack();


    }



    public void PlayerAttackAnimations()
    {
        if (skillName == "LongSword")
        {
            anim.Play("LongSwordAttack");
        }
    }

   public void UpdateEnemy(Enemy_Handler _enemy)
    {
        Enemy = _enemy;
        playerAttack.enemy = Enemy;
    }
}
