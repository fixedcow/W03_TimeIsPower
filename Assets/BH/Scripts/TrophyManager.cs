using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyManager : MonoBehaviour
{
    public static TrophyManager Instance;
    [SerializeField] List<GameObject> perfectAwards;


    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        GetTrophy();
    }

    void Update()
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
}
