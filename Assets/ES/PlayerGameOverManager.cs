using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameOverManager : MonoBehaviour
{
    public bool isPlayerDaad;

    [SerializeField] private GameObject fadeScreen;
    [SerializeField] private float restartInterval;
    [SerializeField] private Vector3 startPlayerPosition;
    [SerializeField] private GameObject recordTrigger;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            PlayerGameOver();
            Invoke("PlayerRestart", restartInterval);
        }
    }

    private void PlayerGameOver()
    {
        isPlayerDaad = true;
        transform.position = startPlayerPosition;
    }

    private void PlayerRestart()
    {
        recordTrigger.SetActive(true);
        isPlayerDaad = false;
    }
}
