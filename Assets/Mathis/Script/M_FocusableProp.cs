using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FocusableProp : MonoBehaviour
{
    public M_PlayerManager m_PlayerManager;

    public string defaultString = "default";

    public BoxCollider triggerBoxCollider;


    private void Awake()
    {
        m_PlayerManager = FindObjectOfType<M_PlayerManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            m_PlayerManager.InRangeFocusableProp = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(m_PlayerManager.InRangeFocusableProp == this)
            {
                m_PlayerManager.InRangeFocusableProp = null;
            }
        }
    }

    public virtual void Interact()
    {
        Debug.Log("default");
    }
}
