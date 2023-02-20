using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static Action OnNextTile;

    public static void NextTile()
    {
        OnNextTile?.Invoke();
    }

    public static Action<GameState> OnGameStateUpdate;

    public static void UpdateGameState(GameState state)
    {
        OnGameStateUpdate?.Invoke(state);
    }

    public static Action<Enemy_Handler> OnNewEnemy;

    public static void TriggerNewEnemy(Enemy_Handler _enemy)
    {
        OnNewEnemy?.Invoke(_enemy);
    }
}
