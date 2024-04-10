using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PuzzleBoxLightBehaviour : MonoBehaviour
{
    public Light pointLight;

    [SerializeField]
    private bool lightIsOn = true;
    // Start is called before the first frame update
    void Start()
    {
        lightIsOn = false;
        pointLight.enabled = false;
    }

    public void toggleLightON()
    {
        pointLight.enabled = true;
        lightIsOn = true;

    }

    public void toggleLightOFF()
    {
        pointLight.enabled = false;
        lightIsOn = false;
    }

    public bool getLightStatus()
    {
        return lightIsOn;
    }

}
