using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BlastDoorPuzzle : M_InteractableProp
{

    public  CinemachineVirtualCamera virtualCamera;
    [SerializeField] private bool focused = false;

    public override void Interact()
    {
        if (focused)
        {
            virtualCamera.Priority = 0;
            focused = false;
            
            M_GeneralManager.GetManager<M_PlayerMovement>().enabled = true;
            M_GeneralManager.GetManager<M_playerRotation>().lockCurs();

        }
        else
        {
            M_GeneralManager.GetManager<M_PlayerMovement>().Freeze();
            M_GeneralManager.GetManager<M_PlayerMovement>().enabled = false;
            M_GeneralManager.GetManager<M_playerRotation>().unlockCurs();
            Cursor.lockState = CursorLockMode.Confined;

            virtualCamera.Priority = 20;
            focused = true;
        }
        
    }

}
