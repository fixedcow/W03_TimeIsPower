using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class GhostRecorder : MonoBehaviour
{
	[SerializeField] private GameObject ghostPrefab;
	private Player player;
	private Animator playerAnimator;
    private WaitForSeconds replayWait;
    private GhostReplayer replayer;
	private bool isRecording;

	public void Record()
	{
		isRecording = true;
		StartCoroutine(nameof(StartRecordGhost));
	}
	public void StopRecord()
	{
		isRecording = false;
	}
	public void SetReplayer(GhostReplayer _replayer) => replayer = _replayer;
	public void SetInterval(float _interval)
	{
		replayWait = new WaitForSeconds(_interval);
	}

	private void Start()
	{
		player = GameManager.instance.GetPlayer();
		playerAnimator = player.GetAnimator();
	}
	private IEnumerator StartRecordGhost()
    {
        GameObject ghost = Instantiate(ghostPrefab, new Vector3(15, 0, 0), Quaternion.identity);
        GhostData ghostData = ghost.GetComponent<GhostData>();

        while (isRecording)
        {
            ghostData.recordPosition.Add(player.transform.position);
            ghostData.recordLocalScaleX.Add(player.transform.localScale.x);
            ghostData.dodgeTrigger.Add(playerAnimator.GetBool("dodge"));
            ghostData.moveTrigger.Add(playerAnimator.GetBool("move"));
            ghostData.jumpTrigger.Add(playerAnimator.GetBool("jump"));
            ghostData.attackTrigger.Add(playerAnimator.GetBool("attack"));
            yield return replayWait;
        }
		replayer.AddData(ghostData);
    }
}
