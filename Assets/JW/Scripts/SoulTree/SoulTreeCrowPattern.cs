using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class SoulTreeCrowPattern : BossPattern
{
    [SerializeField] private StaticAttack rightCrowAttack;
    [SerializeField] private StaticAttack leftCrowAttack;
    [SerializeField] private float rightPosX;
    [SerializeField] private float leftPosX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    [Button]
    protected override void ActionContext()
    {
        playerAngle();
    }

    private void playerAngle()
    {
        float randomX;
        float randomY;
        Vector3 attackPos=Vector3.zero;

        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            randomX = rightPosX;
            randomY = Random.Range(minY, maxY);
            attackPos = new Vector3(randomX, randomY, 0);
            rightCrowAttack.transform.position = attackPos;
            Vector3 playerDirection = GameManager.instance.GetPlayer().transform.position - attackPos;
            float angle = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg-90;
            rightCrowAttack.transform.rotation=Quaternion.Euler(new Vector3(0, 0, angle));
            rightCrowAttack.StartAttack();
        }
        else
        {
            randomX = leftPosX;
            randomY = Random.Range(minY, maxY);
            attackPos = new Vector3(randomX, randomY, 0);
            leftCrowAttack.transform.position = attackPos;
            Vector3 playerDirection = GameManager.instance.GetPlayer().transform.position - attackPos;
            float angle = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg-90;
            leftCrowAttack.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            leftCrowAttack.StartAttack();
        }

       

    }
}
