using System.Collections;
using UnityEngine;

namespace Assets.Mathis.Script
{
    public class M_InspectableObject : M_InteractableProp
    {

        public GameObject inspectionWindowRef;
        private void Start()
        {
            inspectionWindowRef = M_GeneralManager.GetManager<M_InspectionWindowManager>().uiRef;
        }

        public override void Interact()
        {
            Debug.Log("Montre l'UI !!");
            Debug.Log(inspectionWindowRef);
            inspectionWindowRef.SetActive(true);
        }
    }
}