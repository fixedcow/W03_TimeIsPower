using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    public float yOffset;

    private void Update()
    {
        Vector3 cameraPos = player.position;
        cameraPos.y += yOffset;
        cameraPos.z = -10f;
        transform.position = cameraPos;
    }
}
