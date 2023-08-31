using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackData : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	[SerializeField] private Vector2 pointA;
	[SerializeField] private Vector2 pointB;

	private Collider2D[] cols = new Collider2D[0];
	#endregion

	#region PublicMethod
	public void OnAttackAnimationImpact()
	{
		Physics2D.OverlapAreaNonAlloc((Vector2)transform.position + transform.localScale.x * pointA
			, (Vector2)transform.position + transform.localScale.x * pointB, cols
			, 1 << LayerMask.NameToLayer("Enemy"));
		if (cols.Length > 0)
		{
			foreach (Collider2D col in cols)
			{
				GameManager.instance.GetBoss().HP--;
			}
		}
	}
	#endregion

	#region PrivateMethod
	#endregion
}
