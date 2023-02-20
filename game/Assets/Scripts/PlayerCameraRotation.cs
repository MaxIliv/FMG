using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraRotation : MonoBehaviour
{

    [SerializeField] int minXAngle = -30;
    [SerializeField] int maxXAngle = 30;

    [SerializeField] int minYAngle = -90;
    [SerializeField] int maxYAngle = 90;
    [SerializeField] float xAngle;
    [SerializeField] float yAngle;
    [SerializeField] float xAngleTemp;
    [SerializeField] float yAngleTemp;

    Vector3 firstRotationPoint;
    Vector3 secondRotationPoint;
    public GameObject playerRotationObj;

    // [SerializeField] TileManager tileManager;
    [SerializeField] GameObject GameMaster;

    int HORIZONTAL_RANGE = 180;
    int VERTICAL_RANGE = 90;

    bool needToCenter = false;

    // public Waypoint CurrentWaypoint { get { return tileManager.ActiveWaypoint; } }

    void Awake()
    {
        GameMaster = GameObject.FindGameObjectWithTag("GM");
        // tileManager = GameMaster.GetComponent<TileManager>();
    }

    void Start()
    {
        xAngle = 0;
        yAngle = 0;
        this.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0);
    }

    void Update()
    {
        HandleReset();
        HandleMobileRotation();
         
        // Desktop
        // if (Input.GetMouseButtonDown(0))
        // {
        //     firstRotationPoint = Input.mousePosition;
        //     xAngleTemp = xAngle;
        //     yAngleTemp = yAngle;
        // }
        // if (Input.GetMouseButtonUp(0))
        // {
        //     secondRotationPoint = Input.mousePosition;
        //     xAngle = xAngleTemp + (secondRotationPoint.x - firstRotationPoint.x) * 180 / Screen.width;
        //   //  yAngle = yAngleTemp + (secondRotationPoint.y - firstRotationPoint.y) * 90 / Screen.height;
        //     playerRotationObj.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0.0f);
        // }

    }

    void HandleReset()
    {
        if (needToCenter == false) return;

        // xAngle = CurrentWaypoint.transform.eulerAngles.x;
        // yAngle = CurrentWaypoint.transform.eulerAngles.y;

        // Quaternion targetRotation = Quaternion.Euler(CurrentWaypoint.transform.eulerAngles);
        // playerRotationObj.transform.rotation = Quaternion.Lerp(playerRotationObj.transform.rotation, targetRotation, 4f * Time.deltaTime);
    }

    void HandleMobileRotation()
    {
        if (Input.touchCount <= 0) return;

        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            firstRotationPoint = Input.GetTouch(0).position;
            xAngleTemp = xAngle;
            yAngleTemp = yAngle;
        }

        if (Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            secondRotationPoint = Input.GetTouch(0).position;

            // Define Horizontal rotate
            xAngle = xAngleTemp + (secondRotationPoint.x - firstRotationPoint.x) * HORIZONTAL_RANGE / Screen.width;
            xAngle = Mathf.Clamp (xAngle, minXAngle, maxXAngle);

            // Define Vertical rotate
            yAngle = yAngleTemp + (secondRotationPoint.y - firstRotationPoint.y) * VERTICAL_RANGE / Screen.height;
            yAngle = Mathf.Clamp (yAngle, minYAngle, maxYAngle);
            playerRotationObj.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0.0f);
        }
    }

    public void ResetRotation()
    {
        StartCoroutine(CenterCameraSmooth());
    }

    IEnumerator CenterCameraSmooth()
    {
        needToCenter = true;

        yield return new WaitForSeconds(1f);

        needToCenter = false;
    }
}
