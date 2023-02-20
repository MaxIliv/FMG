using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {
    BATTLE, // When player is in Battle
    IDLE, // Player is Idle
    MOVE // Moving from tile to tile
}

public class GameStateController : MonoBehaviour
{
    [SerializeField] public GameState state;

    void Awake()
    {
    }

    void OnDisable()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        state = GameState.IDLE;
        EventManager.OnGameStateUpdate += HandleGameStateUpdate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HandleGameStateUpdate(GameState _state)
    {
        state = _state;

        switch (state)
        {
            case GameState.MOVE:
                Debug.Log("[Game State] Move");
                break;
            case GameState.BATTLE:
                Debug.Log("[Game State] Battle");
                break;
            case GameState.IDLE:
                Debug.Log("[Game State] Idle");
                break;
        }
    }
}
