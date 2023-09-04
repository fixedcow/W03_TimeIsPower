using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueKnight : Boss
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	[SerializeField] GameObject rageVersion;
	[Range(0, 1)][SerializeField] private float ragePercentage;
	#endregion

	#region PublicMethod
	public override void Hit(int _damage, GameObject _source)
	{
		base.Hit(_damage, _source);
		if (hpCurrent < hpMax * ragePercentage)
		{
			RageBlueKnight rage;
			rageVersion.TryGetComponent(out rage);
			rage.SetHpSameWithMain(hpCurrent, hpMax);
			rageVersion.transform.position = transform.position;
			gameObject.SetActive(false);
			rageVersion.SetActive(true);
			rage.PatternStart();
		}
	}
	public override void BossKilled()
	{

	}
	#endregion

	#region PrivateMethod
	#endregion
}
