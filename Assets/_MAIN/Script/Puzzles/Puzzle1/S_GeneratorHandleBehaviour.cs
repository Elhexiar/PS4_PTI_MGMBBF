using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_GeneratorHandleBehaviour : S_InteractableProp
{

    public Animator handleAnimator;
    private bool isPowerOn = false;

    public override void Interact()
    {
        if (!isPowerOn)
        {
            handleAnimator.Play("TurningPowerOn");
            isPowerOn = true;
            S_GeneralManager.GetManagerfromGeneral<S_PuzzleManager>().FinishPuzzle1();
        }
    }

    public bool getIsPowerOn()
    {
        return isPowerOn;
    }

}
