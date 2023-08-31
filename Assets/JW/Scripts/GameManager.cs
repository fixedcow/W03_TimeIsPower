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
	[SerializeField] private Boss boss;

	[SerializeField] private UnityEvent onGameStart;
	[SerializeField] private UnityEvent onBattleStart;
	#endregion

	#region PublicMethod
	public Player GetPlayer() => player;
	public Boss GetBoss() => boss;
	public void Initialize()
	{

	}

	public void GameStart()
	{
		onGameStart.Invoke();
	}
	public void BattleStart()
	{
		onBattleStart.Invoke();
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
