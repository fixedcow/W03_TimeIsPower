using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	private Animator anim;
	private Rigidbody2D rb;

	[SerializeField] private float moveSpeed;
	[SerializeField] private float linearDrag;
	#endregion

	#region PublicMethod
	public void Move(int _direction)
	{
		transform.localScale = new Vector3(_direction, 1, 1);
		anim.SetBool("move", true);
	}
	public void MoveCanceled()
	{
		anim.SetBool("move", false);
	}
	#endregion

	#region PrivateMethod
	private void Awake()
	{
		transform.Find("Renderer").TryGetComponent(out anim);
		TryGetComponent(out rb);
	}
	private void Update()
	{
		MovePlayer();
	}
	private void MovePlayer()
	{
		if (anim.GetBool("move") == true
			&& anim.GetBool("attack") == false
			&& rb.bodyType == RigidbodyType2D.Dynamic )
		{
			rb.velocity = new Vector2(transform.localScale.x * moveSpeed, rb.velocity.y);
		}
		else if(rb.bodyType == RigidbodyType2D.Dynamic)
		{
			float velocityX = Mathf.Lerp(rb.velocity.x, 0, linearDrag * Time.deltaTime);
			rb.velocity = new Vector2(velocityX, rb.velocity.y);
		}
	}


	#endregion
}
