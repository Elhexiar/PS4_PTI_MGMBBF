using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_PlayerManager : M_Manager
{

    public M_InteractableProp InRangeFocusableProp = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.E)) 
        {

            if(InRangeFocusableProp != null)
            {
                InRangeFocusableProp.Interact();
            }

        }
        
    }



}
