using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class S_InteractableProp : MonoBehaviour
{
    private S_PlayerInteractionManager playerManager;

    private void Awake()
    {
        playerManager = S_GeneralManager.GetManager<S_PlayerInteractionManager>();
    }



    // Every Interactable Prop has a Collider that puts its reference in the PlayerManager so that when he interact with it using the E key,
    // It will have the behaviour of the specific S_Interactable prop Child
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerManager.InRangeFocusableProp = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (playerManager.InRangeFocusableProp == this)
            {
                playerManager.InRangeFocusableProp = null;
            }
        }
    }

    public virtual void Interact()
    {

    }
}
