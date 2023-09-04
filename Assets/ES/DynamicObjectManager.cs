using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DynamicObjectManager : MonoBehaviour
{
    public List<DynamicObject> objects = new();
    public static DynamicObjectManager instance;
    public void AddObject(DynamicObject _object)
    {
        objects.Add(_object);
    }

    public void Clear()
    {
        foreach(DynamicObject go in objects)
        {
            try
            {
                go.DestroyObject();
            }
            catch(Exception ex)
            {

            }
        }
        objects.Clear();
    }

    public void EndClear()
    {
        foreach (DynamicObject go in objects)
        {
            try
            {
                go.StopObject();
            }
            catch (Exception ex)
            {

            }
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
