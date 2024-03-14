using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_playerRotation : M_Manager
{
    [Header(">> PlayerRotation")]
    public float rotationSpeedGlobal;
    public float rotationSmoothnessGlobal;
    public float maxAngleUp;
    public float maxAngleDown;
    public bool headTilting;
    public bool reverseHeadTilting = true;
    public float headTiltFactor = 8;

    private Transform cameraPos;
    private float targetRotationY;
    private float targetRotationX;
    private bool isMouseLocked = true;
    private float oldTargetRotation;
    private float coordRotation;

    [Header(">> Advanced Rotation Parameter")]
    public float rotationSpeedX;
    public float rotationSpeedY;
    public float rotationSmoothnessX;
    public float rotationSmoothnessY;

    private void Awake()
    {
        cameraPos = transform.GetChild(0);
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // lock mouse cursor
        Cursor.visible = false; // hide cursor

        // set data if needed
        if (rotationSpeedX == 0) { rotationSpeedX = rotationSpeedGlobal; }
        if (rotationSpeedY == 0) { rotationSpeedY = rotationSpeedGlobal; }
        if (rotationSmoothnessX == 0) { rotationSmoothnessX = rotationSmoothnessGlobal; }
        if (rotationSmoothnessY == 0) { rotationSmoothnessY = rotationSmoothnessGlobal; }
    }

    // Update is called once per frame
    void Update()
    {
        if (isMouseLocked)
        {
            // === apply roatation to player ===
            // get input on X axis
            float mouseX = Input.GetAxis("Mouse X");
            // get targeted rotation
            targetRotationY += mouseX * rotationSpeedY * Time.deltaTime;

            // smooth rotation
            float smoothedRotationY = Mathf.LerpAngle(transform.eulerAngles.y, targetRotationY, rotationSmoothnessY * Time.deltaTime);

            // Apply rotation to player
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, smoothedRotationY, transform.eulerAngles.z);


            // === apply roatation to camera ===
            // get input on Y axis
            float mouseY = Input.GetAxis("Mouse Y");

            // get targeted rotation
            targetRotationX -= mouseY * rotationSpeedX * Time.deltaTime;
            targetRotationX = Mathf.Clamp(targetRotationX, -maxAngleDown, maxAngleUp); // limit vertical Rotation

            // smooth rotation
            float smoothedRotationX = Mathf.LerpAngle(cameraPos.eulerAngles.x, targetRotationX, rotationSmoothnessX * Time.deltaTime);

            // Head Tilting 
            float headTilt = transform.eulerAngles.z;
            if (headTilting)
            {
                if (oldTargetRotation != transform.eulerAngles.y) { coordRotation -= oldTargetRotation - transform.eulerAngles.y; oldTargetRotation = transform.eulerAngles.y; } // << PB

                headTilt = targetRotationY - coordRotation; // distance between targeted rotation and actual rotation divided by 
                if (reverseHeadTilting) { headTilt = headTilt * -1; }
                Debug.Log(targetRotationY + " // " + coordRotation);
            }
            // Apply rotation to cam
            cameraPos.eulerAngles = new Vector3(smoothedRotationX, cameraPos.eulerAngles.y, headTilt);
        }
    }
}
