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
	public string bossName;
	#endregion

	#region PrivateVariables
	protected Animator anim;
	private GameObject rend;
	private Sequence hitSeq;

	[SerializeField] private Vector2 respawnPoint;
	[ReadOnly] [SerializeField] protected int hpCurrent;
	[SerializeField] protected int hpMax;
	[SerializeField] protected BossPattern startPattern;
	[SerializeField] protected List<BossPattern> patternList = new List<BossPattern>();
	[SerializeField] protected List<StaticAttack> initAttackList = new();
	[SerializeField] private GameObject halo;
	[ReadOnly] [SerializeField] protected int patternIndex;
	[ReadOnly][SerializeField] protected BossPattern currentPattern;
	#endregion

	#region PublicMethod
	public Animator GetAnimator() => anim;
	public int GetMaxHp() => hpMax;
	public virtual void Initialize()
	{
		hpCurrent = hpMax;
		patternIndex = -1;
	}
	public virtual void Hit(int _damage, GameObject _source)
	{
		if (hpCurrent <= 0)
		{
			GameManager.instance.GetPlayer().CanNotAct();
			halo.SetActive(false);
			ShutdownAction();
			foreach (StaticAttack attack in initAttackList)
			{
				attack.InitAttack();
			}
			transform.Find("renderer").TryGetComponent(out anim);
			anim.Play("Die");
			Invoke("BossKilled", 3f);
			DynamicObjectManager.instance.EndClear();
		}
        else
        {
			hitSeq.Restart();
			hpCurrent = Mathf.Clamp(hpCurrent - _damage, 0, hpMax);
			BossHpGUI.instance.SetHp(hpCurrent);
		}
		
		
	}
	public void BossKilled()
	{
		GameManager.instance.GameClear();

	}
	[Button]
	public void PatternStart()
	{
		currentPattern = startPattern; 
		currentPattern.Act().Forget();
	}
	public void PatternNext()
	{
		patternIndex = GetNextPatternIndex(patternIndex);
		currentPattern = patternList[patternIndex];
		currentPattern.Act().Forget();
	}
	public void ShutdownAction()
	{
		currentPattern.ShutdownAction();
	}
	#endregion

	#region PrivateMethod
	protected virtual void Awake()
	{
		rend = transform.Find("renderer").gameObject;
		transform.Find("renderer").TryGetComponent(out anim);
	}
	protected virtual void OnEnable()
	{
		transform.position = respawnPoint;
	}
	protected virtual void Start()
	{
		hitSeq = DOTween.Sequence()
			.SetAutoKill(false)
			.Append(rend.transform.DOShakePosition(0.1f, 0.3f))
			.Pause();
		Initialize();
	}
	private int GetNextPatternIndex(int _currentIndex)
	{
		int result = _currentIndex;
		if(result >= patternList.Count - 1)
		{
			result = 0;
		}
		else
		{
			++result;
		}
		return result;
	}
	#endregion
}
