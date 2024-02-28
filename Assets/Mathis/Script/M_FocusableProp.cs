using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusableProp : MonoBehaviour
{
    private M_PlayerManager m_PlayerManager;

    public BoxCollider triggerBoxCollider;

    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        if(other.gameObject.tag == "Player")
        {
            Debug.Log(this);
            Debug.Log("PlayerInbound");
            m_PlayerManager.InRangeFocusableProp = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Out");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("PlayerInbound");

            m_PlayerManager.InRangeFocusableProp = null;
        }
    }
}
