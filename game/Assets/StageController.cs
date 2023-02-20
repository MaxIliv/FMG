using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StageType { BATTLE, RESOURCE, REWARD, IDLE, TRAP }

public class StageController : MonoBehaviour
{
    [SerializeField] StageType stageType;
    public StageType Type { get { return stageType; } }
    [SerializeField] public GameState gameState;
    [SerializeField] public Enemy_Handler enemy;
    [SerializeField] public Enemy_Handler Enemy { get { return enemy; } }

    [SerializeField] public GameObject enemyPrefab;
    [SerializeField] public Transform enemySpawnPoint;

    void Awake()
    {
        enemySpawnPoint = gameObject.transform.Find("EnemySpawn");
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Setup()
    {
        // Invoke("StartStage", 1f);
        InitEnemy();
        StartStage();
    }

    public void StartStage()
    {
        Debug.Log("[Stage] Start");

        EventManager.UpdateGameState(gameState);
    }

    public void EndStage()
    {
        Debug.Log("[Stage] End");
        EventManager.UpdateGameState(GameState.IDLE);
    }

    void InitEnemy()
    {
        if (stageType == StageType.BATTLE) {
            GameObject _enemy = Instantiate(enemyPrefab, enemySpawnPoint);
            enemy = _enemy.GetComponent<Enemy_Handler>();
        }
    }
}
