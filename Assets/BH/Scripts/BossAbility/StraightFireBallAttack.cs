using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightFireBallAttack : BossAbility
{
    WaitForSeconds delay = new WaitForSeconds(1f);
    WaitForSeconds patternTime = new WaitForSeconds(0.5f);

    GameObject fireBall;
    float speed = 25f;
    GameObject _player;

    protected override void HandleInputUpdate()
    {

    }

    public override void Active()
    {
        fireBall = (GameObject)Resources.Load("fireball");
        _player = GameManager.instance.GetPlayer().gameObject;
        this.enabled = false;
    }

    private void OnEnable()
    {
        StartCoroutine(FireBall());
    }

    IEnumerator FireBall()
    {

        for (int i = 0; i < 3; i++)
        {
            float currentTime = 0;
            GameObject go = Instantiate(fireBall, this.transform.position + Vector3.up * 2.5f, Quaternion.identity);
            yield return patternTime;

            while (currentTime < 1f)
            {
                currentTime += Time.deltaTime;
                go.transform.position += (Vector3)Random.insideUnitCircle / 20f;
                yield return null;
            }

            Vector2 dir = _player.transform.position - go.transform.position;
            currentTime = 0;
            while(currentTime < 1.5f)
            {
                currentTime += Time.deltaTime;
                go.transform.Translate(dir.normalized * Time.deltaTime * speed);
                yield return null;
            }
        }

        yield return patternTime;

        GameManager.instance.GetBoss().isPatternFinished = true;
        this.enabled = false;
    }
}
