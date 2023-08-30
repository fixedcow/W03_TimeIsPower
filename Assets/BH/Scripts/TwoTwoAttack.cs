using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoTwoAttack : BossAbility
{
    WaitForSeconds onoffDelay = new WaitForSeconds(0.5f);
    WaitForSeconds patternTime = new WaitForSeconds(2f);

    protected override void HandleInputUpdate()
    {

    }

    public override void Active()
    {
        this.enabled = false;
    }

    private void OnEnable()
    {
        StartCoroutine(BottomUp());
    }

    IEnumerator BottomUp()
    {
        // on
        _boss.ActiveSwitch(_alertAreas, 11);
        _boss.ActiveSwitch(_alertAreas, 13);
        yield return patternTime;

        // off
        _boss.ActiveSwitch(_alertAreas, 11);
        _boss.ActiveSwitch(_alertAreas, 13);
        yield return onoffDelay;

        // on
        _boss.ActiveSwitch(_damageAreas, 11);
        _boss.ActiveSwitch(_damageAreas, 13);
        _boss.ActiveSwitch(_alertAreas, 12);
        _boss.ActiveSwitch(_alertAreas, 14);
        yield return patternTime;

        // off
        _boss.ActiveSwitch(_damageAreas, 11);
        _boss.ActiveSwitch(_damageAreas, 13);
        _boss.ActiveSwitch(_alertAreas, 12);
        _boss.ActiveSwitch(_alertAreas, 14);
        yield return onoffDelay;

        // on
        _boss.ActiveSwitch(_damageAreas, 12);
        _boss.ActiveSwitch(_damageAreas, 14);
        yield return patternTime;

        // off
        _boss.ActiveSwitch(_damageAreas, 12);
        _boss.ActiveSwitch(_damageAreas, 14);
        yield return onoffDelay;

        _boss.isPatternFinished = true;
        this.enabled = false;
    }
}
