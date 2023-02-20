using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField]
    public Waypoint waypoint;
    public Waypoint Waypoint { get { return waypoint; } }

    [SerializeField]
    public StageController stageController;
    public StageController StageController { get { return stageController; } }

    // Start is called before the first frame update
    void Start()
    {
        stageController = GetComponent<StageController>();
        waypoint = transform.Find("Waypoint").GetComponent<Waypoint>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
