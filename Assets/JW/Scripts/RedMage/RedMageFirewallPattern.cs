using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMageFirewallPattern : BossPattern
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	[SerializeField] List<StaticAttack> firewalls = new List<StaticAttack>();
	#endregion

	#region PublicMethod
	#endregion

	#region PrivateMethod
	protected override void ActionContext()
	{
		firewalls[Random.Range(0, firewalls.Count - 1)].StartAttack();
	}
	#endregion
}
