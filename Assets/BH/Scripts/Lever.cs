using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public bool isActive = false;
    [SerializeField] float timer = 1.5f;
    WaitForSeconds wfs;
    public Gate gate;
    public Sprite leverOn;
    public Sprite leverOff;
    SpriteRenderer leverSprite;

    private void Start()
    {
        wfs = new WaitForSeconds(timer);
        leverSprite = this.GetComponent<SpriteRenderer>();
    }

    public void Hit()
    {
        if (isActive) return;
        
        isActive = true;
        StartCoroutine(SwitchTimer());
    }

    IEnumerator SwitchTimer()
    {
        this.leverSprite.sprite = leverOn;
        gate.IsOpen = true;

        yield return wfs;

        this.leverSprite.sprite = leverOff;

        isActive = false;
        gate.IsOpen = false;
    }
}
