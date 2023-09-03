using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance;
    public List<Vector3> spawnPosition;
    public ParticleSystem fire;
    float fireDelayTime = 12f;

    [SerializeField] private List<GameObject> stageEnterTriggerList = new List<GameObject>();
    [SerializeField] private FadeBlackController fadeBlackController;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameManager.instance.ChangeState(GameManager.EGameState.tutorial);
    }

    bool _stage2 = false;
    public bool Stage2EnterTrigger
    {
        get
        {
            return _stage2;
        }
        set
        {
            _stage2 = value;
            if(value == true)
            {
                if (_stage2)
                {
                    StartCoroutine(FireWall());
                }
            }
            else
            {
                StopAllCoroutines();
                fire.Stop();
            }
        }
    }

    IEnumerator FireWall()
    {
        yield return new WaitForSeconds(fireDelayTime);
        fire.Play();
    }


}