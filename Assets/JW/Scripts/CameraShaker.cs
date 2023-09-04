using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

public class CameraShaker : MonoBehaviour
{
	#region PublicVariables
	public Camera main;

	public enum ECameraShakingType
	{
		playerHit = 0,
		thunder = 1
	}
	#endregion

	[SerializeField] private List<CameraShakingData> datas = new List<CameraShakingData>();

	public void StartCameraShake(ECameraShakingType type)
    {
		CameraShakingData data = datas[(int)type];
		transform.DOShakePosition(data.duration, data.strength, data.vibrato, data.randomness);
    }

}