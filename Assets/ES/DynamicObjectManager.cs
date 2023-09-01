using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicObjectManager : MonoBehaviour
{
    private List<GameObject> magmaBalls = new();

    public void AddMagmaBall(GameObject magmaBall)
    {
        magmaBalls.Add(magmaBall);
    }

    public void InitMagmaBalls()
    {
        magmaBalls.Clear();
    }
}
