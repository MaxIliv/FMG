using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// To Be Removed
// Refactored to Fighter.cs
public class Checks_Atributes : MonoBehaviour
{

    [Header("Battle Check Results")]
    public int Player_Hitting;
    public int Enemy_Hitting;

    public int Player_Blocking;
    public int Enemy_Blocking;

    [Header("References")]
    public Enemy_Handler Enemy;
    public Player_Battle Player;
    private Turn_Manager TM;
    public PlayerAttack P_Attack;
    public WeaponHandler Weapon;


    private GameObject GameMaster;
    private Text_Effects TextEffects;

    private void Awake()
    {
        GameMaster = GameObject.FindGameObjectWithTag("GM");
        TextEffects = GameMaster.GetComponent<Text_Effects>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Battle>();

        EventManager.OnNewEnemy += OnNewEnemy;

        GameObject _weapon = GameObject.FindGameObjectWithTag("Weapon");
        Weapon = _weapon.GetComponent<WeaponHandler>();
    }

    void Start()
    {
        TM = GetComponent<Turn_Manager>();


    }

    // додаткове очко дії
    public void CheckOnLuck_Enemy()
    {
        int randomValue;
        randomValue = Random.Range(1, 21);


        float luckResult;
        float luckBonus;


        luckResult = (float)Enemy.luck / 100;
        luckResult *= 25;
        luckResult = Mathf.Round(luckResult);
        luckResult = (int)luckResult;
        luckBonus = (int)luckResult;
        luckResult += randomValue;

        Enemy.onLuck = (int)luckResult;


    }

    // додаткове очко дії
    public void CheckOnLuck_Player()
    {
        int randomValue;
        randomValue = Random.Range(1, 21);


        float luckResult;
        float luckBonus;


        luckResult = (float)Player.luck / 100;
        luckResult *= 25;
        luckResult = Mathf.Round(luckResult);
        luckResult = (int)luckResult;
        luckBonus = (int)luckResult;
        luckResult += randomValue;

        Player.onLuck = (int)luckResult;

    }

    // чи попав
    public void CheckOnHitting()
    {

        int Player_Random = Random.Range(1, 21);

        float Player_Dext;
        float Player_Luck;

        Player_Dext = (float)Player.dexterity / 100 * 10;
        Player_Dext = Mathf.Round(Player_Dext);

        Player_Luck = (float)Player.luck / 100 * 10;
        Player_Luck = Mathf.Round(Player_Luck);


        Player_Hitting = Player_Random;
        Player_Hitting += (int)Player_Dext;
        Player_Hitting += (int)Player_Luck;
        Player_Hitting += Weapon.Precision;


        int Enemy_random = Random.Range(1, 21); ;
        float Enemy_Dext;
        float Enemy_Luck;

        Enemy_Dext = (float)Enemy.dexterity / 100 * 25;
        Enemy_Dext = Mathf.Round(Enemy_Dext);

        Enemy_Luck = (float)Enemy.luck / 100 * 10;
        Enemy_Luck = Mathf.Round(Enemy_Luck);


        Enemy_Hitting = Enemy_random;
        Enemy_Hitting += (int)Enemy_Dext;
        Enemy_Hitting += (int)Enemy_Luck;




        

        if (Enemy_Hitting > Player_Hitting)
        {
            P_Attack.AttackMissed = true;
            TextEffects.Missed();
            Debug.Log("Yuou Missed! Player's value is " + Player_Hitting + "  Enemy value is " + Enemy_Hitting);

            
        }
        if (Enemy_Hitting < Player_Hitting)
        {
            P_Attack.AttackMissed = false;
            Debug.Log("You hit on target! Player's value is " + Player_Hitting + "  Enemy value is " + Enemy_Hitting);

        }

    }

    public void CheckOnBlock()
    {
        if (Enemy.canBlock)
        {
            int Player_Random = Random.Range(1, 21);

            float Player_Dext;
            float Player_Str;
            float Player_Luck;



            Player_Dext = (float)Player.dexterity / 100 * 10;
            Player_Dext = Mathf.Round(Player_Dext);

            Player_Str = (float)Player.strength / 100 * 20;
            Player_Str = Mathf.Round(Player_Str);

            Player_Luck = (float)Player.luck / 100 * 10;
            Player_Luck = Mathf.Round(Player_Luck);


            Player_Hitting = Player_Random;
            Player_Hitting += (int)Player_Dext;
            Player_Hitting += (int)Player_Str;
            Player_Hitting += (int)Player_Luck;
            Player_Hitting += Weapon.blockBreaking;



            int Enemy_random = Random.Range(1, 21); ;

            float Enemy_Dext;
            float Enemy_Str;
            float Enemy_Luck;

            Enemy_Dext = (float)Enemy.dexterity / 100 * 20;
            Enemy_Dext = Mathf.Round(Enemy_Dext);

            Enemy_Str = (float)Enemy.strength / 100 * 10;
            Enemy_Str = Mathf.Round(Enemy_Str);

            Enemy_Luck = (float)Enemy.luck / 100 * 10;
            Enemy_Luck = Mathf.Round(Enemy_Luck);


            Enemy_Blocking = Enemy_random;
            Enemy_Blocking += (int)Enemy_Dext;
            Enemy_Blocking += (int)Enemy_Str;
            Enemy_Blocking += (int)Enemy_Luck;


            if (Enemy_Blocking > Player_Hitting)
            {
                P_Attack.AttackBlocked = true;
                TextEffects.Blocked();
                Debug.Log("Blocked");


            }
             else if (Enemy_Blocking < Player_Hitting)
            {
                P_Attack.AttackBlocked = false;
                Debug.Log("Block Crashed ");

            }

            // need to handle same values
        }
    }

    public void OnNewEnemy(Enemy_Handler _enemy)
    {
        Enemy = _enemy;
    }


}
