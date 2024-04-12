using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmManager : MonoBehaviour
{
    [SerializeField] private LightBehavior[] lights;
    [SerializeField] private int alarmCount = 5;
    private int alarmsAmmount;

    private void Awake()
    {
        alarmsAmmount = alarmCount;
    }

    public void triggerAlarm()
    {
        StartCoroutine(playAlarm());
    }

    private IEnumerator playAlarm()
    {
        if (alarmCount >0)
        {
            for (int j = 0; j < lights.Length; j++)
            {
                lights[j].activated = true;
            }
            yield return new WaitForSeconds(1.5f);
            StartCoroutine(playAlarm());
            alarmCount--;
        }
        else
        {
            alarmCount = alarmsAmmount;
        }
    }
}
