using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ElevatorButtonBehaviour : S_InteractableProp
{

    private bool boxPuzzleIsSolved = false;
    public Animator elevatorAnimator;

    public override void Interact()
    {

        if (boxPuzzleIsSolved)
        {
            elevatorAnimator.Play("OpenElevatorDoors");
            S_GeneralManager.GetManagerfromGeneral<S_PuzzleManager>().FinishPuzzle5();
        }
        else
        {
            Debug.Log("Vas faire la boite dans le couloir");
        }


    }

    public void setBoxPuzzleIsSolved(bool state)
    {
        boxPuzzleIsSolved = state;
    }

}
