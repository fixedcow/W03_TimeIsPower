using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicObjectManager : MonoBehaviour
{
    public List<GameObject> objects = new();
    public static DynamicObjectManager instance;
    public void AddObject(GameObject _object)
    {
        objects.Add(_object);
    }

    

    public void Clear()
    {
        foreach( GameObject go in objects)
        {
            Destroy(go);   
        }
        objects.Clear();
    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }
}
