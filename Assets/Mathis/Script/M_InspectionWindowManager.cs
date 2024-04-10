using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_InspectionWindowManager: M_Manager
{

    public GameObject panel;

    public GameObject uiRef;
    public GameObject objectToInspect;
    public float rotationSpeed;
    public bool InspecEnabled = false;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (InspecEnabled)
        {
            objectToInspect.transform.Rotate((Input.GetAxis("Mouse Y") * -rotationSpeed * Time.deltaTime), (Input.GetAxis("Mouse X") * -rotationSpeed * Time.deltaTime), 0, Space.World);
        }
    }

    public void SetPanelState(bool state)
    {
        panel.SetActive(state);
    }

}
