using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraControllerTrigger : MonoBehaviour
{
    private CameraController cameraController;
    [SerializeField] private Transform player;
	[SerializeField] private Vector3 stageCameraPosition;

	private void Start()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			cameraController.transform.DOMove(stageCameraPosition, 0.5f)
				.OnComplete(() =>
				{
					//cameraController.enabled = true;
					gameObject.SetActive(false);
				});
			StartCoroutine(GameManager.instance.GetBoss().ChangePattern());
		}
	}

}
