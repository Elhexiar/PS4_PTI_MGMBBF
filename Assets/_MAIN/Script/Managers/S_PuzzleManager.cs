using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PuzzleManager : S_Manager
{

    public bool puzzle1IsDone, puzzle2IsDone, puzzle3IsDone, puzzle4IsDone, puzzle5IsDone;

    [SerializeField]
    private GameObject  puzzle2UI, puzzle3UI, puzzle5UI;
    [SerializeField]
    private List<GameObject> puzzle4UI;

    [SerializeField]
    private S_InputTerminalMainComputer inputTerminalScript;


    public void FinishPuzzle1()
    {
        Debug.Log("Finished Puzzle 1");
        puzzle1IsDone = true;
        // Once the lever in the main scene is trigereed call this function to light up the lamp etc ...
        // ex: S_GeneralManager.GetManagerfromGeneral<S_LightManager>().TurnTheLightsOn
        puzzle2UI.SetActive(true);
        puzzle5UI.SetActive(true);
        inputTerminalScript.enabled = true;


    }

    public void FinishPuzzle2()
    {
        puzzle2IsDone = true;
        Debug.Log("Finished Puzzle 2");
        puzzle3UI.SetActive(true);

        foreach (var computer in puzzle4UI)
        {
            computer.SetActive(true);
        }

    }

    public void FinishPuzzle3()
    {
        puzzle3IsDone = true;
        Debug.Log("Finished Puzzle 3");

        // once elevator room cleared of water
    }

    public void FinishPuzzle4()
    {
        puzzle4IsDone = true;
        Debug.Log("Finished Puzzle 4");

        // once flag code is found
    }

    public void FinishPuzzle5()
    {
        puzzle5IsDone = true;
        Debug.Log("Finished Puzzle 5");

        
        // once the button is pressed open the doors to the elevator;
        

    }




}
