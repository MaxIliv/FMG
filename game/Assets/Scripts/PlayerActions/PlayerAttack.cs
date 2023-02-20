using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int attackPower;
    public int criticalAttackPower;
    public int damage;
    // public bool CriticalDamage;


    public bool AttackMissed;
    public bool AttackBlocked;

    [Header("Rreferences")]
    private GameObject _weapon;

    public Player_Battle player;
    public Enemy_Handler enemy;
    public WeaponHandler weapon;
    public Checks_Atributes Check;

    public Turn_Manager TM;





    private void Awake()
    {
        _weapon = GameObject.FindGameObjectWithTag("Weapon");
        weapon = _weapon.GetComponent<WeaponHandler>();

        player = GetComponent<Player_Battle>();



    }

    void Start()
    {
        attackPower = weapon.basicAttack;
        criticalAttackPower = weapon.criticalAttack;




        
    }


    void Update()
    {
        
    }

    public void Attack()
    {
        
        if (TM.state != TurnState.PLAYER_TURN) return;

        if (TM.playerTurn)
        {
            if (player.actionMade)
            {
                player.PlayerAttackAnimations();
                player.actionMade = false;
                TM.MakeAction();
                Check.CheckOnHitting();
                
                if (!AttackMissed)
                {
                    if (!enemy.canBlock)
                    {
                        Damage();
                        enemy.GetDamage();
                    }
                    if (enemy.canBlock)
                    {
                        Check.CheckOnBlock();
                        if (!AttackBlocked)
                        {
                            Damage();
                            enemy.GetDamage();
                        }
                    }            
                }


            }
        }



    }

    public void Damage()
    {
        // Check.CheckOnCriticalDamage();

        // if (CriticalDamage)
        // {
        //     damage = criticalAttackPower;

        // }
        // else if (!CriticalDamage)
        // {
        //     damage = attackPower;
        // }
    }


}
