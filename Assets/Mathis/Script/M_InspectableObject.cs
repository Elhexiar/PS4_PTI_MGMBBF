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
            if(M_GeneralManager.GetManager<M_InspectionWindowManager>().InspecEnabled == false)
            {
                M_GeneralManager.GetManager<M_InspectionWindowManager>().objectToInspect.SetActive(true);
                M_GeneralManager.GetManager<M_InspectionWindowManager>().InspecEnabled = true;
                M_GeneralManager.GetManager<M_playerRotation>().isMouseUnlocked = false;

                inspectionWindowRef.SetActive(true);
                M_GeneralManager.GetManager<M_InspectionWindowManager>().InspecEnabled = true;
            }
            else
            {
                M_GeneralManager.GetManager<M_InspectionWindowManager>().objectToInspect.SetActive(false);
                M_GeneralManager.GetManager<M_InspectionWindowManager>().InspecEnabled = false;
                M_GeneralManager.GetManager<M_playerRotation>().isMouseUnlocked = true;

                inspectionWindowRef.SetActive(false);

                M_GeneralManager.GetManager<M_InspectionWindowManager>().InspecEnabled = false;
            }
            
        }
    }
}