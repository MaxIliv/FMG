using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    public GameObject destroy_this;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(destroy_this, time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
