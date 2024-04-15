using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_EndingGameButton : S_InteractableProp
{
    [SerializeField]
    private AudioSource powerlessButtonSound;
    public override void Interact()
    {
        if(S_GeneralManager.GetManagerfromGeneral<S_PuzzleManager>().puzzle5IsDone
        && S_GeneralManager.GetManagerfromGeneral<S_PuzzleManager>().puzzle4IsDone
        && S_GeneralManager.GetManagerfromGeneral<S_PuzzleManager>().puzzle3IsDone)
        {
            SceneManager.LoadScene("SC_VictoryScene");
        }
        else
        {
            powerlessButtonSound.Play();
        }
    }

}
