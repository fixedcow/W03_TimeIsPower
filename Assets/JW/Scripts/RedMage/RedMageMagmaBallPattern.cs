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
		DynamicObjectManager.instance.AddObject(attack);
    }
}
