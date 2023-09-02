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
	private bool flip;
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
		flip = false;
	}
	protected override void ActionContext()
	{
		if(flip == false)
		{
			flip = !flip;
			foreach(StaticAttack breath in left)
			{
				breath.StartAttack();
			}
		}
		else
		{
			flip = !flip;
			foreach (StaticAttack breath in right)
			{
				breath.StartAttack();
			}
		}
	}
	#endregion
}
