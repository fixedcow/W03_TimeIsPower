using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagmaBall : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] float guideSpeed;
    [SerializeField] float rotateSpeed;
    [SerializeField] float maxSpeed;
    private Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void GuideToPlayer()
    {

        Vector2 dir = transform.right;
        Vector2 targetDir = player.position - transform.position;
        Vector3 crossVec = Vector3.Cross(dir, targetDir);
        float inner = Vector3.Dot(Vector3.forward, crossVec);
        float saveAngle = inner + transform.rotation.eulerAngles.z;
        transform.rotation = Quaternion.Euler(0, 0, saveAngle*rotateSpeed);

        float moveDirAngle = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        Vector2 moveDir = Vector2.zero;
        moveDir = new Vector2(Mathf.Cos(moveDirAngle), Mathf.Sin(moveDirAngle));
        rigid.velocity = moveDir*guideSpeed;

    }

    private void Update()
    {
        GuideToPlayer();
    }
}


