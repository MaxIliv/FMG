using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestActivator : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject questPanel;
    [Space]

    public string tagName;

    [Space]

    public string sceneName;
    void Start()
    {
        
    }

    // Update is called once per frame
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
        questPanel.SetActive(true);
    }

    public void loadLevel()
    {
        SceneManager.LoadScene(sceneName);
    }
}
