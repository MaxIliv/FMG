using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferencesController : MonoBehaviour
{
    public GameObject _gameMaster;
    public GameObject _player;
    public GameObject _playerWeapon;
    public GameObject _activeArea;
    public GameObject _enemy;




    void Awake()
    {
        _gameMaster = GameObject.FindGameObjectWithTag("GM");
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerWeapon = GameObject.FindGameObjectWithTag("Weapon");
        _activeArea = GameObject.FindGameObjectWithTag("AA");
        _enemy = GameObject.FindGameObjectWithTag("Enemy");


    }



}
