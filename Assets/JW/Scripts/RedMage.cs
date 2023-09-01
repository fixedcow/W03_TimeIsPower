using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMage : Boss
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	[SerializeField] private List<Vector2> teleportPosition = new List<Vector2>();
	private int teleportIndex = 0;
	#endregion

	#region PublicMethod
	public void Teleport()
	{
		if(teleportIndex >= teleportPosition.Count - 1)
		{
			teleportIndex = 0;
		}
		else
		{
			++teleportIndex;
		}
		transform.position = teleportPosition[teleportIndex];
	}
	public void TeleportRandomly()
	{
		transform.position = teleportPosition[Random.Range(0, teleportPosition.Count)];
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
