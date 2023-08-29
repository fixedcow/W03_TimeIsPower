using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Boss : MonoBehaviour
{
    public enum State
    {
        Ignore = 0,
        IDLE,
        ATTACK_1,
        ATTACK_2,
        ATTACK_3,
    }

    public class Info
    {
        public State state;
    }

    public Info bossInfo {  get; private set; }

    private List<BossAbility> _abilities;


    public List<Transform> platformPositions;
    public List<GameObject> alertAreas;
    public List<GameObject> damageAreas;

    private void Awake()
    {
        _abilities = new List<BossAbility>();
        _abilities.AddRange(this.GetComponents<BossAbility>());


        bossInfo = new Info();
        
    }

    private void Run()
    {

        //_abilities[1].Active();
    }

    private void Update()
    {
        //

        //PreUpdateBoss();

        //DoUpdateBoss();

        //PostUpdateBoss();
    }

    private void PreUpdateBoss()
    {
        foreach(var ability in _abilities)
        {
            ability.PreUpdate();
        }
    }

    private void DoUpdateBoss()
    {
        foreach (var ability in _abilities)
        {
            ability.DoUpdate();
        }
    }

    private void PostUpdateBoss()
    {
        foreach (var ability in _abilities)
        {
            ability.PostUpdate();
        }
    }

    public void ChangeState(State _state)
    {
        bossInfo.state = _state;
        switch (_state)
        {
            case State.IDLE: break;
            case State.ATTACK_1: break;
            case State.ATTACK_2: break;
            case State.ATTACK_3: break;
        }
    }

    public void ActiveSwitch(List<GameObject> _list, int _startNum, int _endNum)
    {
        for(int i = _startNum - 1; i <= _endNum - 1; i++)
        {
            if (_list[i].activeSelf)
            {
                _list[i].SetActive(false);
            }
            else
            {
                _list[i].SetActive(true);
            }
        }
    }
}
