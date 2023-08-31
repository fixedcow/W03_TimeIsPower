using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FadeBlackController : MonoBehaviour
{
	[SerializeField] private float fadeMiddlePositionX;
	[SerializeField] private float fadeEndPositionX;
	[SerializeField] private float fadeStartPositionX;
	[SerializeField] private float fadeTime;
	[SerializeField] private Vector3 startPlayerPosition;
	private Transform player;
	private Transform cameraTransfom;

    private void Start()
    {
		cameraTransfom = Camera.main.transform;
		player = GameManager.instance.GetPlayer().transform;
    }

    public void GameOverFade()
    {
		transform.DOLocalMoveX(fadeMiddlePositionX, fadeTime)
			.OnComplete(() =>
			{
				player.position = startPlayerPosition;
				transform.DOLocalMoveX(fadeEndPositionX, fadeTime)
				 .OnComplete(() =>
				 {
					 Vector3 cameraPos = cameraTransfom.position;
					 cameraPos.x = fadeStartPositionX;
					 transform.localPosition = cameraPos;
				 });
			});


	}
}
