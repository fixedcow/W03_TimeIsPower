using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMage : Boss
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	[SerializeField] private List<Vector2> patternPosition = new List<Vector2>();
	#endregion

	#region PublicMethod
	public void Teleport()
	{

	}
	public void TeleportRandomly()
	{
		transform.position = patternPosition[Random.Range(0, patternPosition.Count)];
	}
	public void Fireball()
	{

	}
	public void Magmaball()
	{

	}
	public void Firebreath()
	{

	}
	public void Firewall()
	{

	}
	#endregion

	#region PrivateMethod
	#endregion
}
