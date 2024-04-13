using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armoire : MonoBehaviour
{
    [SerializeField] private BoxCollider bcl;
    private bool moving;

    private void OnCollisionStay(Collision collision)
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Space))
        {
            moving = true;
        }

    }

    private void Update()
    {
        if(moving&& transform.position.z < 2.43f )
        {
            transform.position = new Vector3(transform.position.x,transform.position.y,Mathf.Lerp(transform.position.z,2.6f,0.01f));
        }
        else if (transform.position.z >= 2.43f)
        {
            Destroy(this);
        }

    }
}
