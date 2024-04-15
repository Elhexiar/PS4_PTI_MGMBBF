using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_InspectableObject1 : S_InteractableProp
{

    public GameObject referencedUIGameObject;

    [SerializeField]
    private AudioSource pickupSound;
    public override void Interact()
    {


        if (S_GeneralManager.GetManagerfromGeneral<S_InspectionWindowsManager>().inspecEnabled == false)
        {
            // open Inspection window
            pickupSound.Play();

            S_GeneralManager.GetManagerfromGeneral<S_PlayerMovementBehaviour>().Freeze();
            S_GeneralManager.GetManagerfromGeneral<S_PlayerMovementBehaviour>().enabled = false;

            S_GeneralManager.GetManagerfromGeneral<S_InspectionWindowsManager>().objectToInspect = referencedUIGameObject;
            S_GeneralManager.GetManagerfromGeneral<S_InspectionWindowsManager>().objectToInspect.SetActive(true);
            S_GeneralManager.GetManagerfromGeneral<S_InspectionWindowsManager>().inspecEnabled = true;
            S_GeneralManager.GetManagerfromGeneral<S_PlayerRotationBehaviour>().isMouseUnlocked = false;


            S_GeneralManager.GetManagerfromGeneral<S_InspectionWindowsManager>().inspecEnabled = true;
            S_GeneralManager.GetManagerfromGeneral<S_InspectionWindowsManager>().SetPanelState(true);
        }
        else
        {

            // close Inspection window
            S_GeneralManager.GetManagerfromGeneral<S_PlayerMovementBehaviour>().enabled = true;

            S_GeneralManager.GetManagerfromGeneral<S_InspectionWindowsManager>().objectToInspect.SetActive(false);
            S_GeneralManager.GetManagerfromGeneral<S_InspectionWindowsManager>().inspecEnabled = false;
            S_GeneralManager.GetManagerfromGeneral<S_PlayerRotationBehaviour>().isMouseUnlocked = true;


            S_GeneralManager.GetManagerfromGeneral<S_InspectionWindowsManager>().inspecEnabled = false;
            S_GeneralManager.GetManagerfromGeneral<S_InspectionWindowsManager>().SetPanelState(false);

        }

    }


}
