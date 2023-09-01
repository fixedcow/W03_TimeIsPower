using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMageFirebreathPattern : BossPattern
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	[SerializeField] List<StaticAttack> left = new List<StaticAttack>();
	[SerializeField] List<StaticAttack> right = new List<StaticAttack>();
	#endregion

	#region PublicMethod
	#endregion

	#region PrivateMethod
	protected override void OnDisable()
	{
		base.OnDisable();
		foreach (StaticAttack breath in left)
		{
			breath.InitAttack();
		}
		foreach (StaticAttack breath in right)
		{
			breath.InitAttack();
		}
	}
	protected override void ActionContext()
	{
		if(GetRandom())
		{
			foreach(StaticAttack breath in left)
			{
				breath.StartAttack();
			}
		}
		else
		{
			foreach (StaticAttack breath in right)
			{
				breath.StartAttack();
			}
		}
	}
	private bool GetRandom()
	{
		return Random.value > 0.5f;
	}
	#endregion
}
