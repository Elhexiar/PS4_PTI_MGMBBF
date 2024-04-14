using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class S_GeneralManager : MonoBehaviour
{
    private static S_GeneralManager instance;

    [SerializeField]
    public List<S_Manager> managers;


    // Typical General Manager script able to have all the other managers references
    // Put as a static Singleton to be easily accesible everywhere else

    public void Awake()
    {
        if (S_GeneralManager.instance == null)
        {
            S_GeneralManager.instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        managers = new List<S_Manager>();
        managers = GetComponents<S_Manager>().ToList();
        DontDestroyOnLoad(gameObject);
    }

    
    public static T GetManagerfromGeneral<T>() where T : S_Manager
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