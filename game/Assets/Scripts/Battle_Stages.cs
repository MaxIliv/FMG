using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_Stages : MonoBehaviour
{
    public Animator moveAnim;
    public BattleSceneController BSC;
    private GameObject Player;

    public Player_Battle player;
    public PlayerAttack player_attack;

    [SerializeField] StageController activeStage;
    [SerializeField] Turn_Manager TM;
    [SerializeField] TileManager tileManager;
    [SerializeField] GameObject GameMaster;
    

    public int stage = 0;
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        GameMaster = GameObject.FindGameObjectWithTag("GM");
        tileManager = GameMaster.GetComponent<TileManager>();
    }

    void Start()
    {
        BSC = GetComponent<BattleSceneController>();
        TM = GetComponent<Turn_Manager>();

        player = Player.GetComponent<Player_Battle>();
        player_attack  = Player.GetComponent<PlayerAttack>();

        UpdateStage();
        UpdateEnemy();
    }

    void OnEnable()
    {
        EventManager.OnNextTile += NextTile;
    }

    void OnDisable()
    {
        EventManager.OnNextTile -= NextTile;
    }

    public void NextTile()
    {
        Debug.Log("NEXT Tile");
        EventManager.UpdateGameState(GameState.MOVE);

        UpdateStage();
        UpdateEnemy();
    }

    // Update Enemy for all components
    void UpdateEnemy()
    {
        if (activeStage.Type == StageType.BATTLE) {
            Debug.Log(activeStage.Enemy);
            EventManager.TriggerNewEnemy(activeStage.Enemy);
            player.UpdateEnemy(activeStage.Enemy);
            TM.SetStage(activeStage);
            TM.SetEnemy(activeStage.Enemy);
            TM.StartBattle();
        }
    }

    void UpdateStage()
    {
        activeStage = tileManager.ActiveStage;
        activeStage.Setup();
    }
}
