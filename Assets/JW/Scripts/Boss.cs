using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.ComponentModel;
using Sirenix.OdinInspector;
using ReadOnly = Sirenix.OdinInspector.ReadOnlyAttribute;

public class Boss : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables

	private GameObject rend;
	private Animator anim;
	private Sequence hitSeq;

	private bool isRage;

	[ReadOnly] [SerializeField] private int hpCurrent;
	[SerializeField] private int hpMax;
	#endregion

	#region PublicMethod
	public void Initialize()
	{
		hpCurrent = hpMax;
	}
	[Button]
	public void Hit(int _damage, Player _source)
	{
		hitSeq.Restart();
		hpCurrent = Mathf.Clamp(hpCurrent - _damage, 0, hpMax);
		BossHpGUI.instance.SetHp(hpCurrent);
		if(hpCurrent == 0)
		{
			BossKilled();
		}
	}
	public void BossKilled()
	{

	}
	#endregion

	#region PrivateMethod
	private void Awake()
	{
		rend = transform.Find("renderer").gameObject;
		transform.Find("renderer").TryGetComponent(out anim);
	}
	private void Start()
	{
		hitSeq = DOTween.Sequence()
			.SetAutoKill(false)
			.Append(transform.DOShakePosition(0.1f, 0.15f))
			.Pause();
	}
	private void Die()
	{

	}
	#endregion
}
