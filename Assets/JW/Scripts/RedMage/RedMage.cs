using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RedMage : Boss
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	[SerializeField] GameObject rageVersion;
	#endregion

	#region PublicMethod
	public override void Hit(int _damage, GameObject _source)
	{
		base.Hit(_damage, _source);
		if(hpCurrent < hpMax * 3 / 10)
		{
			RageRedMage rage;
			rageVersion.TryGetComponent(out rage);
			rage.SetHpSameWithMain(hpCurrent, hpMax);
			rageVersion.transform.position = transform.position;
			gameObject.SetActive(false);
			rageVersion.SetActive(true);
			rage.PatternStart();
		}
	}
	#endregion

	#region PrivateMethod
	#endregion
}
