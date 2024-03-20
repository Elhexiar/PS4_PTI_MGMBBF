using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehavior : MonoBehaviour
{
    public bool execute;
    [SerializeField] private Light thisLight;
    private float intensity;

    private void Awake()
    {
        this.GetComponent<Light>();
        intensity = thisLight.intensity;
    }

    private void Start()
    {
        thisLight.intensity = 0;
        StartCoroutine(flicker(1,1));
    }

    public IEnumerator fadeIn(float duration)
    {
        thisLight.intensity += intensity/100 ;
        yield return new WaitForSeconds(duration/100);
        if(thisLight.intensity < intensity)
        {
            StartCoroutine(fadeIn(duration));
            Debug.Log("A");
        }
    }

    public IEnumerator fadeOut(float duration)
    {
        thisLight.intensity -= intensity / 100;
        yield return new WaitForSeconds(duration / 100);
        if (thisLight.intensity > 0)
        {
            StartCoroutine(fadeOut(duration));
            Debug.Log("B");
        }
    }

    public IEnumerator flicker(float time , float duration)
    {
            StartCoroutine(fadeIn((time / duration)/2));
            yield return new WaitForSeconds(duration / time);
            StartCoroutine(fadeOut((time / duration) / 2));
            yield return new WaitForSeconds(duration / time);
    }

}
