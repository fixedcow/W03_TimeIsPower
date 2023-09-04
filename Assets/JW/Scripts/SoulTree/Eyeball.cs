using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyeball : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Vector3 direction;

    private void Start()
    {
        direction = GetAngleToPlayer();
        Invoke(nameof(DestroyObject), 10f);
    }

    private Vector3 GetAngleToPlayer()
    {
        return GameManager.instance.GetPlayer().transform.position - transform.position;


    }
    private void ShootAtPlayer()
    {
        transform.Translate(direction.normalized*moveSpeed);
        
    }

    private void DestroyObject()
    {
        Destroy(this.gameObject);
    }
    private void Update()
    {
        ShootAtPlayer();
    }
}
