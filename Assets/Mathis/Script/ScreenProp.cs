using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScreenProp : M_InteractableProp
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

        }
        else
        {
            M_GeneralManager.GetManager<M_PlayerMovement>().Freeze();
            M_GeneralManager.GetManager<M_PlayerMovement>().enabled = false;
            virtualCamera.Priority = 20;
            focused = true;
        }
        
    }

}
