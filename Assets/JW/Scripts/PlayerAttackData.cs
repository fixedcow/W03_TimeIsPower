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
		Collider2D col = Physics2D.OverlapArea((Vector2)transform.position + source.transform.localScale.x * pointA
			, (Vector2)transform.position + source.transform.localScale.x * pointB, 1 << LayerMask.NameToLayer("Enemy"));
		if (col != null)
		{
			Boss boss;
			Zombie zombie;
			Lever lever;
			if (col.TryGetComponent(out boss) == true)
			{
				boss.Hit(damage, source);
			}
			if (col.TryGetComponent(out lever) == true)
			{
				lever.Hit();
			}
			if (col.TryGetComponent(out zombie) == true)
			{
				zombie.HitZombie(damage, source);
			}
		}
	}
	#endregion

	#region PrivateMethod
	#endregion
}
