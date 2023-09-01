using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;

public class BossHpGUI : MonoBehaviour
{
	#region PublicVariables
	public static BossHpGUI instance;
	public TextMeshPro text;
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
	public void ShowGUI()
	{
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
	public void SetBossNameText(string _str)
	{
		text.text = _str;
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
		ShowGUI();
		HideGUI();
	}
	#endregion
}
