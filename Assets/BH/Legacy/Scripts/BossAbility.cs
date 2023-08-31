using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossAbility : Boss
{
    protected Boss _boss;
    protected List<Transform> _platformPositions;
    protected List<GameObject> _alertAreas;
    protected List<GameObject> _damageAreas;
    
    protected virtual void Awake()
    {
        Init();
    }

    public virtual void PreUpdate()
    {
        PreHandleInput();
        HandleInputUpdate();
    }

    public virtual void DoUpdate()
    {
        
    }

    public virtual void PostUpdate()
    {

    }

    public abstract void Active();

    private void Init()
    {
        _boss = GetComponent<Boss>();

        _platformPositions = _boss.platformPositions;
        _alertAreas = _boss.alertAreas;
        _damageAreas = _boss.damageAreas;

        StopAllCoroutines();
    }

    protected void PreHandleInput()
    {
        
    }

    protected abstract void HandleInputUpdate();

    public void Stop()
    {
        StopAllCoroutines();
        foreach(GameObject go in _damageAreas)
        {
            if (go.activeSelf)
            {
                go.SetActive(false);
            }
        }
        foreach(GameObject go in _alertAreas)
        {
            if (go.activeSelf)
            {
                go.SetActive(false);
            }
        }
    }
}
