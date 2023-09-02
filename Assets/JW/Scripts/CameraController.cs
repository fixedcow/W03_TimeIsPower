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
	[SerializeField] private Vector3 defaultCameraPosition;
	[SerializeField] private float offsetY;
	[SerializeField] private List<Vector2> stageCameraPosition = new List<Vector2>();
	[SerializeField] private Vector3 respawnPoint;
	[SerializeField] private CameraShaker shaker;

	private Transform player;
	private bool isGameStart;
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
		transform.DOMove(result, 0.5f)
			.OnComplete(()=>{
				StartFollowToPlayer();
			});
	}
	public void HitShake()
	{
		shaker.StartCameraShake();
	}

	public void StartFollowToPlayer()
    {
		isGameStart = true;
    }

	public void EndFollowToPlayer()
    {
		isGameStart = false;
    }
	#endregion

	#region PrivateMethod
	private void Awake()
	{
		if(instance == null)
			instance = this;
	}

    private void Start()
    {
		player = GameManager.instance.GetPlayer().transform;
    }
    private void FollowToPlayer()
    {
        if (isGameStart)
        {
			Vector3 cameraPos = defaultCameraPosition;
			float posY = Mathf.Clamp(player.position.y + offsetY, 4f, 6f);
			cameraPos.y = posY;
			cameraPos.z = -10;
			transform.position = cameraPos;
		}
		
    }

    private void Update()
    {
		FollowToPlayer();
    }

    #endregion
}
