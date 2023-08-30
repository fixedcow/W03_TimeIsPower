using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class GhostGenerator : MonoBehaviour
{
    public bool testGameOver;

    [SerializeField] private PlayerGameOverManager gameOverManager;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private GameObject ghostPrefab;
    [SerializeField] private float recordInterval;
    private WaitForSeconds replayWait;
    [SerializeField] private GhostManager ghostManager;

    public Vector2 _deadVector { get; set; }

    private void Start()
    {
        replayWait = new WaitForSeconds(recordInterval);
    }

    private IEnumerator RecordGhost()
    {
        GameObject ghost = Instantiate(ghostPrefab, new Vector3(15, 0, 0), Quaternion.identity);
        GhostData ghostData = ghost.GetComponent<GhostData>();

        while (!gameOverManager.isPlayerDead) //게임오버가 되지 않았다면 while문 실행
        {
            ghostData.recordPosition.Add(transform.position);
            ghostData.recordLocalScaleX.Add(transform.localScale.x);
            ghostData.dodgeTrigger.Add(playerAnimator.GetBool("dodge"));
            ghostData.moveTrigger.Add(playerAnimator.GetBool("move"));
            ghostData.jumpTrigger.Add(playerAnimator.GetBool("jump"));
            ghostData.attackTrigger.Add(playerAnimator.GetBool("attack"));
            yield return replayWait;
        }
		ghostData.deadVector = _deadVector;
        ghostManager.ghostDatas.Add(ghostData);
    }

    [Button]
    public void StartRecord()
    {
        StartCoroutine(RecordGhost());
    }
}
