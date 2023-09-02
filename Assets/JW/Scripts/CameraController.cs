using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
	#region PublicVariables
	public static CameraController instance;
	#endregion

	#region PrivateVariables
	[SerializeField] private List<Vector2> stageCameraPosition = new List<Vector2>();
	[SerializeField] private Vector3 respawnPoint;
	[SerializeField] private CameraShaker shaker;
	#endregion

	#region PublicMethod
	public void MoveToRespawnPoint()
	{
		transform.position = respawnPoint;
	}
	public void MoveToStage(Utils.EStage stageNumber)
	{
		Vector3 result = Vector3.zero;
		switch(stageNumber)
		{
			case Utils.EStage.Stage1:
				result = stageCameraPosition[0];
				break;
			case Utils.EStage.Stage2:
				result = stageCameraPosition[1];
				break;
		}
		result.z = -10f;
		transform.DOMove(result, 0.5f);
	}
	public void HitShake()
	{
		shaker.StartCameraShake();
	}
	#endregion

	#region PrivateMethod
	private void Awake()
	{
		if(instance == null)
			instance = this;
	}
	#endregion
}
