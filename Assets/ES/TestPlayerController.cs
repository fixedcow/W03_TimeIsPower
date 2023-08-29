using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigid;
    [SerializeField] private float moveForce;

    private void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerRigid.AddForce(-Vector2.right * moveForce);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerRigid.AddForce(Vector2.right * moveForce);
        }
    }

    private void Update()
    {
        Move();
    }
}
