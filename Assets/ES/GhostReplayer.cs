using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class GhostReplayer : MonoBehaviour
{
    private List<GhostData> ghostDatas = new List<GhostData>();
    private WaitForSeconds replayWait;
	private bool isReplaying;

	public void Replay()
	{
		isReplaying = true;
		StartCoroutine(nameof(ReplayGhost));
	}
	public void StopReplay()
	{
		isReplaying = false;
	}
	public void SetInterval(float _interval)
	{
		replayWait = new WaitForSeconds(_interval);
	}
	public void AddData(GhostData _data)
	{
		ghostDatas.Add(_data);
	}

	private IEnumerator ReplayGhost()
    {
        //비활성화 되어있는 ghost들 켜주기
        foreach(GhostData ghost in ghostDatas)
        {
            ghost.gameObject.SetActive(true);
        }

        int nowCount = 0;
        while (isReplaying)
        {
            foreach (GhostData ghost in ghostDatas)
            {
                if(ghost.recordPosition.Count - 1 == nowCount)
				{
					BodyGenerator.instance.SpawnBody(ghost.transform);
                    ghost.gameObject.SetActive(false);
                }
                if (ghost.recordPosition.Count-1 > nowCount)
                {
                    ghost.transform.position = ghost.recordPosition[nowCount];
                    Vector3 localScale = transform.localScale;
                    localScale.x = ghost.recordLocalScaleX[nowCount];
                    ghost.transform.localScale = localScale;
                    ghost.ghostAnimator.SetBool("dodge", ghost.dodgeTrigger[nowCount]);
                    ghost.ghostAnimator.SetBool("move", ghost.moveTrigger[nowCount]);
                    ghost.ghostAnimator.SetBool("jump", ghost.jumpTrigger[nowCount]);
                    ghost.ghostAnimator.SetBool("attack", ghost.attackTrigger[nowCount]);
                }
            }
            ++nowCount;
            yield return replayWait;
        }
    }
}
