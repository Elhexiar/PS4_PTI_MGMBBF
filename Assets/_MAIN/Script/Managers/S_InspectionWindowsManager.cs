using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_InspectionWindowsManager : S_Manager
{
    public GameObject panel;

    public GameObject inspectionWindowsUIRef;
    [SerializeField]
    private Light inspectionLight;
    public GameObject objectToInspect;
    public float rotationSpeed;
    public bool inspecEnabled = false;

    private void Start()
    {

    }

    private void Update()
    {
        if (inspecEnabled)
        {
            objectToInspect.transform.Rotate(0, (Input.GetAxis("Mouse X") * -rotationSpeed * Time.deltaTime), (Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime), Space.World);
        }
    }

    public void SetPanelState(bool state)
    {
        panel.SetActive(state);
        inspectionLight.enabled = state;
    }
}
