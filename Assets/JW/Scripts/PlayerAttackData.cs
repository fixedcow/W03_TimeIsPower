using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackData : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	[SerializeField] private GameObject source;
	[SerializeField] private int damage;
	[SerializeField] private Vector2 pointA;
	[SerializeField] private Vector2 pointB;

	#endregion

	#region PublicMethod
	public void OnAttackAnimationImpact()
	{
		Collider2D[] cols = Physics2D.OverlapAreaAll((Vector2)transform.position + source.transform.localScale.x * pointA
			, (Vector2)transform.position + source.transform.localScale.x * pointB, 1 << LayerMask.NameToLayer("Enemy"));
		if (cols.Length > 0)
		{
			foreach (Collider2D col in cols)
			{
				Boss boss;
				Lever _switch;
				if(col.TryGetComponent(out boss) == true)
				{
					boss.Hit(damage, source);
				}
				if(col.TryGetComponent(out _switch) == true)
				{
					_switch.Hit();
				}
				
			}
		}
	}
	#endregion

	#region PrivateMethod
	#endregion
}
