using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyeball : MonoBehaviour
{

    [SerializeField] private Transform pupilTransform;
    [SerializeField] private float moveSpeed;
    private Vector3 direction;

    private void Start()
    {
        direction = GetAngleToPlayer();
    }

    private Vector3 GetAngleToPlayer()
    {
        return GameManager.instance.GetPlayer().transform.position - pupilTransform.position;


    }
    private void ShootAtPlayer()
    {
        transform.Translate(direction.normalized*moveSpeed);
        
    }

    private void Update()
    {
        ShootAtPlayer();
    }
}
