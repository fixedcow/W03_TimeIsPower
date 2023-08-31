using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingObject : MonoBehaviour
{
    float deadPower = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vector2 deadVector = new Vector2(0f, 1f);
            collision.GetComponent<GhostGenerator>()._deadVector = deadVector.normalized;

            GameManager.instance.GetPlayer().Hit();
            BodyGenerator.Instance.SpawnBody(collision.transform, deadVector.normalized * deadPower, false);
        }
    }
}
