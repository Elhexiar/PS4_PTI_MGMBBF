using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrdinateurDrap : MonoBehaviour
{
    [SerializeField] private int Selection;
    [SerializeField] private int flagAmmount;
    
    public void NextFlag()
    {
        if (Selection < flagAmmount) { Selection++; }
        else { Selection = 0; }
    }

    public void PreviousFlag()
    {
        if (Selection > 0) { Selection--; }
        else { Selection = flagAmmount; }
    }

    public bool ChekSelection()
    {
        if (Selection == 0)
        {
            return true;
        }

        else return false;
    }
}
