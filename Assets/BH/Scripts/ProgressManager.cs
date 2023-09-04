using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager Instance;

    [SerializeField] GameObject redMageWall;
    [SerializeField] GameObject blueKnightWall;
    [SerializeField] GameObject soulTreeWall;
    [SerializeField] float speed = 1f;
    Vector2 originRedMageWall;
    Vector2 originBlueKnightWall;
    Vector2 originSoulTreeWall;

    private void Awake()
    {
        Instance = this;

        originRedMageWall = redMageWall.transform.position;
        originBlueKnightWall = blueKnightWall.transform.position;
        originSoulTreeWall = soulTreeWall.transform.position;
    }

    [Button]
    public void SetProgress()
    {
        redMageWall.transform.DOMoveY(redMageWall.transform.position.y + 1.8f, speed);

        if(PlayerPrefs.GetInt(LocalDataManager.Instance.RedMageName) == 1)
        {
            blueKnightWall.transform.DOMoveY(blueKnightWall.transform.position.y + 1.8f, speed);
        }
        if (PlayerPrefs.GetInt(LocalDataManager.Instance.BlueKnightName) == 1)
        {
            soulTreeWall.transform.DOMoveX(soulTreeWall.transform.position.x - 2f, speed);
        }
    }

    [Button]
    public void ResetWall()
    {
        redMageWall.transform.position = originRedMageWall;
        blueKnightWall.transform.position = originBlueKnightWall;
        soulTreeWall.transform.position = originSoulTreeWall;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameManager.instance.GetPlayer().CanAct();
        SetProgress();
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
