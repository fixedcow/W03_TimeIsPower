using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEnterTrigger : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	#endregion

	#region PublicMethod
	#endregion

	#region PrivateMethod
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			GameManager.instance.BattleStart();
			gameObject.SetActive(false);
		}
	}
	#endregion
}
