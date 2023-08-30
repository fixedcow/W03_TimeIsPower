using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatternList : MonoBehaviour
{
    Boss _boss;

    private void Start()
    {
        _boss = GetComponent<Boss>();

        foreach (var pattern in _list)
        {
            _boss.PatternList.Add(pattern);
        }

    }
    

    private List<Boss.Info> _list = new()
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
        }
    };
    

    
    
}
