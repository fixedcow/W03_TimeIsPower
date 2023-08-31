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
            Vector2 deadVector = new Vector2(collision.transform.position.x - this.transform.position.x, 0.5f);
            collision.GetComponent<GhostGenerator>()._deadVector = deadVector.normalized;

            BodyGenerator.Instance.SpawnBody(this.transform, deadVector.normalized * deadPower, false);
        }
    }
}
