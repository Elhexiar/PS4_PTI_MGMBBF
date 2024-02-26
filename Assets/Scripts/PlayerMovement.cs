using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header(">> References")]
    [SerializeField] Rigidbody rb;

    [Header(">> Inputs")]
    public KeyCode forward;
    public KeyCode backward;
    public KeyCode left;
    public KeyCode right;

    [Header(">> PlayerMovement")]
    public float maxSpeed;
    [Range(0f,1f)]public float acceleration , deceleration;
    public float friction;

    float currentSpeed;
    bool moving;
    float VectorX;
    float VectorZ;

    [Header(">> PlayerRotation")]
    public float rotationSpeedGlobal;
    public float rotationSmoothnessGlobal;
    public float maxAngleUp;
    public float maxAngleDown;
    public bool headTilting;

    private Transform cameraPos;
    private float targetRotationY;
    private float targetRotationX;
    private bool isMouseLocked = true;

    [Header(">> Advanced Rotation Parameter")]
    public float rotationSpeedX;
    public float rotationSpeedY;
    public float rotationSmoothnessX;
    public float rotationSmoothnessY;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
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

    private void Update()
    {
        Movement();
        Rotation();
    }

    // === horizontal movement ===
    private void Movement()
    {
        // movement on global X axis 
        if (Input.GetKey(forward) && VectorX < maxSpeed) { VectorX += acceleration; } // move forward
        else if (Input.GetKey(backward) && VectorX > -maxSpeed) { VectorX -= acceleration; } // move backward
        else if (!Input.GetKey(forward) && !Input.GetKey(backward))
        { VectorX = Mathf.Lerp(0, VectorX, 1 - deceleration); } // if idle input on x axis , slow down on this axis

        // movement on global Z axis 
        if (Input.GetKey(right) && VectorZ < maxSpeed) { VectorZ += acceleration; } // move to the right
        else if (Input.GetKey(left) && VectorZ > -maxSpeed) { VectorZ -= acceleration; } // move to the left
        else if (!Input.GetKey(right) && !Input.GetKey(left))
        { VectorZ = Mathf.Lerp(0, VectorZ, 1 - deceleration); } // if idle input on z axis , slow down on this axis

        // check for movement 
        if (VectorX != 0 || VectorZ != 0) { moving = true; }
        else { moving = false; }

        // friction 
        //decelerate when max speed is reach to not get stuck on an axis
        if (VectorX > maxSpeed || VectorX < -maxSpeed) { VectorX -= Mathf.Lerp(0, VectorX, friction / 10); }
        if (VectorZ > maxSpeed || VectorZ < -maxSpeed) { VectorZ -= Mathf.Lerp(0, VectorZ, friction / 10); }

        // apply movement 
        rb.velocity = (transform.TransformDirection(new Vector3(VectorZ, 0, VectorX)));
    }

    private void Rotation()
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

            // Apply rotation to cam
            cameraPos.eulerAngles = new Vector3(smoothedRotationX, smoothedRotationY, cameraPos.eulerAngles.z);
        }
    }
}
