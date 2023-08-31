using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
	#region PublicVariables
	public static GameManager instance;
	#endregion

	#region PrivateVariables
	[SerializeField] private Player player;
	private Boss boss;
	private GameObject stageEnterTrigger;

	[SerializeField] private GameObject GameClearUI;
	[SerializeField] private List<Boss> bossList = new List<Boss>();
	[SerializeField] private List<GameObject> stageEnterTriggerList = new List<GameObject>();
	[SerializeField] private FadeBlackController fadeBlackController;
	#endregion

	#region PublicMethod
	public Player GetPlayer() => player;
	public Boss GetBoss() => boss;
	public void Initialize()
	{

	}
	public void GameStart()
	{
		player.CanAct();
	}
	public void BattleStart(Utils.EStage _stage)
	{
		boss = bossList[(int)_stage];
		stageEnterTrigger = stageEnterTriggerList[(int)_stage];
		boss.Initialize();
		BossHpGUI.instance.ShowGUI();
		BossHpGUI.instance.SetMaxHp(boss.GetMaxHp());
		BodyGenerator.instance.ClearBody();
		GhostManager.instance.RecordAndReplay();
	}
	public void BattleEnd()
	{
		BossHpGUI.instance.HideGUI();
		DeathCounterManager.instance.PlayerDead();
		fadeBlackController.GameOverFade();
		stageEnterTrigger.SetActive(true);
		GhostManager.instance.StopRecordAndReplay();
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
