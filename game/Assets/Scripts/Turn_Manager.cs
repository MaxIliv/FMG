using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TurnState { IDLE, START, PLAYER_TURN, ENEMY_TURN, WON, LOST }

public class Turn_Manager : MonoBehaviour
{


    public int turn;
    public int maxActionNumber;
    public int currentActionNumber;

    public int playerInitiativeNumber;
    public int enemyInitiativeNumber;

    public bool playerTurn;

    public int turnCounter; 

    public Image action_1, action_2, action_3, action_4; // star icons, needed for changing the color - active\unactive

    [Header("References")]

    private Checks_Atributes onCheck;
    public LuckyBird Bird;
    public DiceRoll roll;

    public GameObject ActionPanel;
    public Enemy_Handler enemy;
    public Player_Battle player;
    public StageController stage;

    public TurnState state;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Battle>();
    }

    void Start()
    {
        Bird = GetComponent<LuckyBird>();
        onCheck = GetComponent<Checks_Atributes>();

        state = TurnState.IDLE;
    }

    public void StartBattle()
    {
        currentActionNumber = maxActionNumber;
        state = TurnState.START;

        ActionStarColor();
        InitiativeCheck();
        newTurn();
    }

    public void SetEnemy(Enemy_Handler _enemy)
    {
        enemy = _enemy;
    }
    public void SetStage(StageController _stage)
    {
        stage = _stage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void newTurn()
    {
        turn += 1;

        if (state != TurnState.PLAYER_TURN || state != TurnState.ENEMY_TURN) return;


        if (playerTurn)
        {

            PlayerTurn();
        }

        if (!playerTurn)
        {
            EnemyTurn();
        }

    }

    void PlayerTurn()
    {
        onCheck.CheckOnLuck_Player();

        if (player.onLuck > 20)
        {
            currentActionNumber = 4;
            Debug.Log("PLAYER Check of Luck - PASSED  ");

            ActionStarColor();

            Bird.Luck();
        }
        else  if (player.onLuck < 3)
        {
            currentActionNumber = 2;
            Debug.Log("Player Check of Luck - FAILED  ");
            ActionStarColor();

            Bird.Fail();
        }
        else
        {

            ActionStarColor();
            Bird.BirdOff();
        }
    }

    void EnemyTurn()
    {
        onCheck.CheckOnLuck_Enemy();

        if (enemy.onLuck > 20)
        {
            // currentActionNumber = 4;
            Debug.Log("ENEMY Check of Luck - PASSED  ");
            ActionStarColor();

            Bird.Luck();
        }
        else if (enemy.onLuck < 3)
        {
            // currentActionNumber = 2;
            Debug.Log("ENEMY Check of Luck - FAILED  ");
            ActionStarColor();

            Bird.Fail();

        }
        else
        {
            ActionStarColor();
            Bird.BirdOff();
        }
    }

    public void EnemyDied()
    {
        state = TurnState.WON;

        StartCoroutine(Stop());
    }

    public void MakeAction()
    {

        currentActionNumber -= 1;

        ActionStarColor();

        FinishTurn();


    }

    public void FinishTurn()
    {
        if (state != TurnState.PLAYER_TURN || state != TurnState.ENEMY_TURN) return;

        if (currentActionNumber <= 0)
        {
            if (playerTurn)
            {
                playerTurn = false;
                Debug.Log("PLAYER'S TURN FINISHED");
            }
            else if (!playerTurn)
            {
                playerTurn = true;
                Debug.Log("ENEMY'S TURN FINISHED");
            }
            currentActionNumber = maxActionNumber;
            ActionStarColor();

            

        }

    }

    public void InitiativeCheck()
    {
        int playerRoll;
        int enemyRoll;


        //first roll is on Player
        roll.Roll();
        playerRoll = roll.randomValue;
        playerInitiativeNumber = playerRoll + player.initiative;
     //   Debug.Log("Player dice roll is  " + playerRoll + ",  player initiative atribute is  " + player.initiative + ",  so player initiative equal to " + playerInitiativeNumber);

        roll.Roll();
        enemyRoll = roll.randomValue;
        enemyInitiativeNumber = enemyRoll + enemy.initiative;
      //  Debug.Log("Enemy dice roll is  " + enemyRoll + ",  and enemy initiative atribute is  " + enemy.initiative + ",  so - enemy initiative equal to  " + enemyInitiativeNumber);

        if (enemyInitiativeNumber > playerInitiativeNumber)
        {
            playerTurn = false;
            Debug.Log("Enemy makes the first turn");
            state = TurnState.ENEMY_TURN;
        }
        if (enemyInitiativeNumber < playerInitiativeNumber)
        {
            playerTurn = true;
            Debug.Log("Player makes the first turn");
            state = TurnState.PLAYER_TURN;
        }
    }


    //UI view of action counter (Starts on top panel)
    public void ActionStarColor()
    {
        Debug.Log(currentActionNumber);
        if (currentActionNumber == 4)
        {
            action_1.color = new Color32(255, 255, 255, 255);
            action_2.color = new Color32(255, 255, 255, 255);
            action_3.color = new Color32(255, 255, 255, 255);
            action_4.color = new Color32(255, 255, 255, 255);
        }
        if (currentActionNumber == 3)
        {
            action_1.color = new Color32(255, 255, 255, 255);
            action_2.color = new Color32(255, 255, 255, 255);
            action_3.color = new Color32(255, 255, 255, 255);
            action_4.color = new Color32(0, 0, 0, 100);
        }
        if (currentActionNumber == 2)
        {
            action_1.color = new Color32(255, 255, 255, 255);
            action_2.color = new Color32(255, 255, 255, 255);
            action_3.color = new Color32(0, 0, 0, 255);
            action_4.color = new Color32(0, 0, 0, 100);
        }
        if (currentActionNumber == 1)
        {
            action_1.color = new Color32(255, 255, 255, 255);
            action_2.color = new Color32(0, 0, 0, 255);
            action_3.color = new Color32(0, 0, 0, 255);
            action_4.color = new Color32(0, 0, 0, 100);
        }
        if (currentActionNumber == 0)
        {
            action_1.color = new Color32(0, 0, 0, 255);
            action_2.color = new Color32(0, 0, 0, 255);
            action_3.color = new Color32(0, 0, 0, 255);
            action_4.color = new Color32(0, 0, 0, 100);
        }
    }

    IEnumerator Stop()
    {
        state = TurnState.IDLE;
        enemy = null;
        currentActionNumber = 0;
        playerTurn = false;
        ActionStarColor();

        yield return new WaitForSeconds(2f);

        stage.EndStage();
    }
}
