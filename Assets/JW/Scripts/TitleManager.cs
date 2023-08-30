using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	[SerializeField] private GameObject black;
	#endregion

	#region PublicMethod
	public void ExitTitle()
	{
		SpriteRenderer blackSr;
		black.TryGetComponent(out blackSr);
		blackSr.DOFade(1, 0.8f).From(0)
			//.OnComplete(() => Æ©Åä¸®¾ó ·ëÀ¸·Î ÀÌµ¿)
			.OnComplete(() => blackSr.DOFade(0, 0.3f).From(0))
			.OnComplete(() => gameObject.SetActive(false));
	}
	#endregion

	#region PrivateMethod
	#endregion
}
