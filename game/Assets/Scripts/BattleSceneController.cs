using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneController : MonoBehaviour
{


    public GameObject _gameMaster;
    public GameObject _player;
    public GameObject _playerWeapon;
    public GameObject _activeArea;

    public GameObject activeEnemy;
    public Player_Battle player;

    void Awake()
    {
        _gameMaster = GameObject.FindGameObjectWithTag("GM");
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerWeapon = GameObject.FindGameObjectWithTag("Weapon");
        _activeArea = GameObject.FindGameObjectWithTag("AA");

        // _enemy = GameObject.FindGameObjectWithTag("Enemy");

        // _allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        // player = _player.GetComponent<Player_Battle>(); 

        // foreach (GameObject enemy in _allEnemies)
        // {
        //     enemy.SetActive(false);
        //     allEnemies.Enqueue(enemy);
        // }

       // activeEnemy = allEnemies.Dequeue();
        //activeEnemy.SetActive(true);
    }

    // Update is called once per frame
    public GameObject getActiveEnemy()
    {
        return activeEnemy;
    }

    public bool EnemyCheck()
    {
        return false;
        // return allEnemies.Count > 0;

    }

    public int SortBySceneOrder(GameObject a, GameObject b) //sorter
    {
        var element_1 = a.GetComponent<Stage_Handler>();
        var element_2 = b.GetComponent<Stage_Handler>();

        return element_1.stageOrder.CompareTo(element_2.stageOrder);


    }
}
