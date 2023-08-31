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
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			cameraController.transform.DOMove(stageCameraPosition, 0.5f)
				.OnComplete(() =>
				
				{
					Debug.Log("tweenComplete");
					//cameraController.enabled = true;
					gameObject.SetActive(false);
				});
			StartCoroutine(GameManager.instance.GetBoss().ChangePattern());
		}
	}

}
