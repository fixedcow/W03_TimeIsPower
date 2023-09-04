using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueKnightMove : MonoBehaviour
{
    private bool canAct;
    [SerializeField] private float moveSpeed;
    public void CanAct() => canAct = true;

    public void CanNotAct() => canAct = false;

    private void FollowPlayer()
    {
        if (canAct)
        {
            float playerPosX = GameManager.instance.GetPlayer().transform.position.x;
            float bossPosX = transform.position.x;
            if ((playerPosX - bossPosX) > 0.5f)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                transform.Translate(moveSpeed, 0, 0);
            }
            else if ((playerPosX - bossPosX) < -0.5f)
            {
                transform.localScale = new Vector3(1, 1, 1);
                transform.Translate(-moveSpeed, 0, 0);
            }
        }
    }

    private void Update()
    {
        FollowPlayer();
    }
}
