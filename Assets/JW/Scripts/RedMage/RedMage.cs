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
			rageVersion.transform.position = transform.position;
			rageVersion.SetActive(true);
			gameObject.SetActive(false);
		}
	}
	#endregion

	#region PrivateMethod
	#endregion
}
