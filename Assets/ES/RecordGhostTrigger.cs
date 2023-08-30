using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordGhostTrigger : MonoBehaviour
{
    [SerializeField] private GhostGenerator ghostGenerator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ghostGenerator.StartRecord();
            Invoke("DisableTrigger", 0.1f);
        }
    }
    private void DisableTrigger()
    {
        this.gameObject.SetActive(false);
    }
}
