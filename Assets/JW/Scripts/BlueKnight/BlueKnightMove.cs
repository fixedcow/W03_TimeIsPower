using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueKnightMove : MonoBehaviour
{
    [SerializeField] private bool canAct;
    [SerializeField] private float moveSpeed;
    public Transform testBoss;
    public void CanAct() => canAct = true;

    public void CanNotAct() => canAct = false;

    private void FollowPlayer()
    {
        if (canAct)
        {
            float playerPosX = GameManager.instance.GetPlayer().transform.position.x;
            float bossPosX = transform.position.x;
            if (playerPosX > bossPosX)
            {
                transform.localScale = new Vector3(-1, 0, 0);
                transform.Translate(moveSpeed, 0, 0);
            }
            else
            {
                transform.localScale = new Vector3(1, 0, 0);
                transform.Translate(-moveSpeed, 0, 0);
            }
        }
    }

    private void Update()
    {
        FollowPlayer();
    }
}
