using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateInteractionMenu : MonoBehaviour
{
   

    [Header("optionsUI")]
    public GameObject options;



    private Camera mainCamera;


    public void Awake()
    {
        mainCamera = Camera.main;
    }

    void Start()
    {


    }


    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                if (raycastHit.collider.gameObject.CompareTag("Interactive"))
                {
                    Debug.Log("Interacted with " + raycastHit.collider.gameObject.name);
                    ShowOptions();

                }
            }
        }
    }

    public void ShowOptions()
    {

        if (!options.activeSelf)
        {
            options.SetActive(true);
        }
        else
        {
            options.SetActive(false);
        }




    }
}
