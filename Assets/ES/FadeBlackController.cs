using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FadeBlackController : MonoBehaviour
{
	private float fadeStartPositionX = -40f;
	private float fadeMiddlePositionX = 0f;
	private float fadeEndPositionX = 40f;

	public float fadeTime;
	public float waitFadeTime;
	private Transform player;
	private Transform cameraTransfom;

    private void Start()
    {
		cameraTransfom = Camera.main.transform;
		player = GameManager.instance.GetPlayer().transform;
    }

	public void StartFade()
    {
		Invoke(nameof(GameOverFade), waitFadeTime);
    }
    public void GameOverFade()
    {
		transform.DOLocalMoveX(fadeMiddlePositionX, fadeTime)
			.OnComplete(() =>
			{
				GameManager.instance.GetPlayer().MoveToRespawnPoint();
				CameraController.instance.MoveToRespawnPoint();
				GameManager.instance.GetPlayer().transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
				transform.DOLocalMoveX(fadeEndPositionX, fadeTime)
				 .OnComplete(() =>
				 {
					 transform.DOLocalMoveX(fadeStartPositionX, 0f);
					 
				 });
			});


	}
}
