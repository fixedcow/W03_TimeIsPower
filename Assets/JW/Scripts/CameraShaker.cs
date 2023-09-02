using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

public class CameraShaker : MonoBehaviour
{
	#region PublicVariables
	public Camera main;
	#endregion

	[SerializeField] private float shakeDuration;
	[SerializeField] private float shakeStrength;
	[SerializeField] private int shakeVibrato;
	[SerializeField] private float shakeRandomness;

	private enum Etype
	{
		playerHit = 0
	}
	[SerializeField] List<CameraShakingData> datas = new List<CameraShakingData>();

	[Button]
	public void StartCameraShake()
    {
		transform.DOShakePosition(shakeDuration, shakeStrength, shakeVibrato, shakeRandomness);
    }

}