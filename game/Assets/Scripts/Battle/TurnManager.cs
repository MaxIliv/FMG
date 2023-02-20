using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RPG.Battle;
using RPG.Control;

/*
  This file contains logic for Turn Based Battle

  // Battle - sequence of character TURNs
  // TURN - character turn.
  // ACTION - one action during TURN. Few actions per TURN
*/

// Battle States
public enum BattleState {
  UNDEFINED, // - initial
  IDLE, // - No Battle
  START, // - Battle Init
  PLAYER_TURN, // - Player Turn
  ENEMY_TURN, // - Enemy Turn
  WON, // - When Player Won
  LOST, // - When Player Lost
}

public class TurnManager : MonoBehaviour {
  GameObject player;
  [SerializeField] GameObject enemy;

  [SerializeField] Color32 ACTIVE_COLOR = new Color32(255, 255, 255, 255);
  [SerializeField] Color32 INACTIVE_COLOR = new Color32(0, 0, 0, 100);
  [SerializeField] int maxActionPointsTreshold = 20; // How many points needed to upgrade to 4 Action Points
  [SerializeField] int actionPointsTreshold2 = 3; // How many points needed to downgrade to 2 Action Points
  [SerializeField] List<Image> actionPointImages = new List<Image>(); // Images of Action Points Indication UI

  // Refs
  public LuckyBird luckyBird;
  public BattleState state;
  private GameObject GameMaster;
  public Text_Effects TextEffects;

  int maxActionNumber;
  public int currentActionNumber;
  public int iteration = 0;

  void Awake()
  {
    player = GameObject.FindGameObjectWithTag("Player");
    luckyBird = GetComponent<LuckyBird>();
    GameMaster = GameObject.FindGameObjectWithTag("GM");
    TextEffects = GameMaster.GetComponent<Text_Effects>();
  }

  void Start()
  {
    state = BattleState.IDLE;
    maxActionNumber = actionPointImages.Count;
    currentActionNumber = maxActionNumber;

    SetupBattle();
    DisplayActionPointsUI();
    InitiativeCheck();
    NewTurn(state);
  }

  /*
   * Setup battle between characters
  */
  void SetupBattle()
  {
    Fighter playerController = player.GetComponent<Fighter>();
    Fighter enemyController = enemy.GetComponent<Fighter>();

    playerController.Attack(enemy);
    enemyController.Attack(player);
  }

  // show on UI how many action points character has
  void DisplayActionPointsUI()
  {
    for (int i = 0; i < actionPointImages.Count; i++)
    {
      Image actionImage = actionPointImages[i];

      Color32 color = currentActionNumber > i ? ACTIVE_COLOR : INACTIVE_COLOR;
      actionImage.color = color;
    }
  }

  // check who will start battle first
  void InitiativeCheck()
  {
    BattleChecks playerChecks = player.GetComponent<BattleChecks>();
    BattleChecks enemyChecks = enemy.GetComponent<BattleChecks>();

    float playerPoints = playerChecks.InitiativePoints();
    float enemyPoints = enemyChecks.InitiativePoints();

    Debug.Log($"[TM][InitiativeCheck] P {playerPoints} and E {enemyPoints}");

    if (playerPoints >= enemyPoints) {
      state = BattleState.PLAYER_TURN;
      Debug.Log("Player makes the first turn");
    } else {
      state = BattleState.ENEMY_TURN;
      Debug.Log("Enemy makes the first turn");
    }
  }

  /*
    New Character Turn
    Defines who makes turn
  */
  void NewTurn(BattleState newState)
  {
    iteration++;

    if (newState == BattleState.PLAYER_TURN) {
      CharacterTurn(player);
      Debug.Log("Player Turn");
    }

    if (newState == BattleState.ENEMY_TURN)
    {
      CharacterTurn(enemy);
      Debug.Log("Enemy Turn");
    }
  }

  IEnumerator ProcessNewTurn(BattleState nextState)
  {
    yield return new WaitForSeconds(1f);

    NewTurn(nextState);

    yield return new WaitForSeconds(3f);

    state = nextState;
  }

  // Character Callback after Action
  public void MakeAction()
  {
    currentActionNumber -= 1;
    DisplayActionPointsUI();
    FinishTurn();
  }

  // Defines start of next character turn
  void CharacterTurn(GameObject character)
  {
    currentActionNumber = maxActionNumber - 1;

    BattleChecks characterChecks = character.GetComponent<BattleChecks>();
    double luckPoints = characterChecks.TurnLuckPoints();

    if ((int)luckPoints > maxActionPointsTreshold)
    {
      Debug.Log("Check of Luck - PASSED");

      currentActionNumber = maxActionNumber;
      // Bird.Luck();
    }
    else if (luckPoints < actionPointsTreshold2)
    {
      Debug.Log("Check of Luck - FAILED");

      currentActionNumber = 2;
      // Bird.Fail();
    }

    DisplayActionPointsUI();
  }

  // Finish Turn Check
  void FinishTurn()
  {
    if (currentActionNumber > 0) return;

    BattleState currentState = state;
    BattleState nextState = BattleState.UNDEFINED;

    state = BattleState.IDLE;

    if (currentState == BattleState.PLAYER_TURN)
    {
      Debug.Log("PLAYER'S TURN FINISHED");
      nextState = BattleState.ENEMY_TURN;
    }
    else if (currentState == BattleState.ENEMY_TURN)
    {
      Debug.Log("ENEMY'S TURN FINISHED");
      nextState = BattleState.PLAYER_TURN;
    }

    StartCoroutine(ProcessNewTurn(nextState));
  }

  // Callback for when character Die
  public void OnCharacterDie(GameObject character)
  {
    if (character == player) state = BattleState.LOST;
    if (character == enemy) state = BattleState.WON;

    TextEffects.Show(state);

    StartCoroutine(StopBattle());
  }

  /*
    Process Battle Stopage
  */
  IEnumerator StopBattle()
  {
    yield return new WaitForSeconds(2f);
    state = BattleState.IDLE;

    player.GetComponent<BattleCharacter>().StopBattle();
    enemy.GetComponent<BattleCharacter>().StopBattle();

    // stage.EndStage(); // TODO 
  }
}