using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class S_BlastDoor : S_InteractableProp
{
    public CinemachineVirtualCamera virtualCamera;
    [SerializeField]
    private S_BlastDoorLogic blastDoorLogic;
    [SerializeField] private bool focused = false;

    public override void Interact()
    {

        // TODO : Refactoriser
        
        if (focused)
        {
            virtualCamera.Priority = 0;
            toggleFreezePlayer(focused);
            focused = false;
            if (blastDoorLogic.cogInHand)
            {
                blastDoorLogic.TopCogPicked();
            }
        }
        else
        {
            virtualCamera.Priority = 20;
            toggleFreezePlayer(focused);
            focused = true;
        }
    }


    public void toggleFreezePlayer(bool focus)
    {
        if (focus) // UnFreeze the player
        {
            S_GeneralManager.GetManagerfromGeneral<S_PlayerMovementBehaviour>().enabled = true;
            S_GeneralManager.GetManagerfromGeneral<S_PlayerRotationBehaviour>().lockCurs();
        }
        else // Freeze the player and show the cursor
        {
            S_GeneralManager.GetManagerfromGeneral<S_PlayerMovementBehaviour>().Freeze();
            S_GeneralManager.GetManagerfromGeneral<S_PlayerMovementBehaviour>().enabled = false;
            S_GeneralManager.GetManagerfromGeneral<S_PlayerRotationBehaviour>().unlockCurs();
            Cursor.lockState = CursorLockMode.Confined;
        }
    }


}
