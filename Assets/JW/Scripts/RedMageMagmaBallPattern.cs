using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMageMagmaBallPattern : BossPattern
{
    [SerializeField] private GameObject magmaball;
    [SerializeField] private float offsetY;
    private Boss boss;
    protected override void OnDisable()
    {
        base.OnDisable();
       
    }
    private void Start()
    {
        boss = GameManager.instance.GetBoss();
    }


    protected override void ActionContext()
    {
        Vector3 attackPos = transform.position;
        attackPos.y += offsetY;
        GameObject attack = Instantiate(magmaball, attackPos, Quaternion.identity);
        //나중에 DynamicObjectManager 연결해서 AddMagmaBall()호출해주기
        // 메인씬 건드리는거 불안해서 안함

    }
}
