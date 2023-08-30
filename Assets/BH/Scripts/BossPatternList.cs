using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatternList : MonoBehaviour
{
    
    public List<Boss.Info> _list = new()
    {
        new Boss.Info
        {
            state = Boss.BossState.ATTACK,
            position = 10,
            ability = 0
        },
        new Boss.Info
        {
            state = Boss.BossState.ATTACK,
            position = 1,
            ability = 1
        },
        new Boss.Info
        {
            state = Boss.BossState.ATTACK,
            position = 2,
            ability = 2
        },
    };
    

    
    
}
