using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
	[SerializeField] private Vector3 stageCameraPosition = new Vector3(0f, 3.75f, -10f);
	public float yOffset;

	public void StageIn()
	{
		transform.DOMove(stageCameraPosition, 0.5f);
	}

    private void Update()
    {
        Vector3 cameraPos = player.position;
        cameraPos.y += yOffset;
        cameraPos.z = -10f;
        transform.position = cameraPos;
    }
}
