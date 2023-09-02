using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading;
using Cysharp.Threading.Tasks;
using System.Threading;

public abstract class BossPattern : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	private Boss main;
	protected Animator anim;
	[SerializeField] protected string animationStateName;
	[SerializeField] protected int preDelayMilliSeconds;
	[SerializeField] protected int postDelayMilliSeconds;

	protected CancellationTokenSource preDelaySource = new CancellationTokenSource();
	protected CancellationTokenSource postDelaySource = new CancellationTokenSource();
	#endregion

	#region PublicMethod
	public async UniTaskVoid Act()
	{
		PlayAnimation();
		await UniTask.Delay(preDelayMilliSeconds, cancellationToken: preDelaySource.Token);
		ActionContext();
		await UniTask.Delay(postDelayMilliSeconds, cancellationToken: postDelaySource.Token);
		CallNextAction();
	}
	public void CallNextAction()
	{
		main.PatternNext();
	}
	#endregion

	#region PrivateMethod
	protected void Awake()
	{
		TryGetComponent(out main);
	}
	private void Start()
	{
		anim = main.GetAnimator();
	}
	protected virtual void OnEnable()
	{
		if (preDelaySource != null)
			preDelaySource.Dispose();
		preDelaySource = new CancellationTokenSource();
		if(postDelaySource != null)
			postDelaySource.Dispose();
		postDelaySource = new CancellationTokenSource();
	}
	protected virtual void OnDisable()
	{
		preDelaySource.Cancel();
		postDelaySource.Cancel();
	}
	private void PlayAnimation()
	{
		if (animationStateName != "")
		{
			//TODO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
			transform.Find("renderer").TryGetComponent(out anim);
			anim.Play(animationStateName);
		}
	}
	protected abstract void ActionContext();
	#endregion
}
