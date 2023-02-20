using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] public GameObject target;
    [SerializeField] public GameObject currentPoint;
    [SerializeField] public Transform movePoint;
    [SerializeField] public bool isMoving = false;
    
    [Header("Movement Settings")]
    [SerializeField] [Range(0f, 5f)] public float moveTime = 0.5f;
    [SerializeField] [Range(0f, 20f)] public float moveSpeed = 10f;
    [SerializeField] [Range(0f, 10f)] float rotateSpeed = 2f;

    Vector3 velocity;
    float turnSmoothVelocity;

    // Update is called once per frame
    void Update()
    {
        if (currentPoint && isMoving)
        {
            transform.position = Vector3.SmoothDamp(transform.position, movePoint.position, ref velocity, moveTime, moveSpeed);

            // it will always try to rotate in currentPoint angles
            // Quaternion targetRotation = Quaternion.Euler(movePoint.eulerAngles);
            // transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
            
            Vector3 distanceToWalkPoint = transform.position - movePoint.position;

            if (distanceToWalkPoint.magnitude <= 0.01f) {
                isMoving = false;
            }
        }
    }

    public void SetTarget(GameObject _target)
    {
        target = _target;
    }

    public void Move()
    {
        if (isMoving) return;

        if (!target) {
            // try to check for nextPoint from currentPoint
            GameObject nextPoint = currentPoint.GetComponent<Waypoint>().NextPoint;

            if (nextPoint) {
                target = nextPoint;
            }
        }

        if (!target) return;

        currentPoint = target;
        movePoint = currentPoint.GetComponent<Waypoint>().Point;
        isMoving = true;
    }
}
