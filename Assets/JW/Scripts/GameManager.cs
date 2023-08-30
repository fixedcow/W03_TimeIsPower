using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	#region PublicVariables
	public static GameManager instance;
	#endregion

	#region PrivateVariables
	[SerializeField] private Player player;
	[SerializeField] private Boss boss;
	#endregion

	#region PublicMethod
	public Player GetPlayer() => player;
	public Boss GetBoss() => boss;
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
