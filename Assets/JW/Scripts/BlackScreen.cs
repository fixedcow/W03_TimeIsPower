using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cysharp.Threading;
using Cysharp.Threading.Tasks;

public class BlackScreen : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	private Camera main;
	private SpriteRenderer sr;
	#endregion

	#region PublicMethod
	public async UniTask ScreenFadeOut()
	{
		gameObject.SetActive(true);
		transform.position = (Vector2)main.transform.position;
		await sr.DOFade(1, 0.8f).From(0);
	}
	public async UniTask ScreenFadeIn()
	{
		transform.position = (Vector2)main.transform.position;
		await sr.DOFade(0, 0.7f).From(1).OnComplete(() => gameObject.SetActive(false));
	}
	#endregion

	#region PrivateMethod
	private void Awake()
	{
		main = Camera.main;
		TryGetComponent(out sr);
		gameObject.SetActive(false);
	}
	#endregion
}
