using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnterTrigger : MonoBehaviour
{
    public Vector3 cameraPos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Camera.main.transform.DOMove(cameraPos, 1f);
        if(collision.transform.position.x < -9)
        {
            TutorialManager.Instance.Stage2EnterTrigger = true;
        }
    }
}
