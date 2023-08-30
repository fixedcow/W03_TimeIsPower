using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayGhostTrigger : MonoBehaviour
{
    [SerializeField] private GhostManager ghostManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ghostManager.StartReplay();
        }
    }
}
