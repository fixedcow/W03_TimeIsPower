using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NeoBoss : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	private List<Vector2> patternPosition = new List<Vector2>();
	[SerializeField] private GameObject rend;
	[SerializeField] private Animator anim;
	private bool isRage;

	private int hpMax;
	private int hpCurrent;
	#endregion

	#region PublicMethod
	public void Initialize()
	{

	}
	public void Hit()
	{

	}
	public void Move()
	{

	}
	#endregion

	#region PrivateMethod
	private void Die()
	{

	}
	#endregion
}
