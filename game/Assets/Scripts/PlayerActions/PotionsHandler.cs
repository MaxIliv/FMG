using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionsHandler : MonoBehaviour
{
    [Header("Potion Size")]
    public bool XL;
    public bool L;
    public bool M;
    public bool S;


    [Header("References")]

    public GameObject PLAYER;
    public GameObject GameMaster;

    public EffectManager effects;
    public GameObject thisPotion;
    public Turn_Manager turnManager;
   // public Animator effectAnim;
    public Player_Battle player;
    public Player_HealthBar HB;

    private int _XL;
    private int _L;
    private int _M;
    private int _S;


    
    void Start()
    {
        thisPotion = this.gameObject;
        PLAYER = GameObject.FindGameObjectWithTag("Player");
        GameMaster = GameObject.FindGameObjectWithTag("GM");


        player = PLAYER.GetComponent<Player_Battle>();
        HB = PLAYER.GetComponent<Player_HealthBar>();
        
        turnManager = GameMaster.GetComponent<Turn_Manager>();
        effects = turnManager.GetComponent<EffectManager>();


    }

    // Update is called once per frame
   public void HillHealingPotion_XL()
    {
        if (turnManager.playerTurn)
        {
            if (turnManager.currentActionNumber > 0)
            {
                Percentage();

                effects.healing();
                player.health += _XL;
                if (player.health > player.MaxHealth)
                {
                    player.health = player.MaxHealth;
                }
                HB.SetHealth(player.health);
                turnManager.MakeAction();
                Debug.Log("Player got healing " + _XL);
                Destroy(thisPotion);

            }
        }

    }

    public void HillHealingPotion_L()
    {
        if (turnManager.playerTurn)
        {
            if (turnManager.currentActionNumber > 0)
            {
                Percentage();

   
                effects.healing();
                player.health += _L;

                if (player.health > player.MaxHealth)
                {
                    player.health = player.MaxHealth;
                }

                HB.SetHealth(player.health);
                turnManager.MakeAction();
                Debug.Log("Player got healing " + _L);
                Destroy(thisPotion);
            }
        }
    }

    public void HillHealingPotion_M()
    {
        if (turnManager.playerTurn)
        {
            if (turnManager.currentActionNumber > 0)
            {
                Percentage();

                effects.healing();
                player.health += _M;

                if (player.health > player.MaxHealth)
                {
                    player.health = player.MaxHealth;
                }

                HB.SetHealth(player.health);
                turnManager.MakeAction();
                Debug.Log("Player got healing " + _M);
                Destroy(thisPotion);
            }
        }
    }
    public void HillHealingPotion_S()
    {
        if (turnManager.playerTurn)
        {
            if (turnManager.currentActionNumber > 0)
            {
                Percentage();

                effects.healing();
                player.health += _S;

                if (player.health > player.MaxHealth)
                {
                    player.health = player.MaxHealth;
                }

                HB.SetHealth(player.health);
                turnManager.MakeAction();
                Debug.Log("Player got healing " + _S);
                Destroy(thisPotion);
            }
        }
    }
    public void Percentage()
    {
        if (XL)
        {
            float healingPercentage;

            healingPercentage = (float)player.MaxHealth;
            healingPercentage = healingPercentage / 100 * 100;
            healingPercentage = Mathf.Round(healingPercentage);

            _XL = (int)healingPercentage;
        }

        if (L)
        {
            float healingPercentage;

            healingPercentage = (float)player.MaxHealth;
            healingPercentage = healingPercentage / 100 * 75;
            healingPercentage = Mathf.Round(healingPercentage);

            _L = (int)healingPercentage;
        }

        if (M)
        {
            float healingPercentage;

            healingPercentage = (float)player.MaxHealth;
            healingPercentage = healingPercentage / 100 * 50;
            healingPercentage = Mathf.Round(healingPercentage);

            _M = (int)healingPercentage;
        }

        if (S)
        {
            float healingPercentage;

            healingPercentage = (float)player.MaxHealth;
            healingPercentage = healingPercentage / 100 * 25;
            healingPercentage = Mathf.Round(healingPercentage);

            _S = (int)healingPercentage;
        }

    }
}
