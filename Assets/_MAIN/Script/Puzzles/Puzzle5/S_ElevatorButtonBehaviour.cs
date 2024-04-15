using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ElevatorButtonBehaviour : S_InteractableProp
{

    private bool boxPuzzleIsSolved = false;

    [SerializeField]
    private AudioSource doorSound, powerlessButtonSound;

    public Animator elevatorAnimator;

    public override void Interact()
    {

        if (boxPuzzleIsSolved && !S_GeneralManager.GetManagerfromGeneral<S_PuzzleManager>().puzzle5IsDone)
        {
            elevatorAnimator.Play("OpenElevatorDoors");
            doorSound.Play();
            S_GeneralManager.GetManagerfromGeneral<S_PuzzleManager>().FinishPuzzle5();
        }
        else
        {
            powerlessButtonSound.Play();
            Debug.Log("Vas faire la boite dans le couloir");
        }


    }

    public void setBoxPuzzleIsSolved(bool state)
    {
        boxPuzzleIsSolved = state;
    }

}
