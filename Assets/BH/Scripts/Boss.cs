using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Boss : MonoBehaviour
{

    private int _maxHp = 100000;

    public bool isPatternFinished = true;

    WaitForSeconds delay = new WaitForSeconds(2f);

    public int HP
    {
        get
        {
            return HP;
        }
        private set
        {
            HP = value;
        }
    }

    public enum BossState
    {
        Ignore = 0,
        IDLE,
        ATTACK,
        CHANGEPHASE,
        DIE,
    }

    [Serializable]
    public class Info
    {
        public BossState state;
        public int position;
        public int ability;
    }

    public BossState state;

    private List<BossAbility> _abilities;

    public List<Transform> platformPositions;
    public List<GameObject> alertAreas;
    public List<GameObject> damageAreas;

    public List<Info> PatternList;

    private int currentPatternIdx = 0;

    private void Awake()
    {
        _abilities = new List<BossAbility>();
        _abilities.AddRange(this.GetComponents<BossAbility>());

        foreach (var ability in _abilities)
        {
            ability.Active();
        }


        LateWake();
    }

    protected virtual void LateWake()
    {

    }


    protected virtual void Start()
    {
        StartCoroutine(ChangePattern());
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
        foreach (var ability in _abilities)
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

    void Init()
    {
        ChangeState(BossState.IDLE);

    }

    public void ChangeState(BossState _state)
    {
        state = _state;
        switch (_state)
        {
            case BossState.IDLE: break;
            case BossState.ATTACK: break;
            case BossState.CHANGEPHASE: break;
            case BossState.DIE: break;
        }
    }

    public void ActiveSwitch(List<GameObject> _list, int _startNum, int _endNum)
    {
        for (int i = _startNum - 1; i <= _endNum - 1; i++)
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

    public void ActiveSwitch(List<GameObject> _list, int num)
    {
        if (_list[num - 1].activeSelf)
        {
            _list[num - 1].SetActive(false);
        }
        else
        {
            _list[num - 1].SetActive(true);
        }

    }

    void ResetParameter()
    {
        this.HP = _maxHp;
        this.ChangeState(BossState.IDLE);
        this.currentPatternIdx = 0;
    }


    IEnumerator ChangePattern()
    {
        
        isPatternFinished = false;

        // 조건 플레이어랑 연동해서 바꿔놓기


        if (PatternList.Count - 1 <= currentPatternIdx)
        {
            currentPatternIdx = 0;
        }

        if (PatternList.Count == 0) yield break;

        if (PatternList[currentPatternIdx].state == BossState.CHANGEPHASE)
        {

        }
        else
        {
            this.ChangeState(PatternList[currentPatternIdx].state);
            this.transform.position = platformPositions[PatternList[currentPatternIdx].position].position;
            this._abilities[PatternList[currentPatternIdx].ability].enabled = true;
            currentPatternIdx++;
        }
        yield return new WaitUntil(() => isPatternFinished);
        yield return delay;
        StartCoroutine(ChangePattern());
    }
}

