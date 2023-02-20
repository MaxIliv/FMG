using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnChestOpening : MonoBehaviour
{
    private Camera camera;
    public Animator anim;
    public GameObject chest1, chest2;

    public Material newMat;



    void Start()
    {

        camera = Camera.main;






    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {


            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                

                if (raycastHit.collider.gameObject.CompareTag ("Chest"))
                {
                    raycastHit.collider.gameObject.GetComponent<OnChestOpening>().openChest();
                }
                

                }



               /* if (gameObject.CompareTag("Interactive"))
                {


                    chest1.GetComponent<MeshRenderer>().material = newMat;
                    chest2.GetComponent<MeshRenderer>().material = newMat;
                    anim.SetBool("Opened", true);

                }*/

            }
        }

    public void openChest()
    {


        chest1.GetComponent<MeshRenderer>().material = newMat;
        chest2.GetComponent<MeshRenderer>().material = newMat;
        anim.SetBool("Opened", true);

    }

}

