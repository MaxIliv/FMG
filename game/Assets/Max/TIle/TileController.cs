using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This file is for generating Tile objects

public class TileController : MonoBehaviour
{
    [SerializeField] List<Transform> objectSpawnPoints = new List<Transform>();
    [SerializeField] List<GameObject> objectOnSpawnPoint = new List<GameObject>();
    [SerializeField] List<GameObject> objects = new List<GameObject>();

    public int index;

    void Awake()
    {
        CollectSpawnPoints();

    }

    void Start()
    {
        InstantiateObjects(); 
    }

    void CollectSpawnPoints()
    {
        objectSpawnPoints.Clear();

        Transform parent = gameObject.transform.Find("Objects");

        foreach(Transform child in parent.transform)
        {
            if (child != null)
            {
                objectSpawnPoints.Add(child);
            }
        }
    }

    void InstantiateObjects()
    {
        for(int i = 0; i < objectSpawnPoints.Count; i++)
        {
            // objects.Add(Instantiate(objectOnSpawnPoint[i], objectSpawnPoints[i]));

            // define random object from the list
            index = Random.Range(0, objectOnSpawnPoint.Count);

            //instantiate random object in the list
            objects.Add(Instantiate(objectOnSpawnPoint[index], objectSpawnPoints[i]));
        }
    }
}
