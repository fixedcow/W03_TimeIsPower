using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class BossHpFillGUI : MonoBehaviour
{
	#region PublicVariables
	public enum EType
	{
		red = 0,
		yellow = 1
	}
	#endregion

	#region PrivateVariables
	[SerializeField] private SpriteRenderer sr;
	private Material material;

	[SerializeField] EType type;
	private float targetValue;
	private float currentValue;
	[SerializeField] private float speedMult;
	[SerializeField] bool isYellow;
	#endregion

	#region PublicMethod
	#endregion
	public void Initialize()
	{
		targetValue = 0f;
		currentValue = 0f;
	}
	public void SetTargetValue(float _value)
	{
		targetValue = _value;
	}

	#region PrivateMethod
	private void OnEnable()
	{
		material = sr.material;
	}
	private void Update()
	{
		SetCurrentToTargetValue();
	}
	private void SetCurrentToTargetValue()
	{
		if(type == EType.red)
		{
			currentValue = targetValue;
		}
		else
		{
			if(targetValue > currentValue)
			{
				currentValue = targetValue;
			}
			currentValue = Mathf.Lerp(currentValue, targetValue, speedMult * Time.deltaTime);
		}
		material.SetFloat("_ClipUvRight", 1 - currentValue);
	}
	#endregion
}
