using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Body : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	[SerializeField] private SpriteRenderer sr;
	[SerializeField] private Rigidbody2D rb;

	private static Color32 transparent = new Color32(150, 150, 255, 100);
	private static Color32 opaque = new Color32(255, 255, 255, 255);
	#endregion

	#region PublicMethod
	public void SetTransparency(bool isTransparent)
	{
		sr.color = isTransparent ? transparent : opaque;
	}
	public void SetVelocity(Vector2 _velocity)
	{
		rb.velocity = _velocity;
	}
	#endregion

	#region PrivateMethod
	private void OnEnable()
	{
		sr.DOFade(0, 1).SetDelay(Random.Range(5f, 10f)).OnComplete(() => gameObject.SetActive(false));
	}
	#endregion
}
