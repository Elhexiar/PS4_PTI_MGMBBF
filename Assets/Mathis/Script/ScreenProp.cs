using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScreenProp : FocusableProp
{

    public  CinemachineVirtualCamera virtualCamera;
    [SerializeField] private bool focused = false;

    public override void Interact()
    {
        if (focused)
        {
            virtualCamera.Priority = 0;
            focused = false;
        }
        else
        {
            virtualCamera.Priority = 20;
            focused = true;
        }
        
    }

}
