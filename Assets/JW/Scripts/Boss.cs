using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.ComponentModel;
using Sirenix.OdinInspector;
using ReadOnly = Sirenix.OdinInspector.ReadOnlyAttribute;

public abstract class Boss : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables

	private GameObject rend;
	private Animator anim;
	private Sequence hitSeq;

	[ReadOnly] [SerializeField] private int hpCurrent;
	[SerializeField] private int hpMax;
	#endregion

	#region PublicMethod
	public int GetMaxHp() => hpMax;
	public virtual void Initialize()
	{
		hpCurrent = hpMax;
	}
	[Button]
	public virtual void Hit(int _damage, GameObject _source)
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
	protected void Awake()
	{
		rend = transform.Find("renderer").gameObject;
		transform.Find("renderer").TryGetComponent(out anim);
	}
	protected void Start()
	{
		hitSeq = DOTween.Sequence()
			.SetAutoKill(false)
			.Append(transform.DOShakePosition(0.1f, 0.2f))
			.Pause();
		Initialize();
	}
	#endregion
}
