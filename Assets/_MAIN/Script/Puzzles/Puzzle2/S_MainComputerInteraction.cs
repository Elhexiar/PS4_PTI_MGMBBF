using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class S_MainComputerInteraction : S_InteractableProp
{
    public CinemachineVirtualCamera virtualCamera;
    public S_InputTerminalMainComputer inputScreen;
    [SerializeField] private bool focused = false;

    public override void Interact()
    {
        if (focused)
        {
            virtualCamera.Priority = 0;
            toggleFreezePlayer(focused);
            focused = false;
            inputScreen.ToggleIsWaitingForInput(false);
        }
        else
        {
            virtualCamera.Priority = 20;
            toggleFreezePlayer(focused);
            focused = true;
            inputScreen.ToggleIsWaitingForInput(true);
        }
    }


    public void toggleFreezePlayer(bool focus)
    {
        if (focus) // UnFreezes the player
        {
            S_GeneralManager.GetManagerfromGeneral<S_PlayerMovementBehaviour>().enabled = true;
            S_GeneralManager.GetManagerfromGeneral<S_PlayerRotationBehaviour>().lockCurs();
        }
        else // Freezes the player and show the cursor
        {
            S_GeneralManager.GetManagerfromGeneral<S_PlayerMovementBehaviour>().Freeze();
            S_GeneralManager.GetManagerfromGeneral<S_PlayerMovementBehaviour>().enabled = false;
            S_GeneralManager.GetManagerfromGeneral<S_PlayerRotationBehaviour>().unlockCurs();
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
