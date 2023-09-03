using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSwitch : MonoBehaviour
{
    public bool isActive = false;
    [SerializeField] float timer = 1.5f;
    WaitForSeconds wfs;
    public Gate gate;

    private void Start()
    {
        wfs = new WaitForSeconds(timer);
    }

    public void Hit()
    {
        if (isActive) return;
        
        isActive = true;
        StartCoroutine(SwitchTimer());
    }

    IEnumerator SwitchTimer()
    {
        this.GetComponent<SpriteRenderer>().color = Color.red;
        gate.IsOpen = true;

        yield return wfs;

        this.GetComponent<SpriteRenderer>().color = Color.blue;
        gate.IsOpen = false;

        isActive = false;
    }
}
