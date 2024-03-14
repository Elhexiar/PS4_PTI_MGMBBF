using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class M_GeneralManager : MonoBehaviour
{
    private static M_GeneralManager instance;

    [SerializeField]
    public  List<M_Manager> managers;

    public void Awake()
    {
        if (M_GeneralManager.instance == null)
        {
            M_GeneralManager.instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        managers = new List<M_Manager>();
        managers = GetComponents<M_Manager>().ToList();
        DontDestroyOnLoad(gameObject);
    }


    public static T GetManager<T>() where T : M_Manager
    {
        foreach (var manager in instance.managers)
        {
            if (manager.GetType() == typeof(T))
            {
                return (T)manager;
            }
        }
        return null;
    }

}

