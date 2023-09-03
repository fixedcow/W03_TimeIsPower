using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UIElements;

public class Gate : MonoBehaviour
{
    public List<GateSwitch> switches = new();
    [SerializeField] float openSpeed = 1f;
    [SerializeField] float closeSpeed = 0.3f;


    bool _isOpen = false;
    public bool IsOpen
    {
        get
        {
            return _isOpen;
        }
        set
        {
            _isOpen = value;
            if (value)
            {
                foreach (var v in switches)
                {
                    if (!v.isActive) return;
                }
                GateOpen();
            }
            else
            {
                GateClose();
            }
        }
    }


    void GateOpen()
    {
        this.gameObject.transform.DOMoveY(4.2f, openSpeed);
    }

    void GateClose()
    {
        this.gameObject.transform.DOMoveY(1.2f, closeSpeed);
    }

  
}

