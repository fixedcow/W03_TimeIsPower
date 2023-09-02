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

	public void StartCameraShake()
    {
		transform.DOShakePosition(shakeDuration, shakeStrength, shakeVibrato, shakeRandomness);
    }

}