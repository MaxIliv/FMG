using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using UnityEngine.UIElements;

public class PlayerMapMove : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clicked");
        player.SetDestination(this);
    }

    public Player player;

    void Start()
    {
    }

    private void MouseClick()
    {
        player.SetDestination(this);
    }

    void OnMouseDown()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        player.SetDestination(this);
        Debug.Log("OnPointerClick called.");
    }
}
