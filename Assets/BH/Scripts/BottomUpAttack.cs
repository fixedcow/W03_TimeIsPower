using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomUpAttack : BossAbility
{
    WaitForSeconds onoffDelay = new WaitForSeconds(0.5f);
    WaitForSeconds patternTime = new WaitForSeconds(1.2f);

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
        _boss.ActiveSwitch(_alertAreas, 1, 2);
        yield return patternTime;

        // off
        _boss.ActiveSwitch(_alertAreas, 1, 2);
        yield return onoffDelay;

        // on
        _boss.ActiveSwitch(_damageAreas, 1, 2);
        _boss.ActiveSwitch(_alertAreas, 3, 5);
        yield return patternTime;

        // off
        _boss.ActiveSwitch(_damageAreas, 1, 2);
        _boss.ActiveSwitch(_alertAreas, 3, 5);
        yield return onoffDelay;

        // on
        _boss.ActiveSwitch(_damageAreas, 3, 5);
        _boss.ActiveSwitch(_alertAreas, 6, 7);
        yield return patternTime;

        // off
        _boss.ActiveSwitch(_damageAreas, 3, 5);
        _boss.ActiveSwitch(_alertAreas, 6, 7);
        yield return onoffDelay;

        // on
        _boss.ActiveSwitch(_damageAreas, 6, 7);
        _boss.ActiveSwitch(_alertAreas, 8, 10);
        yield return patternTime;

        // off
        _boss.ActiveSwitch(_damageAreas, 6, 7);
        _boss.ActiveSwitch(_alertAreas, 8, 10);
        yield return onoffDelay;

        // on
        _boss.ActiveSwitch(_damageAreas, 8, 10);
        yield return patternTime;

        // off
        _boss.ActiveSwitch(_damageAreas, 8, 10);
        yield return onoffDelay;
        

        _boss.isPatternFinished = true;
        this.enabled = false;
    }
}
