using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDrapeauMn : MonoBehaviour
{
    [SerializeField] private OrdinateurDrap[] allPC;
    private void Update()
    {
        if(allPC != null)
        {
            allPC = GetComponentsInChildren<OrdinateurDrap>();
        }
    }

    private void Start()
    {
        StartCoroutine(CheckAwnser());
    }
        
    private IEnumerator CheckAwnser()
    {
        int count = 0;
        for (int i = 0; i < allPC.Length; i++)
        {
            if (allPC[i].ChekSelection()) { count ++; }
        }
        if(count == 4)
        {
            S_GeneralManager.GetManagerfromGeneral<S_PuzzleManager>().FinishPuzzle4();
        }
        else
        {
            yield return new WaitForSeconds(3);
            StartCoroutine(CheckAwnser());
        }
    }
}
