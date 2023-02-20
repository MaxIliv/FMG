using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_Map : MonoBehaviour
{
    public string sceneName;

    public GameObject player;

    public float distance;
    public float action_distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log(hit.transform.gameObject.name);
                if (hit.collider.gameObject.CompareTag("Enemy"))
                {
                    Debug.Log("You cklicked on Enemy");

                    if (distance <= action_distance)
                    {
                        SceneManager.LoadScene(sceneName);
                    }
                    

                    
                }
            }
        }


        }
}
