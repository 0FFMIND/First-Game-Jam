using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitySingleton<T> : MonoBehaviour where T:Component
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance != null)
                _instance = FindObjectOfType(typeof(T)) as T;
            if(_instance == null)
            {
                GameObject obj = new GameObject();
                obj.name = typeof(T).ToString();
                _instance = (T)obj.AddComponent(typeof(T));
                DontDestroyOnLoad(obj);
            }
            return _instance;
        }
    }
    protected virtual void Awake()
    {
        
        if(_instance == null)
        {
            _instance = this as T;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
