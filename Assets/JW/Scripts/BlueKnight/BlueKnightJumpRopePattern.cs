using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class BlueKnightJumpRopePattern : BossPattern
{
    [SerializeField] private JumpRopeAttack jumpRopeAttackLeft;
    [SerializeField] private JumpRopeAttack jumpRopeAttackRight;
    [SerializeField] private float attackSpace;
    [Button]
    protected override void ActionContext()
    {
        Vector3 attackPos = GameManager.instance.GetBoss().transform.position;
        attackPos.x -= attackSpace;

        jumpRopeAttackLeft.transform.position = attackPos;
        jumpRopeAttackLeft.gameObject.SetActive(true);
        jumpRopeAttackLeft.StartAttack();

        attackPos = GameManager.instance.GetBoss().transform.position;
        attackPos.x += attackSpace;

        jumpRopeAttackRight.transform.position = attackPos;
        jumpRopeAttackRight.gameObject.SetActive(true);
        jumpRopeAttackRight.StartAttack();
    }
}
