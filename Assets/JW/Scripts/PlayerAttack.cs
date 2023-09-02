using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	#region PublicVariables
	public bool isAttack;
	#endregion

	#region PrivateVariables
	private Animator anim;

	#endregion

	#region PublicMethod
	public void Attack()
	{
        if (isAttack)
        {
			if (anim.GetBool("jump") == true)
				return;
			anim.SetBool("attack", true);
		}
	}
	#endregion

	#region PrivateMethod
	private void Awake()
	{
		transform.Find("Renderer").TryGetComponent(out anim);
	}

    private void Update()
    {
		Attack();
	}
    #endregion
}
