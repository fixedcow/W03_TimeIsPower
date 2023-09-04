using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
	#region PublicVariables
	public static GameManager instance;
	public enum EGameState
	{
		idle = 0,
		battle = 1,
		tutorial = 2,
	}
	#endregion

	#region PrivateVariables
	private EGameState state;
	[SerializeField] private Player player;
	[SerializeField]private Boss boss;
	private GameObject stageEnterTrigger;

	[SerializeField] private EndingUI GameClearUI;
	[SerializeField] private List<Boss> bossList = new List<Boss>();
	[SerializeField] private List<GameObject> rageBossList = new List<GameObject>();
	[SerializeField] private List<GameObject> stageEnterTriggerList = new List<GameObject>();
	[SerializeField] private FadeBlackController fadeBlackController;

	[SerializeField] private GameObject bossClearText;
	[SerializeField] private SpriteRenderer bossClearFadeBlack;
	[SerializeField] private Vector3 initPlayerPosition;

	#endregion

	#region PublicMethod
	public EGameState GetGameState() => state;
	public Player GetPlayer() => player;
	public Boss GetBoss() => boss;
	public void SetBoss(Boss _boss) => boss = _boss;
	public void Initialize()
	{

	}
	public void GameStart()
	{
		player.CanAct();
	}
	public void BattleStart(Utils.EStage _stage)
	{
		state = EGameState.battle;
		boss = bossList[(int)_stage - 1];
		stageEnterTrigger = stageEnterTriggerList[(int)_stage - 1];
		boss.Initialize();
		boss.gameObject.SetActive(true);
		BossHpGUI.instance.ShowGUI();
		BossHpGUI.instance.SetBossNameText(boss.bossName);
		BossHpGUI.instance.SetMaxHp(boss.GetMaxHp());
		BodyGenerator.instance.ClearBody();
		GhostManager.instance.RecordAndReplay();
		boss.PatternStart();
	}
	public void BattleEnd()
	{
		if (state == EGameState.idle) return;

		if (state != EGameState.tutorial)
		{
			state = EGameState.idle;
		}
	

		if (state == EGameState.tutorial)
		{
			TutorialManager.Instance.Reset();
		}

		CameraController.instance.EndFollowToPlayer();
		player.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;

		if (state != EGameState.tutorial)
		{
			DeathCounterManager.instance.PlayerDead();
		}

		CameraController.instance.HitShake();
		fadeBlackController.StartFade();
		GhostManager.instance.StopRecordAndReplay();
		Invoke(nameof(WaitBattleEnd), fadeBlackController.waitFadeTime+fadeBlackController.fadeTime);
		GetPlayer().SetInvincibility(false);
	}

	private void WaitBattleEnd()
    {
		if (state == EGameState.tutorial) return;

		BossHpGUI.instance.HideGUI();
		foreach(GameObject go in stageEnterTriggerList)
        {
			go.SetActive(true);
        }
		boss.gameObject.SetActive(false);
		boss = null;
		DynamicObjectManager.instance.Clear();
	}
	public void SetGameStateIdle()
	{
		state = EGameState.idle;
	}
	public void GameClear()
	{
		GameClearUI.EnableEndingUI();
		GameClearUI.SetTryText();
		Physics2D.SyncTransforms();

		if(DeathCounterManager.instance.count == 1)
		{
			LocalDataManager.Instance.SetTrophy(boss.bossName);
		}

	}

	public void BossClear()
    {

		GhostManager.instance.GetReplayer().ClearData();
		foreach(GameObject go in stageEnterTriggerList)
        {
			go.SetActive(true);
        }

		foreach (GameObject go in rageBossList)
		{
			go.SetActive(false);
		}
		bossClearText.SetActive(true);
		GetBoss().Initialize();
		bossClearFadeBlack.DOFade(1f, 2)
			.OnComplete(() =>
			{
				BossHpGUI.instance.HideGUI();
				if (state != EGameState.tutorial)
				{
					state = EGameState.idle;
				}
				CameraController.instance.EndFollowToPlayer();
				CameraController.instance.MoveToRespawnPoint();
				player.transform.position = initPlayerPosition;
				
				Color color = Color.black;
				color.a = 0;
				bossClearFadeBlack.color = color;
				bossClearText.SetActive(false);

				player.CanAct();

			});
		

    }

	public void ChangeState(EGameState _state)
	{
		state = _state;
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
