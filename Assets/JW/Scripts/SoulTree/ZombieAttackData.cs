using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackData : MonoBehaviour
{
	[Header("좀비 공격 관련")]
	[SerializeField] private GameObject source;
	[SerializeField] private int damage;
	[SerializeField] private Vector2 pointA;
	[SerializeField] private Vector2 pointB;
	public void OnZombieAttackAnimationImpact()
	{
		Collider2D[] cols = Physics2D.OverlapAreaAll((Vector2)transform.position + source.transform.localScale.x * pointA
			, (Vector2)transform.position + source.transform.localScale.x * pointB, 1 << LayerMask.NameToLayer("Brazier"));
		if (cols.Length > 0)
		{
			foreach (Collider2D col in cols)
			{
				Brazier brazier;
				if (col.TryGetComponent(out brazier) == true)
				{
					brazier.Hit(damage, source);
				}
				

			}
		}
	}
}
