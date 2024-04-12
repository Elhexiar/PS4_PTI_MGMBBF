using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class S_InputTerminalMainComputer : MonoBehaviour
{
    public List<TextMeshProUGUI> uiCodeRefs;

    public GameObject mainScreen;
    public GameObject folderScreen;

    public int cursorPos = 0;

    public string excpectedCode = "1985";
    public string currentCode = "";

    public bool isWaitingForInput = false;

    void Update()
    {
        // TODO : REFACTORISME MOI TOUT LA C'EST N'IMP
        if (Input.anyKeyDown && isWaitingForInput)
        {
            if (IsDigitsOnly(Input.inputString) && Input.inputString != "")
            {
                currentCode += Input.inputString;


                uiCodeRefs[cursorPos].text = Input.inputString;

                cursorPos++;
                if (cursorPos >= 4)
                {
                    if (currentCode != excpectedCode)
                    {
                        cursorPos = 0;
                        currentCode = "";
                        foreach (var codeRef in uiCodeRefs)
                        {
                            codeRef.text = "0";
                        }
                    }
                    else
                    {
                        S_GeneralManager.GetManagerfromGeneral<S_PuzzleManager>().FinishPuzzle2();
                        isWaitingForInput = false;
                        ShowScreen(mainScreen);
                    }
                }
            }
        }
    }

    public void ToggleIsWaitingForInput(bool newState)
    {
        isWaitingForInput = newState;
    }

    public void ShowScreen(GameObject uiRef)
    {
        uiRef.SetActive(true);
    }

    //u jakobbotsch on stackoverflow
    public bool IsDigitsOnly(string str)
    {
        
        foreach (char c in str)
        {
            if (c < '0' || c > '9')
                return false;
        }
        return true;
    }
}


