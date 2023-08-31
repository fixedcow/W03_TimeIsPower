using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomUpAttack : BossAbility
{
    WaitForSeconds onoffDelay = new WaitForSeconds(0.5f);

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
        if (GameManager.instance.isPlayerDead)
        {
            yield break;
        }
        _boss.ActiveSwitch(_alertAreas, 1, 2);  //Aon
        yield return onoffDelay;
        yield return onoffDelay;

        if (GameManager.instance.isPlayerDead)
        {
            yield break;
        }
        _boss.ActiveSwitch(_alertAreas, 1, 2);  //Aoff
        _boss.ActiveSwitch(_damageAreas, 1, 2); //A'on
        yield return onoffDelay;
        if (GameManager.instance.isPlayerDead)
        {
            yield break;
        }
        _boss.ActiveSwitch(_alertAreas, 3, 5);  //Bon
        yield return onoffDelay;
        yield return onoffDelay;
        if (GameManager.instance.isPlayerDead)
        {
            yield break;
        }
        _boss.ActiveSwitch(_alertAreas, 3, 5);  //Boff
        _boss.ActiveSwitch(_damageAreas, 3, 5); //B'on
        yield return onoffDelay;
        if (GameManager.instance.isPlayerDead)
        {
            yield break;
        }
        _boss.ActiveSwitch(_damageAreas, 1, 2); //A'off
        _boss.ActiveSwitch(_alertAreas, 6, 7);  //Con
        yield return onoffDelay;
        yield return onoffDelay;
        if (GameManager.instance.isPlayerDead)
        {
            yield break;
        }
        _boss.ActiveSwitch(_alertAreas, 6, 7);  //Coff
        _boss.ActiveSwitch(_damageAreas, 6, 7); //C'on
        yield return onoffDelay;
        if (GameManager.instance.isPlayerDead)
        {
            yield break;
        }
        _boss.ActiveSwitch(_damageAreas, 3, 5); //B'off
        _boss.ActiveSwitch(_alertAreas, 8, 10); //Don
        yield return onoffDelay;
        yield return onoffDelay;
        if (GameManager.instance.isPlayerDead)
        {
            yield break;
        }
        _boss.ActiveSwitch(_alertAreas, 8, 10); //Doff
        _boss.ActiveSwitch(_damageAreas, 8, 10);//D'on
        yield return onoffDelay;
        if (GameManager.instance.isPlayerDead)
        {
            yield break;
        }
        _boss.ActiveSwitch(_damageAreas, 6, 7); //C'off
        yield return onoffDelay;
        yield return onoffDelay;
        if (GameManager.instance.isPlayerDead)
        {
            yield break;
        }
        _boss.ActiveSwitch(_damageAreas, 8, 10);//D'off
        yield return onoffDelay;
        if (GameManager.instance.isPlayerDead)
        {
            StopAllCoroutines();

        }

        GameManager.instance.GetBoss().isPatternFinished = true;
        this.enabled = false;
    }

    
}
