using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class S_BlastDoor : S_InteractableProp
{
    public CinemachineVirtualCamera virtualCamera;
    [SerializeField] private bool focused = false;

    public override void Interact()
    {

        // TODO : Refactoriser
        
        if (focused)
        {
            virtualCamera.Priority = 0;
            focused = false;

            S_GeneralManager.GetManagerfromGeneral<S_PlayerMovementBehaviour>().enabled = true;
            S_GeneralManager.GetManagerfromGeneral<S_PlayerRotationBehaviour>().lockCurs();
            
        }
        else
        {
            S_GeneralManager.GetManagerfromGeneral<S_PlayerMovementBehaviour>().Freeze();
            S_GeneralManager.GetManagerfromGeneral<S_PlayerMovementBehaviour>().enabled = false;
            S_GeneralManager.GetManagerfromGeneral<S_PlayerRotationBehaviour>().unlockCurs();
            Cursor.lockState = CursorLockMode.Confined;

            virtualCamera.Priority = 20;
            focused = true;
        }
        

    }
}