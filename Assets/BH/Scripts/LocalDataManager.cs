using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalDataManager : MonoBehaviour
{
    public static LocalDataManager Instance;

    bool _isTutorialCleared = false;
    public bool IsTutorialCleared
    {
        get
        {
            return TutorialCanSkip();     
        }
    }

    public string RedMageName
    {
        get
        {
            return "어딘가의 마법사이름";
        }
    }

    public string BlueKnightName
    {
        get
        {
            return "어딘가의 기사 이름";
        }
    }

    public string SoulTreeName
    {
        get
        {
            return "어딘가의 나무 이름";
        }
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        TutorialCanSkip();
    }

    void Start()
    {
        
    }



    public void SetTrophy(string bossname)
    {
        PlayerPrefs.SetInt(bossname, 1);
    }

    public void SetPerfect(string bossname)
    {
        PlayerPrefs.SetInt(bossname + "Perfect", 1);
    }

    bool TutorialCanSkip()
    {
        return PlayerPrefs.GetInt("TutorialClear") == 1 ? true : false;
    }

    public void ClearTutorial()
    {
        PlayerPrefs.SetInt("TutorialClear", 1);
    }

    [Button]
    void DebugDeleteAllPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    [Button]
    void DebugClearTutorial()
    {
        PlayerPrefs.SetInt("TutorialClear", 1);
    }

    [Button]
    void DebugClearRedMage()
    {
        PlayerPrefs.SetInt(RedMageName, 1);
    }

    [Button]
    void DebugClearBlueKnight()
    {
        PlayerPrefs.SetInt(BlueKnightName, 1);
    }

    [Button]
    void DebugClearSoulTree()
    {
        PlayerPrefs.SetInt(SoulTreeName, 1);
    }

    [Button]
    void DebugPerfectRedMage()
    {
        PlayerPrefs.SetInt(RedMageName+"Perfect", 1);
    }

    [Button]
    void DebugPerfectBlueKnight()
    {
        PlayerPrefs.SetInt(BlueKnightName + "Perfect", 1);
    }

    [Button]
    void DebugPerfectSoulTree()
    {
        PlayerPrefs.SetInt(SoulTreeName + "Perfect", 1);
    }
}
