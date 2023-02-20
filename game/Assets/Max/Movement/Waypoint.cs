using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Transform point;
    public Transform Point { get { return point; }}
    [SerializeField] GameObject nextPoint;
    public GameObject NextPoint { get { return nextPoint; }}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
