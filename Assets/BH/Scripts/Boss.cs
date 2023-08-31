using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    private int _maxHp = 1000;

    public bool isPatternFinished = true;

    public int test;
    WaitForSeconds delay = new WaitForSeconds(2f);

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
        ResetParameter();

        foreach (var ability in _abilities)
        {
            ability.Active();
        }

    }

    protected virtual void LateWake()
    {

    }


    protected virtual void Start()
    {
        
    }

    private void Update()
    {

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
            case BossState.IDLE:

                break;
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

    public void ResetParameter()
    {
        this.ChangeState(BossState.IDLE);
        this.currentPatternIdx = 0;
        //StopAllCoroutines();
    }

    WaitForSeconds wfs = new WaitForSeconds(1f);
    public IEnumerator ChangePattern()
    {
        Debug.Log("changePattern");
        isPatternFinished = false;

        //yield return wfs;

        if (PatternList.Count - 1 < currentPatternIdx)
        {
            currentPatternIdx = 0;
        }

        if (PatternList.Count == 0) {
            Debug.Log("count");
            yield break;
        }
           

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
        Debug.Log("finished값"+ isPatternFinished);
        while (true)
        {
            Debug.Log("hi");
            yield return null;
        }
        yield return new WaitForSeconds(0.2f);
        // yield return new WaitUntil(() => test>=5);
     
        Debug.Log("넘어감" + isPatternFinished);
        yield return delay;
        Debug.Log("ChangePattern 거의 끝");
       // StartCoroutine(ChangePatternSequence());
    }

   
    public IEnumerator ChangePatternSequence()
    {
        while (true)
        {
            
            StartCoroutine(ChangePattern());
            yield return new WaitUntil(() => isPatternFinished);
            yield return delay;
        }
    }

    private void FixedUpdate()
    {
        Debug.Log("ispattern값" + isPatternFinished);
    }
}

