using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColision : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CapsuleCollider playerBody;

    [Header("PlayerSize")]
    public float playerHeight;
    public float playerWidth;

    [Header("Collisions")]
    public LayerMask collideWith;
    public bool enableColision;

    private void Awake()
    {
        playerBody = GetComponent<CapsuleCollider>();
    }

    private void OnDrawGizmos()
    {
        //set Player mensuration
        if(playerBody != null)
        {
            playerBody.enabled = enableColision;
            playerBody.height = playerHeight;
            playerBody.radius = playerWidth;
        }
    }
}
