using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCounter : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	[SerializeField] private SpriteRenderer sr;
	[SerializeField] private Sprite[] sprites;

	private int index = -1;
	#endregion

	#region PublicMethod
	public bool AddCount()
	{
		if(index < sprites.Length - 1)
		{
			++index;
			sr.sprite = sprites[index];
			return true;
		}
		else
		{
			return false;
		}
	}
	#endregion

	#region PrivateMethod
	private void Awake()
	{
		TryGetComponent(out sr);
	}
	#endregion
}
