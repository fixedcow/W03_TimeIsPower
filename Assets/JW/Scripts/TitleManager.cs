using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	[SerializeField] private BlackScreen blackScreen;
	bool isStarted = false;
	#endregion

	#region PublicMethod
	public void StartGame()
	{
		if (isStarted) return;
		isStarted = true;
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

    private void Start()
    {
		isStarted = false;
    }
    #endregion
}
