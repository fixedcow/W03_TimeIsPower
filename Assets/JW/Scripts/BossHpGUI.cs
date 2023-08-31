using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class BossHpGUI : MonoBehaviour
{
	#region PublicVariables
	public static BossHpGUI instance;
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
	public void HideGUI()
	{
		gameObject.SetActive(false);
	}
	public void Initialize()
	{
		SetMaxHp(GameManager.instance.GetBoss().maxHp);

		gameObject.SetActive(true);
	}
	public void SetMaxHp(int _hpMax)
	{
		hpMax = _hpMax;
		hpCurrent = hpMax;
		red.SetTargetValue(percentage);
		yellow.SetTargetValue(percentage);
	}
	public void SetHp(int _currentHp)
	{
		hpCurrent = _currentHp;
		red.SetTargetValue(percentage);
		yellow.SetTargetValue(percentage);
	}
	#endregion

	#region PrivateMethod
	private void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
	}
	private void Start()
	{
		Initialize();
		HideGUI();
	}
	#endregion
}
