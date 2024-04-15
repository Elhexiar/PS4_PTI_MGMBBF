using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class S_LaunchGameScript : Button
{


    protected override void Start()
    {
        
    }
    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        gameObject.GetComponent<AudioSource>().Play();
    }


    public void LaunchGame()
    {
        SceneManager.LoadScene("SC_MainScene");
    }
}
