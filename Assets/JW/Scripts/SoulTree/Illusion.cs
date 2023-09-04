using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Illusion : DynamicObject
{
    [SerializeField] private Vector3 illusionPosition;
    [SerializeField] private float radius;
    [SerializeField] private float circleMoveSpeed;
    [SerializeField] private float circleAngle = 0.0f;
    private float currentTime = 0;
    [SerializeField] private float delayTime;
    [SerializeField] private Collider2D col;
    [SerializeField] private float moveSpeed;
    private Vector3 illusionDirection;
    [SerializeField] private float activeTime;

    private void Start()
    {
        currentTime = 0;
        Invoke(nameof(DestroyObject), activeTime);

    }

    public void SetIllusion(Vector3 startPos, float angle,float delay)
    {
        Debug.Log(illusionPosition);
        illusionPosition = startPos;
        circleAngle = angle;
        delayTime = delay;
    }

    private void moveCirclePath()
    {
        
        float radians = circleAngle * Mathf.Deg2Rad;
        Vector3 newPosition = illusionPosition+ new Vector3(Mathf.Cos(radians) * radius, Mathf.Sin(radians) * radius, 0.0f);
        transform.position = newPosition;
        circleAngle += circleMoveSpeed * Time.deltaTime;
        if (circleAngle >= 360.0f)
        {
            circleAngle = 0.0f;
        }
    }

    private void AttackPlayer()
    {
        currentTime += Time.deltaTime;
        if (currentTime < delayTime)
        {
            col.enabled = false;
            illusionDirection = GameManager.instance.GetPlayer().transform.position - this.transform.position;
            moveCirclePath();
        }
        else
        {
            col.enabled = true;
            transform.Translate(illusionDirection.normalized * moveSpeed * Time.deltaTime);
        }
    }

    private void Update()
    {
        AttackPlayer();
    }

   
    public override void DestroyObject()
    {
        Destroy(this.gameObject);
    }

    public override void StopObject()
    {
        throw new System.NotImplementedException();
    }
}
