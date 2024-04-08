using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDrapeauMn : MonoBehaviour
{
    [SerializeField] private OrdinateurDrap[] allPC;

    private void Awake()
    {
        allPC = GetComponentsInChildren<OrdinateurDrap>();
    }

    public void StartPuzlle()
    {
        StartCoroutine(CheckAwnser());
    }

    private IEnumerator CheckAwnser()
    {
        int count = 0;
        for(int i = 0; i < allPC.Length; i++)
        {
            if (allPC[0].ChekSelection()) { count ++; }
        }
        if(count == 4)
        {
            Debug.Log("PUZLLE REUSSI");
        }
        else
        {
            yield return new WaitForSeconds(3);
            StartCoroutine(CheckAwnser());
        }
    }
}
