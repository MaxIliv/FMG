using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class tap_handler : MonoBehaviour
{
    public GameObject _touchEfffect;

    public Camera camera;




    private Vector2 _mousePosition;


    void Awake()
    {
        //camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Start()
    {

        camera = Camera.main;

    }


     void Update()
    {

        /*
            if (Input.GetMouseButtonDown(0))
            {


                Ray ray = camera.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray, out RaycastHit raycastHit))
                    {
              

                        Instantiate(_touchEfffect, raycastHit.point, Quaternion.identity);

                    }
            }
        */


        // this should work for mobile only (I did not test it)
        /* if (Input.touchCount > 0 )
         {
             // accessing the first touch on the screen |||| TouchPhhase is action we can make on the screen Start\Move\Release
             if (Input.touches[0].phase == TouchPhase.Began)    
             {
                 Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                 RaycastHit hit;

                 if (Physics.Raycast(ray, out hit ))
                 {
                     if (hit.collider != null )
                     {

                         Color color =  new Color(10, 10, 10);
                         hit.collider.gameObject.GetComponent<MeshRenderer>().material.color = color;


                     }


                 }
             }
         }*/






    }

    public void touch_effect()
    {



    }




}
