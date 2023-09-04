using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleManager : MonoBehaviour
{
	#region PublicVariables
	public static TitleManager Instance;

	#endregion

	#region PrivateVariables
	[SerializeField] private BlackScreen blackScreen;
	[SerializeField] private SpriteRenderer button;
	[SerializeField] private TextMeshPro text;

	public bool isStarted = false;
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

	public void SkipTutorial()
	{
		if (!LocalDataManager.Instance.IsTutorialCleared) return;
		if (isStarted) return;
		isStarted = true;
		SkipTutorialTask().Forget();
	}

	#region PrivateMethod
	private async UniTaskVoid StartGameTask()
	{
		await blackScreen.ScreenFadeOut();
		CameraController.instance.MoveToRespawnPoint();
		await blackScreen.ScreenFadeIn();
		GameManager.instance.GameStart();
	}

	async UniTaskVoid SkipTutorialTask()
	{
		await blackScreen.ScreenFadeOut();
		SceneManager.LoadScene("Main");
	}

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
		if(LocalDataManager.Instance.IsTutorialCleared && !isStarted)
		{
			button.color = new Color(1, 1, 1, 1);
			text.color = new Color(1, 1, 1, 1);
		}
    }
    #endregion
}
