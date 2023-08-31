using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodge : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	private Animator anim;
	private Rigidbody2D rb;
	private Player main;
	[SerializeField] private ParticleSystem ps;

	[SerializeField] private float dodgeForce;
	[SerializeField] private float dodgeDuration;
	[SerializeField] private float dodgeCooldown;
	[SerializeField] private float wallRayLength;
	
	private bool isReady = true;
	#endregion

	#region PublicMethod
	public void Dodge()
	{
		if(isReady == false)
		{
			return;
		}
		isReady = false;
		anim.SetBool("dodge", true);
		rb.bodyType = RigidbodyType2D.Kinematic;
		rb.velocity = Vector2.right * transform.localScale.x * dodgeForce;
		ps.transform.localScale = transform.localScale;
		ps.Play();
		main.SetInvincibility(true);

		Invoke(nameof(DodgeReady), dodgeCooldown);
		Invoke(nameof(DodgeEnd), dodgeDuration);
	}
	public void ForceDodgeEnd()
	{
		CancelInvoke(nameof(DodgeEnd));
		DodgeEnd();
	}
	#endregion

	#region PrivateMethod
	private void Awake()
	{
		transform.Find("Renderer").TryGetComponent(out anim);
		TryGetComponent(out rb);
		TryGetComponent(out main);
	}
	private void FixedUpdate()
	{
		if(rb.bodyType == RigidbodyType2D.Kinematic)
			CheckWall();
	}
	private void CheckWall()
	{
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, wallRayLength, 1 << LayerMask.NameToLayer("Wall"));
		Debug.DrawRay(transform.position, Vector2.right * transform.localScale.x * wallRayLength, Color.red);
		if(hit.collider != null)
		{
			ForceDodgeEnd();
			ps.Stop();
		}
	}
	private void DodgeEnd()
	{
		rb.velocity = Vector2.zero;
		rb.bodyType = RigidbodyType2D.Dynamic;
		main.SetInvincibility(false);
	}
	private void DodgeReady()
	{
		isReady = true;
	}
	#endregion
}
