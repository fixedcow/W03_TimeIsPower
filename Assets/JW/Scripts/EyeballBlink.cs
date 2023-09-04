using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EyeballBlink : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	private GameObject letina;
	private GameObject pupil;

	[SerializeField] private float maxReactDistance;
	[SerializeField] private float blinkDelay;
	private float blinkTimer;
	#endregion

	#region PublicMethod
	#endregion

	#region PrivateMethod
	private void Awake()
	{
		letina = transform.Find("letina").gameObject;
		pupil = transform.Find("letina/pupil").gameObject;
		blinkTimer = 0;
	}
	private void Update()
	{
		ChasingPlayer();
		CheckTimeToBlink();
	}
	private void ChasingPlayer()
	{
		float distancePercentage = Mathf.Clamp01(GetDistanceWIthPlayer() / maxReactDistance);
		float pupilDistance = Mathf.Lerp(0, 0.5f, distancePercentage);
		pupil.transform.localPosition = pupilDistance * GetDirectionWithPlakyer();
	}
	private float GetDistanceWIthPlayer()
	{
		return Vector2.Distance(GameManager.instance.GetPlayer().transform.position, transform.position);
	}
	private Vector2 GetDirectionWithPlakyer()
	{
		Vector2 playerPos = GameManager.instance.GetPlayer().transform.position;
		return (playerPos - (Vector2)transform.position).normalized;
	}
	private void CheckTimeToBlink()
	{
		blinkTimer += Time.deltaTime;
		if(blinkTimer > blinkDelay)
		{
			blinkTimer = 0;
			Blink();
		}
	}
	private void Blink()
	{
		letina.transform.DOScaleY(0f, 0.2f).From(1f).OnComplete(() => letina.transform.DOScaleY(1f, 0.3f));
	}
	#endregion
}
