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
	#endregion

	#region PrivateMethod
	private async UniTaskVoid StartGameTask()
	{
		await blackScreen.ScreenFadeOut();
		Camera.main.transform.position = new Vector3(-19f, 3.75f, -10f);
		await blackScreen.ScreenFadeIn();
	}
	#endregion
}
