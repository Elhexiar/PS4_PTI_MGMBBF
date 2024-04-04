using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_LightBehaviour : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        
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
