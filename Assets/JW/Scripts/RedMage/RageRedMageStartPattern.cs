using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageRedMageStartPattern : BossPattern
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	[SerializeField] private StaticAttack groundFire;
	#endregion

	#region PublicMethod

	#endregion

	#region PrivateMethod
	protected override void ActionContext()
	{
		groundFire.StartAttack();
	}
	#endregion
}
