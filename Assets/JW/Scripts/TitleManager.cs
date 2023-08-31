using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	[SerializeField] private BlackScreen blackScreen;

	#endregion

	#region PublicMethod
	public void StartGame()
	{
		StartGameTask().Forget();
	}
	public void ExitGame()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
	}
	#endregion

	#region PrivateMethod
	private async UniTaskVoid StartGameTask()
	{
		await blackScreen.ScreenFadeOut();
		CameraController.instance.MoveToRespawnPoint();
		await blackScreen.ScreenFadeIn();
		GameManager.instance.GameStart();
	}
	#endregion
}
