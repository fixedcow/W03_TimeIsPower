using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
	#region PublicVariables
	public static GameManager instance;

	public GameObject GameClearUI;
	
	#endregion

	#region PrivateVariables
	[SerializeField] private Player player;
	[SerializeField] private Boss boss;

	[SerializeField] private UnityEvent onGameStart;
	[SerializeField] private UnityEvent onBattleStart;
	[SerializeField] private UnityEvent onBattleEnd;
	#endregion

	public GameObject ClearUI;
	public bool isPlayerDead;
	[SerializeField] private FadeBlackController fadeBlackController;
	[SerializeField] private float restartInterval;
	[SerializeField] private GameObject stageEnterTrigger;

	#region PublicMethod
	public Player GetPlayer() => player;
	public Boss GetBoss() => boss;
	public void Initialize()
	{

	}

	public void GameOver()
    {
		isPlayerDead = true;
		fadeBlackController.GameOverFade();
		Invoke("GameRestart", restartInterval);

    }
	public void GameRestart()
    {
		stageEnterTrigger.SetActive(true);
		isPlayerDead = false;
    }

	public void GameStart()
	{
		onGameStart.Invoke();
	}
	public void BattleStart()
	{
		onBattleStart.Invoke();
		StartCoroutine(boss.ChangePattern());
	}
	public void BattleEnd()
	{
		onBattleEnd.Invoke();
	}

	public void GameClear()
	{
		GameClearUI.SetActive(true);
		Time.timeScale = 0;
		Physics2D.SyncTransforms();
	}
	#endregion

	

	#region PrivateMethod
	private void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
	}
	#endregion
}
