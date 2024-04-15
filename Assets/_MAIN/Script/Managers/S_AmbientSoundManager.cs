using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_AmbientSoundManager : MonoBehaviour
{

    //private AudioSource playerAmbientAudioSource;

    [SerializeField]
    private AudioSource breeze, cracks1, cracks2, cracks3;

    public float minTimeBreeze, maxTimeBreeze, minTimeCrack, maxTimeCrack;
    // Start is called before the first frame update
    void Start()
    {
        //playerAmbientAudioSource.Play();
        StartCoroutine(PlayBreezeEffectAtRandom());
        StartCoroutine(PlayCrackEffectAtRandom());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator PlayBreezeEffectAtRandom()
    {

        while(true)
            { 
                yield return new WaitForSeconds(Random.Range(minTimeBreeze, maxTimeBreeze));
            Debug.Log("PlayingBreeze");
            breeze.Play();
            }
    }
    private IEnumerator PlayCrackEffectAtRandom()
    {

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTimeCrack, maxTimeCrack));
            playCrackSoundEffect();
            }
    }

    public void playCrackSoundEffect()
    {
        Debug.Log("PlayingCreak");

        switch (Random.Range(1, 3))
        {
            case 1:
                cracks1.Play();
                break;

            case 2:
                cracks2.Play();
                break;

            case 3:
                cracks3.Play();
                break;
        }
    }


}
