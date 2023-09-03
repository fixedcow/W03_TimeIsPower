using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class BlueKnightJumpRopePattern : BossPattern
{
    [SerializeField] JumpRopeAttack jumpRopeAttack;
    [Button]
    protected override void ActionContext()
    {
        jumpRopeAttack.gameObject.SetActive(true);
        jumpRopeAttack.AttackPlay();
    }
}
