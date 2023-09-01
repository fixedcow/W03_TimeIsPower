using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : BossPattern
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	[SerializeField] private List<Vector2> teleportPosition = new List<Vector2>();
	private int index = 0;
	#endregion

	#region PublicMethod
	#endregion

	#region PrivateMethod
	protected override void OnEnable()
	{
		base.OnEnable();
		index = 0;
	}
	protected override void ActionContext()
	{
		if (index >= teleportPosition.Count - 1)
		{
			index = 0;
		}
		else
		{
			++index;
		}
		transform.position = teleportPosition[index];
	}
	#endregion
}
