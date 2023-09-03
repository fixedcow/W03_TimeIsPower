using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueKnightChargePattern : BossPattern
{
    [SerializeField] private GameObject chanrgeAttack;
    protected override void ActionContext()
    {
        Instantiate(chanrgeAttack, GameManager.instance.GetBoss().transform.position, Quaternion.identity);
    }

}
