using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OrdinateurDrap : MonoBehaviour
{
    [SerializeField] private int Selection;
    [SerializeField] private Image flagDisplay, CodeDisplay;
    [SerializeField] private Sprite[] allFlag;

    [SerializeField] private bool[] code; // true = short ; false = long
    [SerializeField] private Color on, off;

    private float flickerIndex;
    private int codeIndex;


    private void Start()
    {
        StartCoroutine(PlayCode());
    }

    public void NextFlag()
    {
        if (Selection < allFlag.Length - 1) { Selection++; }
        else { Selection = 0; }
        flagDisplay.sprite = allFlag[Selection];
    }

    public void PreviousFlag()
    {
        if (Selection > 0) { Selection--; }
        else { Selection = allFlag.Length - 1; }
        flagDisplay.sprite = allFlag[Selection];
    }

    public bool ChekSelection()
    {
        if (Selection == 0)
        {
            return true;
        }

        else return false;
    }


    private IEnumerator flicker()
    {
        Debug.Log("FLICKERING");
        if (CodeDisplay.color != off)
        {
            CodeDisplay.color = Color.Lerp(on, off, flickerIndex);
            flickerIndex += 0.02f;
            yield return new WaitForSeconds(0.01f);
            StartCoroutine(flicker());
        }
        else
        {
            flickerIndex = 0;
        }
    }

    private IEnumerator PlayCode()
    {
        if (codeIndex < code.Length)
        {
            if (code[codeIndex])
            {
                CodeDisplay.color = on;
                yield return new WaitForSeconds(0.2f);
                StartCoroutine(flicker());
            }
            else if (!code[codeIndex])
            {
                CodeDisplay.color = on;
                yield return new WaitForSeconds(1f);
                StartCoroutine(flicker());
            }
            yield return new WaitForSeconds(1.5f);
            codeIndex++;
        }
        else
        {
            codeIndex = 0;
            yield return new WaitForSeconds(4f);
        }
        StartCoroutine(PlayCode());
    }
}
