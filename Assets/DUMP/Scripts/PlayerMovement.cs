using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header(">> References")]
    [SerializeField] Rigidbody rb;

    [Header(">> Inputs")]
    public KeyCode forward = KeyCode.W;
    public KeyCode backward = KeyCode.S;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;

    [Header(">> PlayerMovement")]
    public float maxSpeed;
    [Range(0f,1f)]public float acceleration , deceleration;
    public float friction;

    float currentSpeed;
    bool moving;
    float VectorX;
    float VectorZ;

   

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }



    private void Update()
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
}
