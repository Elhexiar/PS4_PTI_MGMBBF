using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PuzzleManager : S_Manager
{

    public bool puzzle1IsDone, puzzle2IsDone, puzzle3IsDone, puzzle4IsDone;


    public void FinishPuzzle1()
    {
        // Once the lever in the main scene is trigereed call this function to light up the lamp etc ...
        // ex: S_GeneralManager.GetManagerfromGeneral<S_LightManager>().TurnTheLightsOn

    }

    public void FinishPuzzle2()
    {

    }

    public void FinishPuzzle3()
    {
        // once elevator room cleared of water
    }

    public void FinishPuzzle4()
    {
        // once flag code is found
    }

    public void FinishPuzzle5()
    {
        // once the button is pressed open the doors to the elevator;

    }




}
