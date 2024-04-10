using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PuzzleBoxLogic : MonoBehaviour
{

    public string expectedCode;

    public string currentCode = "";

    public List<S_PuzzleBoxLightBehaviour> lightList;
    public Animator handleAnimator;

    public Light greenLED;
    public Light redLED;

    public void addNumberToCode(int i)
    {
        Debug.Log("Test");
        // we check if the code is already long enough
        if (currentCode.Length < expectedCode.Length)
        {
            Debug.Log("Test2");
            // we check if the button was already pressed ( could have been done in previous if not done for clarity )
            if (lightList[i].getLightStatus() == false)
            {
                Debug.Log(i);
                // we add the index of the corresponding light to the code
                currentCode += i;
            }
        }
    }

    public void CheckCode()
    {
        if (currentCode == expectedCode)
        {
            handleAnimator.Play("TryNSucceed");
            greenLED.enabled = true;
            redLED.enabled = false;

        }
        else
        {
            handleAnimator.Play("FailNReset");
            currentCode = "";
            foreach (S_PuzzleBoxLightBehaviour light in lightList)
            {
                light.toggleLightOFF();
            }
        }
    }
}
