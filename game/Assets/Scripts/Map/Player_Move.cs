using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Player_Move : MonoBehaviour
{
    public Animator anim;

    public LayerMask canBeClicked;
    public LayerMask enemy;

    private NavMeshAgent myAgent;
    public Camera cam;

    public GameObject player;
    public GameObject tapEffect;
    public Transform player_pos;






    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        // cam = GetComponent<Camera>();

        player = gameObject;
        player_pos = player.transform;
    }
    public void Move()
    {

    
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray myRay = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(myRay, out hitInfo, enemy))
            {
                Debug.Log("Enememy");
                Instantiate(tapEffect, hitInfo.point, Quaternion.Euler(90,0,0));
            }
        }



        if (Input.GetMouseButtonDown(0))
        {
            Ray myRay = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(myRay, out hitInfo, canBeClicked))
            {
                myAgent.SetDestination(hitInfo.point);
            }
  
        }

        if (myAgent.remainingDistance > myAgent.stoppingDistance)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }

        
        
    }
}
