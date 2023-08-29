using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerDodge), typeof(PlayerMove), typeof(PlayerJump))]
public class Player : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	private PlayerAction input;

	private PlayerDodge dodge;
	private PlayerMove move;
	private PlayerJump jump;
	private PlayerAttack attack;

	private bool isInvincible;
	#endregion

	#region PublicMethod
	public void Hit()
	{

	}
	public void SetInvincibility(bool b) => isInvincible = b;
	#endregion

	#region PrivateMethod
	private void Awake()
	{
		input = new PlayerAction();
		TryGetComponent(out dodge);
		TryGetComponent(out move);
		TryGetComponent(out jump);
		TryGetComponent(out attack);
	}
	private void OnEnable()
	{
		input.Enable();
		input.Player.Move.performed += Move;
		input.Player.Move.canceled += MoveCanceled;
		input.Player.Attack.performed += Attack;
		input.Player.Dodge.performed += Dodge;
		input.Player.Jump.performed += Jump;
	}
	private void OnDisable()
	{
		input.Player.Move.performed -= Move;
		input.Player.Move.canceled -= MoveCanceled;
		input.Player.Attack.performed -= Attack;
		input.Player.Dodge.performed -= Dodge;
		input.Player.Jump.performed -= Jump;
		input.Disable();
	}
	private void Move(InputAction.CallbackContext _context)
	{
		move.Move((int)_context.ReadValue<Vector2>().x);
	}
	private void MoveCanceled(InputAction.CallbackContext _context)
	{
		move.MoveCanceled();
	}
	private void Jump(InputAction.CallbackContext _context)
	{
		jump.Jump();
	}
	private void Attack(InputAction.CallbackContext _context)
	{
		attack.Attack();
	}
	private void Dodge(InputAction.CallbackContext _context)
	{
		dodge.Dodge();
	}

	#endregion
}
