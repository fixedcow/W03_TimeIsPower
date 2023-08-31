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
	[SerializeField] private float deadBounceMagnitude;
	[SerializeField] private float durationMin;
	[SerializeField] private float durationMax;

	private static Color32 transparent = new Color32(150, 150, 255, 100);
	private static Color32 opaque = new Color32(255, 255, 255, 255);
	#endregion

	#region PublicMethod
	public void SetTransparency(bool isTransparent)
	{
		sr.color = isTransparent ? transparent : opaque;
	}
	#endregion

	#region PrivateMethod
	private void OnEnable()
	{
		rb.velocity = Vector2.up * deadBounceMagnitude;
		sr.DOFade(0, 1).SetDelay(Random.Range(durationMin, durationMax)).OnComplete(() => gameObject.SetActive(false));
	}
	#endregion
}
