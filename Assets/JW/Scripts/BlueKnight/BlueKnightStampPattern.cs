using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class BlueKnightStampPattern : BossPattern
{
    [SerializeField] private ThunderAttack stamp; 
    [SerializeField] private int stampCount;
    [SerializeField] private float attackSpaceX;
    [SerializeField] private float bossSpaceX;
    [SerializeField] private float stampPossitionY;

    [SerializeField] private float attackDelay;
    private WaitForSeconds waitAttackDelay;

    [SerializeField] private float attackInterval;
    private WaitForSeconds waitAttackInterval;

    private void Start()
    {
        waitAttackDelay = new WaitForSeconds(attackDelay);
        waitAttackInterval = new WaitForSeconds(attackInterval);
    }

	[Button]
    protected override void ActionContext()
    {
        StartCoroutine(nameof(ThunderStamp));
    }
	private IEnumerator ThunderStamp()
    {
        float bossPosX = GameManager.instance.GetBoss().transform.position.x;
        float leftStampPosX = bossPosX - bossSpaceX;
        float rightStampPosX = bossPosX + bossSpaceX;
        for(int i = 0; i < stampCount; i++)
        {
            Vector3 stampPos = new Vector3(leftStampPosX, stampPossitionY, 0);
            Instantiate(stamp.gameObject, stampPos, Quaternion.identity);
            leftStampPosX -= attackSpaceX;

            stampPos = new Vector3(rightStampPosX, stampPossitionY, 0);
            Instantiate(stamp.gameObject, stampPos, Quaternion.identity);
            rightStampPosX += attackSpaceX;

            yield return waitAttackInterval;
        }
    }

}
