using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//singleton
public class Player : MonoBehaviour
{
    Rigidbody2D _playerRb;
    private Vector2 _currentPosition;
    private Vector2 _newPosition;

    void Awake()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _currentPosition = this.transform.position;
        _newPosition = _currentPosition;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_newPosition != _currentPosition)
        {
            _playerRb.MovePosition(_newPosition);
            _currentPosition = _newPosition;
        }
    }


    public void SetDestination(Vector2 destination)
    {
        _newPosition = destination;
    }

    public void SetDestination(PlayerMapMove point)
    {   
        _newPosition = point.transform.position;
    }
}
