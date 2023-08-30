using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class ButtonGUI : MonoBehaviour
{
	#region PublicVariables
	public UnityEvent onButtonClicked;
	#endregion

	#region PrivateVariables
	private bool isOver;
	private bool isDown;
	#endregion

	#region PublicMethod
	#endregion

	#region PrivateMethod
	private void OnMouseEnter()
	{
		isOver = true;
		transform.DOScale(1.05f, 0.1f);
	}
	private void OnMouseExit()
	{
		isOver = false;
		transform.DOScale(1f, 0.1f);
	}
	private void OnMouseDown()
	{
		isDown = true;
		transform.DOScale(0.95f, 0.1f);
	}
	private void OnMouseUp()
	{
		if(isOver == true && isDown == true)
		{
			transform.DOScale(1f, 0.2f).From(1.1f);
			onButtonClicked.Invoke();
		}
		isDown = false;
	}
	#endregion
}
