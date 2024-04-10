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


    public void NextFlag()
    {
        if (Selection < allFlag.Length) { Selection++; }
        else { Selection = 0; }
    }

    private void Start()
    {
        StartCoroutine(PlayCode());
    }

    public void PreviousFlag()
    {
        if (Selection > 0) { Selection--; }
        else { Selection = allFlag.Length; }
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
        if(CodeDisplay.color != off)
        {
            CodeDisplay.color = Color.Lerp(on, off, flickerIndex);
            flickerIndex += 0.02f;
            yield return new WaitForSeconds(0.01f);
            StartCoroutine(flicker());
        }
    }

    private IEnumerator PlayCode()
    {
        Debug.Log(codeIndex);
        if(codeIndex > code.Length - 1)
        {
            if (code[codeIndex])
            {
                CodeDisplay.color = on;
                new WaitForSeconds(0.2f);
                flicker();
            }
            else
            {
                CodeDisplay.color = on;
                new WaitForSeconds(1f);
                flicker();
            }
            new WaitForSeconds(2f);

            codeIndex++;
        }
        yield return null;
    }
}
