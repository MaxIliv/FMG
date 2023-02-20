using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveBattle : MonoBehaviour
{
    [Header("Camera Path")]
    [SerializeField] public Waypoint currentPoint;    

    [Header("Movement Settings")]
    [SerializeField] [Range(0f, 5f)] public float moveTime = 0.5f;
    [SerializeField] [Range(0f, 20f)] public float moveSpeed = 10f;
    [SerializeField] [Range(0f, 10f)] float rotateSpeed = 2f;

    [SerializeField] GameObject GameMaster;
    [SerializeField] public TileManager tileManager;

    Vector3 velocity;
    float turnSmoothVelocity;

    void Awake()
    {
        GameMaster = GameObject.FindGameObjectWithTag("GM");
        tileManager = GameMaster.GetComponent<TileManager>();
    }

    void Start()
    {
        NextTile();
    }

    void OnEnable() {
        EventManager.OnNextTile += NextTile;
    }

    void OnDisable() {
        EventManager.OnNextTile -= NextTile;
    }


    void Update()
    {
        if (currentPoint)
        {
            transform.position = Vector3.SmoothDamp(transform.position, currentPoint.transform.position, ref velocity, moveTime, moveSpeed);

            Quaternion targetRotation = Quaternion.Euler(currentPoint.transform.eulerAngles);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

        }
    }

    public void NextTile()
    {
        currentPoint = tileManager.ActiveWaypoint;
    }
}
