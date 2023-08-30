using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class BossHpGUI : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	[SerializeField] private BossHpFillGUI red;
	[SerializeField] private BossHpFillGUI yellow;

	private float percentage
	{
		get
		{
			return Mathf.Clamp01((float)hpCurrent / hpMax);
		}
	}
	private int hpMax;
	private int hpCurrent;
	#endregion

	#region PublicMethod
	public void Initialize(int _hpMax)
	{
		hpMax = _hpMax;
		hpCurrent = hpMax;
	}
	public void SetHp(int _currentHp)
	{
		hpCurrent = _currentHp;
		red.SetTargetValue(percentage);
		yellow.SetTargetValue(percentage);
	}
	#endregion

	#region PrivateMethod
	#endregion
}
