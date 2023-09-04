using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueKnightMovePattern : BossPattern
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	private BlueKnightMove move;
	#endregion

	#region PublicMethod
	#endregion

	#region PrivateMethod
	protected override void Awake()
	{
		base.Awake();
		TryGetComponent(out move);
	}
	protected override void ActionContext()
	{
	}
	protected override void PreProcessing()
	{
		base.PreProcessing();
		preDelayMilliSeconds = Random.Range(200, 800);
		postDelayMilliSeconds = Random.Range(300, 800);
		move.CanAct();
	}
	protected override void PostProcessing()
	{
		base.PostProcessing();
		move.CanNotAct();
	}
	#endregion
}
