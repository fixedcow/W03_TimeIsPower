using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class DeathCounterManager : MonoBehaviour
{
	#region PublicVariables
	public static DeathCounterManager instance;
	public int count { get; private set; }
	#endregion

	#region PrivateVariables
	[SerializeField] private GameObject deathCountPrefab;
	[SerializeField] private List<DeathCounter> deathCounters = new List<DeathCounter>();

	[SerializeField] private float posXRange;
	[SerializeField] private float posYRange;
	[SerializeField] private DeathCounter current;
	#endregion

	#region PublicMethod
	[Button]
	public void PlayerDead()
	{
		if (current.AddCount() == false)
		{
			current = InstantiateCount();
			current.AddCount();
		}
	}
	#endregion

	#region PrivateMethod
	private void Awake()
	{
		if (instance == null)
			instance = this;
	}
	private DeathCounter InstantiateCount()
	{
		DeathCounter result = Instantiate(deathCountPrefab
			, (Vector2)transform.position + new Vector2(Random.Range(-posXRange, posXRange), Random.Range(-posYRange, posYRange))
			, Quaternion.Euler(new Vector3(0, 0, Random.Range(-30, 30))), transform).GetComponent<DeathCounter>();
		deathCounters.Add(result);

		return result;
	}
	#endregion
}
