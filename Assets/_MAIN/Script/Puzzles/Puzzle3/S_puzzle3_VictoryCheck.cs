using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Puzzle3_VictoryCheck : MonoBehaviour
{
    [SerializeField] private cell cell;

    private void Update()
    {
        if(cell.fillAmmount < 2)
        {
            S_GeneralManager.GetManagerfromGeneral<S_PuzzleManager>().FinishPuzzle3();
            Destroy(this);
        }
    }
}
