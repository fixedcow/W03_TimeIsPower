using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public List<Lever> Levers = new();
    float speed = 0.5f;
    Tweener GateMoveTween;

    bool _isOpen = false;
    public bool IsOpen
    {
        get
        {
            return _isOpen;
        }
        set
        {
            if (value)
            {
                _isOpen = true;
                foreach (var v in Levers)
                {
                    if (!v.isActive)
                    {
                        _isOpen = false;
                        break;
                    }
                }
            }
            else
            {
                _isOpen = value;
                this.Open();
            }
        }
    }

    Vector3 openPos;
    Vector3 closePos;

    private void Start()
    {
        GateMoveTween = this.transform.DOMoveY(1.2f, speed).SetAutoKill(false);
        openPos = this.transform.position + Vector3.up * 3f;
        closePos = this.transform.position;
    }

    private void Update()
    {
        if (!_isOpen)
        {
            this.Close();
        }
        else
        {
            this.Open();
        }
    }
    
    public void Close()
    {
        GateMoveTween.ChangeEndValue(closePos, speed, true).Restart();

    }
    public void Open()
    {
        GateMoveTween.ChangeEndValue(openPos, speed, true).Restart();

    }
}

