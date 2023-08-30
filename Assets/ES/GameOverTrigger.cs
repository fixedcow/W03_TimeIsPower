using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{

    [SerializeField] private Player player;
    [SerializeField] private GhostManager ghostManager;
    private WaitForSeconds waitTime = new WaitForSeconds(0.1f);
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){

            Vector3 targetVector = transform.position - player.transform.position;
            player.Hit();
            BodyGenerator.Instance.SpawnBody(collision.transform, targetVector,false);
            StartCoroutine(SetDeadVector(targetVector));
        }
    }

    private IEnumerator SetDeadVector(Vector3 deadVector)
    {
        yield return waitTime;
        ghostManager.ghostDatas[ghostManager.ghostDatas.Count - 1].deadVector = deadVector;
    }
}
