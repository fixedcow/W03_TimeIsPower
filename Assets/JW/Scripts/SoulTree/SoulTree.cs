using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulTree : Boss
{
    [SerializeField] GameObject rageVersion;
    [Range(0, 1)] [SerializeField] private float ragePercentage;

	public override void Hit(int _damage, GameObject _source)
	{
		base.Hit(_damage, _source);
		if (hpCurrent < hpMax * ragePercentage)
		{
			RageSoulTree rage;
			rageVersion.TryGetComponent(out rage);
			rage.SetHpSameWithMain(hpCurrent, hpMax);
			rageVersion.transform.position = transform.position;
			gameObject.SetActive(false);
			rageVersion.SetActive(true);
			rage.PatternStart();
		}
	}
}
