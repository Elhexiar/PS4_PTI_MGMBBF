using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerInteractionManager : S_Manager
{
    public S_InteractableProp InRangeFocusableProp = null;
    void Start()
    {

    }

    void Update()
    {
        // if an InteractibleProp is nearby the player can press E to interact with it
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (InRangeFocusableProp != null)
            {
                InRangeFocusableProp.Interact();
            }
        }
    }
}
