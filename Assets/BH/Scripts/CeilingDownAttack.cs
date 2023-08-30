using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingDownAttack : BossAbility
{
    WaitForSeconds patternDelay = new WaitForSeconds(1.5f);

    protected override void HandleInputUpdate()
    {

    }

    public override void Active()
    {
        this.enabled = false;
    }

    private void OnEnable()
    {
        StartCoroutine(CeilingDown());
    }

    IEnumerator CeilingDown()
    {
        Debug.Log("down");
        // on
        _boss.ActiveSwitch(_alertAreas, 8, 10);
        yield return patternDelay;

        // on
        _boss.ActiveSwitch(_damageAreas, 8, 10);
        _boss.ActiveSwitch(_alertAreas, 6, 7);
        // off
        _boss.ActiveSwitch(_alertAreas, 8, 10);
        yield return patternDelay;

        // on
        _boss.ActiveSwitch(_damageAreas, 6, 7);
        _boss.ActiveSwitch(_alertAreas, 3, 5);
        // off
        _boss.ActiveSwitch(_damageAreas, 8, 10);
        _boss.ActiveSwitch(_alertAreas, 6, 7);
        yield return patternDelay;

        // on
        _boss.ActiveSwitch(_damageAreas, 3, 5);
        _boss.ActiveSwitch(_alertAreas, 1, 2);
        // off
        _boss.ActiveSwitch(_damageAreas, 6, 7);
        _boss.ActiveSwitch(_alertAreas, 3, 5);
        yield return patternDelay;

        // on
        _boss.ActiveSwitch(_damageAreas, 1, 2);
        // off
        _boss.ActiveSwitch(_damageAreas, 3, 5);
        _boss.ActiveSwitch(_alertAreas, 1, 2);
        yield return patternDelay;

        // off
        _boss.ActiveSwitch(_damageAreas, 1, 2);


        _boss.isPatternFinished = true;
        this.enabled = false;
    }
}
