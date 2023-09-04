using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyManager : MonoBehaviour
{
    [SerializeField] List<GameObject> awards;
    public static TrophyManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GetTrophy();
    }

    public void GetTrophy()
    {
        if (PlayerPrefs.GetInt(LocalDataManager.Instance.RedMageName) == 1)
        {
            awards[0].SetActive(true);
        }
        if (PlayerPrefs.GetInt(LocalDataManager.Instance.BlueKnightName) == 1)
        {
            awards[1].SetActive(true);
        }
        if (PlayerPrefs.GetInt(LocalDataManager.Instance.SoulTreeName) == 1)
        {
            awards[2].SetActive(true);
        }
        if (PlayerPrefs.GetInt(LocalDataManager.Instance.RedMageName + "Perfect") == 1)
        {
            awards[3].SetActive(true);
        }
        if (PlayerPrefs.GetInt(LocalDataManager.Instance.BlueKnightName + "Perfect") == 1)
        {
            awards[4].SetActive(true);
        }
        if (PlayerPrefs.GetInt(LocalDataManager.Instance.SoulTreeName + "Perfect") == 1)
        {
            awards[5].SetActive(true);
        }
    }
}
