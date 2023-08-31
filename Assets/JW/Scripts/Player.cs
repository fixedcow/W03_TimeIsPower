using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;
using Sirenix.OdinInspector;

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
	private bool isPressedDown;
	[SerializeField] private bool canAct = false;
	
	#endregion

	#region PublicMethod
	[Button]
	public void Hit()
	{
		if(isInvincible == false)
		{
			GameManager.instance.GameOver();
			GameManager.instance.BattleEnd();
			GameManager.instance.GetBoss().ResetParameter();
		}
	}
	public void SetInvincibility(bool b) => isInvincible = b;
	public void CanAct() => canAct = true;
	public void CanNotAct() => canAct = false;
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
		input.Player.Down.performed += Down;
		input.Player.Down.canceled += DownCanceled;
	}
	private void OnDisable()
	{
		input.Player.Move.performed -= Move;
		input.Player.Move.canceled -= MoveCanceled;
		input.Player.Attack.performed -= Attack;
		input.Player.Dodge.performed -= Dodge;
		input.Player.Jump.performed -= Jump;
		input.Player.Down.performed -= Down;
		input.Player.Down.canceled -= DownCanceled;
		input.Disable();
	}
	private void Move(InputAction.CallbackContext _context)
	{
		if (canAct == false)
			return;
		move.Move((int)_context.ReadValue<Vector2>().x);
	}
	private void MoveCanceled(InputAction.CallbackContext _context)
	{
		move.MoveCanceled();
	}
	private void Jump(InputAction.CallbackContext _context)
	{
		if (canAct == false)
			return;
		if (isPressedDown == true)
		{
			jump.DownJump();
		}
		else
		{
			jump.Jump();
		}
	}
	private void Attack(InputAction.CallbackContext _context)
	{
		if (canAct == false)
			return;
		attack.Attack();
	}
	private void Dodge(InputAction.CallbackContext _context)
	{
		if (canAct == false)
			return;
		dodge.Dodge();
	}
	private void Down(InputAction.CallbackContext _context)
	{
		if (canAct == false)
			return;
		isPressedDown = true;
	}
	private void DownCanceled(InputAction.CallbackContext _context)
	{
		isPressedDown = false;
	}
	
	#endregion
}
