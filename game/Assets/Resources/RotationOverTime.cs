using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationOverTime : MonoBehaviour
{

    public float RotationSpeed = 2.0f;


    void Update()
    {
        transform.Rotate(Vector3.up * (RotationSpeed * Time.deltaTime));
    }
}
