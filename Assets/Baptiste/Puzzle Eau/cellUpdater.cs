using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cellUpdater : MonoBehaviour
{
    public float flowSpeed;
    [SerializeField] private List<cell> map;
    [SerializeField] private cell[] generator;
    [SerializeField] private AlarmManager alarms;


    private void Awake()
    {
        // Find all ScriptB components attached to children objects
        cell[] scriptBs = GetComponentsInChildren<cell>();

        // Add them to the list
        map.AddRange(scriptBs);
    }

    private void Start()
    {
        StartCoroutine(CellUpdate());
    }

    /// <summary>
    /// update every cell content one by one
    /// </summary>
    /// <returns></returns>
    private IEnumerator CellUpdate()
    {
        for(int i = 0; i < map.Count; i++)
        {
            if (map[i] != null)
            {
                map[i].filling();
            }
        }
        for (int i = 0; i < generator.Length; i++)
        {
            if (!generator[i].alarmTrigered && generator[i].fillAmmount > 98)
            {
                generator[i].alarmTrigered = true;
                alarms.triggerAlarm();
            }
        }
        yield return new WaitForSeconds(flowSpeed);
        StartCoroutine(CellUpdate());
    }
}
