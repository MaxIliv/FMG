using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public float degreesPerSecond;




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ObjectRotation();

    }




    public void ObjectRotation()
    {

        transform.Rotate(new Vector3(0, degreesPerSecond, 0) * Time.deltaTime);
        
    }
}
