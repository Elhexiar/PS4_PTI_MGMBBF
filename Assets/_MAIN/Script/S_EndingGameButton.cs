using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_EndingGameButton : S_InteractableProp
{
    public override void Interact()
    {
        if(S_GeneralManager.GetManagerfromGeneral<S_PuzzleManager>().puzzle5IsDone 
        && S_GeneralManager.GetManagerfromGeneral<S_PuzzleManager>().puzzle3IsDone)
        {
            SceneManager.LoadScene("SC_VictoryScene");
        }
    }

}
