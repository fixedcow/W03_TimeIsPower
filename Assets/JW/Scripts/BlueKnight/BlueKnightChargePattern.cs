using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class BlueKnightChargePattern : BossPattern
{
    [SerializeField] private GameObject chanrgeAttack;

    [Button]
    protected override void ActionContext()
    {
        Instantiate(chanrgeAttack, GameManager.instance.GetBoss().transform.position, Quaternion.identity);
    }

}
