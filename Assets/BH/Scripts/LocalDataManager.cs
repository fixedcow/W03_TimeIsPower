using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalDataManager : MonoBehaviour
{
    public static LocalDataManager Instance;

    [SerializeField] List<GameObject> perfectAwards;

    public bool isTutorialCleared = false;

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

    public void GetTrophy()
    {
        if (PlayerPrefs.GetString("분노한 악당 마법사") == "Achieve")
        {
            perfectAwards[0].SetActive(true);
        }
        if (PlayerPrefs.GetString("분노한 아무튼 기사") == "Achieve")
        {
            perfectAwards[1].SetActive(true);
        }
        if (PlayerPrefs.GetString("분노한 아무튼 나무") == "Achieve")
        {
            perfectAwards[2].SetActive(true);
        }
    }

    public void SetTrophy(string bossname)
    {
        PlayerPrefs.SetString(bossname, "Achieve");
    }

    void TutorialCanSkip()
    {
        if (PlayerPrefs.GetInt("TutorialClear") == 1)
        {
            isTutorialCleared = true;
        }
        else
        {
            isTutorialCleared = false;
        }


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
}
