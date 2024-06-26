using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_CommandBoxBehaviour : MonoBehaviour
{

    public string expectedCode;

    public string currentCode = "";

    public List<M_LightBehaviour> lightList;
    public Animator handleAnimator;

    public Light greenLED;
    public Light redLED;

    public void addNumberToCode(int i)
    {
        
        // we check if the code is already long enough
        if(currentCode.Length < expectedCode.Length) 
        {
            // we check if the button was already pressed ( could have been done in previous if not done for clarity )
            if (lightList[i].getLightStatus() == false )
            {

                // we add the index of the corresponding light to the code
                Debug.Log(i);
                currentCode += i;

            }
        }

    }

    public void CheckCode()
    {

        if(currentCode == expectedCode)
        {
            handleAnimator.Play("TryNSucceed");
            Debug.Log("CHAMPION !!!!");
            greenLED.enabled = true;
            redLED.enabled = false;

        }
        else
        {
            Debug.Log("Cringe ...");
            handleAnimator.Play("FailNReset");
            currentCode = "";
            foreach (M_LightBehaviour light in lightList)
            {
                light.toggleLightOFF();
            }
        }
        

    }

}
