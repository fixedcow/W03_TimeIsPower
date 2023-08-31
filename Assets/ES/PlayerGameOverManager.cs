using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerGameOverManager : MonoBehaviour
{
    public bool isPlayerDead;

    [SerializeField] private GameObject fadeScreen;
    [SerializeField] private float fadeMiddlePositionX;
    [SerializeField] private float fadeEndPositionX;
    [SerializeField] private Vector3 fadeStartPosition;
    [SerializeField] private float fadeTime;
    [SerializeField] private float restartInterval;
    [SerializeField] private Vector3 startPlayerPosition;
    [SerializeField] private Vector3 startCameraPosition;
    [SerializeField] private GameObject recordTrigger;
    [SerializeField] private GameObject cameraTrigger;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            PlayerGameOver();
            Invoke("PlayerRestart", restartInterval);
            GameManager.instance.GetBoss().ResetParameter();
        }
    }

    private void PlayerGameOver()
    {
        isPlayerDead = true;
        //transform.position = startPlayerPosition;
        fadeScreen.transform.DOLocalMoveX(fadeMiddlePositionX, fadeTime)
             .OnComplete(() =>
             {
                 Camera.main.GetComponent<CameraController>().enabled = false;
                 Camera.main.transform.position = startCameraPosition;
                 transform.position = startPlayerPosition;
                 fadeScreen.transform.DOLocalMoveX(fadeEndPositionX, fadeTime)
                 .OnComplete(() =>
                 {
                     fadeScreen.transform.localPosition = fadeStartPosition;
                 });
             });
    }

    private void PlayerRestart()
    {
        recordTrigger.SetActive(true);
        cameraTrigger.SetActive(true);
        isPlayerDead = false;
    }
}
