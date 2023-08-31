using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigFireBallAttack : BossAbility
{
    WaitForSeconds delay = new WaitForSeconds(3f);
    WaitForSeconds patternTime = new WaitForSeconds(0.5f);

    GameObject fireBall;
    float speed = 25f;

    protected override void HandleInputUpdate()
    {

    }

    public override void Active()
    {
        fireBall = (GameObject)Resources.Load("Magmaball");
        this.enabled = false;
    }

    private void OnEnable()
    {
        StartCoroutine(FireBall());
    }

    IEnumerator FireBall()
    {
        if (GameManager.instance.GetPlayer().isPlayerDead)
        {
            yield break;
        }

        Instantiate(fireBall,(Vector2)transform.position + Vector2.up * 3, Quaternion.identity);
        yield return delay;

        GameManager.instance.GetBoss().isPatternFinished = true;
        this.enabled = false;
    }
}
