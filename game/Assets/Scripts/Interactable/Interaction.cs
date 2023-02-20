using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public string tagName;

    public GameObject torchLight;

    public ActivateInteractionMenu activation;


    [Header("References")]
    public Camera mainCamera;
  

    public void Awake()
    {
        mainCamera = Camera.main;
    }

    void Start()
    {
        activation = GetComponentInParent<ActivateInteractionMenu>();
        
    }


    void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                    if (raycastHit.collider.gameObject.CompareTag(tagName))
                    {
                        Debug.Log("Interacted with " + raycastHit.collider.gameObject.name);
                    Action();
                    }             
            }
        }
    }

    public void Action()
    {
        Debug.Log("Action was made");
        if (torchLight.activeSelf)
        {
            torchLight.SetActive(false);
        }
        else
        {
            torchLight.SetActive(true);
        }
        activation.ShowOptions();


    }

}
