using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class S_InspectableObject : S_InteractableProp
{
    public GameObject inspectionWindowRef;

    private S_PlayerMovementBehaviour playerMovementBehaviour;
    private S_PlayerRotationBehaviour playerRotationBehaviour;
    private S_InspectionWindowsManager inspectionWindowsManager;
    private void Start()
    {

        // caching (?) the references to the managers instead of having to call the GetManager() function everywhere

        playerMovementBehaviour = S_GeneralManager.GetManager<S_PlayerMovementBehaviour>();
        playerRotationBehaviour = S_GeneralManager.GetManager<S_PlayerRotationBehaviour>();
        inspectionWindowsManager = S_GeneralManager.GetManager<S_InspectionWindowsManager>();

        //inspectionWindowRef = inspectionWindowsManager.uiRef;


    }

    public override void Interact()
    {


        if (M_GeneralManager.GetManager<M_InspectionWindowManager>().InspecEnabled == false)
        {
            // open Inspection window
            M_GeneralManager.GetManager<M_PlayerMovement>().Freeze();
            M_GeneralManager.GetManager<M_PlayerMovement>().enabled = false;

            M_GeneralManager.GetManager<M_InspectionWindowManager>().objectToInspect.SetActive(true);
            M_GeneralManager.GetManager<M_InspectionWindowManager>().InspecEnabled = true;
            M_GeneralManager.GetManager<M_playerRotation>().isMouseUnlocked = false;

            inspectionWindowRef.SetActive(true);
            M_GeneralManager.GetManager<M_InspectionWindowManager>().InspecEnabled = true;
        }
        else
        {

            // close Inspection window
            M_GeneralManager.GetManager<M_PlayerMovement>().enabled = true;

            M_GeneralManager.GetManager<M_InspectionWindowManager>().objectToInspect.SetActive(false);
            M_GeneralManager.GetManager<M_InspectionWindowManager>().InspecEnabled = false;
            M_GeneralManager.GetManager<M_playerRotation>().isMouseUnlocked = true;

            inspectionWindowRef.SetActive(false);

            M_GeneralManager.GetManager<M_InspectionWindowManager>().InspecEnabled = false;
        }

    }
}
}
*/