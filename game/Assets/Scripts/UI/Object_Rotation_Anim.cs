using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Rotation_Anim : MonoBehaviour
{

    public GameObject thisObj;


    public float rotationSpeed_x, rotationSpeed_y, rotationSpeed_z;



    // Update is called once per frame
    void Update()
    {
        thisObj.transform.Rotate(Vector3.right, rotationSpeed_x * Time.deltaTime);
        thisObj.transform.Rotate(Vector3.up, rotationSpeed_y * Time.deltaTime);
        thisObj.transform.Rotate(Vector3.back, rotationSpeed_z * Time.deltaTime);

    }
}
