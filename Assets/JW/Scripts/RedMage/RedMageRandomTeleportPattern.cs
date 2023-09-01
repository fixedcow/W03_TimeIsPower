using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMageRandomTeleportPattern : BossPattern
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	[SerializeField] private List<Vector2> teleportPosition = new List<Vector2>();
	#endregion

	#region PublicMethod
	#endregion

	#region PrivateMethod
	protected override void ActionContext()
	{
		transform.position = teleportPosition[Random.Range(0, teleportPosition.Count)];
	}
	#endregion
}
