using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DynamicObject : MonoBehaviour
{
    public abstract void DestroyObject();

    public abstract void StopObject();
}
