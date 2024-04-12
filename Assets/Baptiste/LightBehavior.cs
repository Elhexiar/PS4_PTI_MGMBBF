using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehavior : MonoBehaviour
{
    public bool activated;
    [SerializeField] private int howManyAlarm;
    [SerializeField] private Light thisLight;

    private IEnumerator FadeIn(float FadeSpeed = 5f)
    {
        if(thisLight.intensity < 1)
        {
            thisLight.intensity += FadeSpeed/100;
            yield return null;
            yield return new WaitForSeconds(0.01f);
            StartCoroutine(FadeIn(FadeSpeed));
        }
        yield return null;
    }


    private IEnumerator FadeOut(float FadeSpeed = 5f)
    {
        if (thisLight.intensity > 0)
        {
            thisLight.intensity -= FadeSpeed / 100;
            yield return null;
            yield return new WaitForSeconds(0.01f);
            StartCoroutine(FadeOut(FadeSpeed));
        }
        yield return null;
    }


    private void Update()
    {
        if(activated)
        {
            Flickering();
        }
    }


    private void Flickering(float flickerSpeed = 5f, bool isRandom = false,float rangeA = 1f , float rangeB = 10f)
    {
        if (howManyAlarm > 0)
        {
            float speed = 0f;
            if (isRandom)
            {
                speed = Random.Range(rangeA, rangeB);
            }
            else
            {
                speed = flickerSpeed;
            }

            if (thisLight.intensity == 0)
            {
                StopAllCoroutines();
                StartCoroutine(FadeIn(speed));
            }
            else if (thisLight.intensity >= 1)
            {
                StopAllCoroutines();
                StartCoroutine(FadeOut(speed));
                howManyAlarm--;
            }
        }
        else
        {
            activated = false;
            howManyAlarm = 1;
        }
    }
}
