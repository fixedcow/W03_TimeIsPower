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
	public bool isPlayerDead;

	[SerializeField] private GameObject fadeScreen;
	[SerializeField] private float fadeMiddlePositionX;
	[SerializeField] private float fadeEndPositionX;
	[SerializeField] private Vector3 fadeStartPosition;
	[SerializeField] private float fadeTime;
	[SerializeField] private float restartInterval;
	[SerializeField] private Vector3 startPlayerPosition;
	[SerializeField] private Vector3 startCameraPosition;
	[SerializeField] private GameObject stageEnterTrigger;
	#endregion

	#region PublicMethod
	[Button]
	public void Hit()
	{
		if(isInvincible == false)
		{
			PlayerGameOver();
			Invoke(nameof(PlayerRestart), restartInterval);
			GameManager.instance.BattleEnd();

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
	private void PlayerGameOver()
	{
		isPlayerDead = true;
		//transform.position = startPlayerPosition;
		fadeScreen.transform.DOLocalMoveX(fadeMiddlePositionX, fadeTime)
			 .OnComplete(() =>
			 {
				 Camera.main.GetComponent<CameraController>().enabled = false;
				 Camera.main.transform.position = startCameraPosition;
				 transform.position = startPlayerPosition;
				 fadeScreen.transform.DOLocalMoveX(fadeEndPositionX, fadeTime)
				 .OnComplete(() =>
				 {
					 fadeScreen.transform.localPosition = fadeStartPosition;
				 });
			 });
	}

	private void PlayerRestart()
	{
		stageEnterTrigger.SetActive(true);
		isPlayerDead = false;
	}
	#endregion
}
