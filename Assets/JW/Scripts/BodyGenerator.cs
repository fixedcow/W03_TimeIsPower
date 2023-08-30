using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class BodyGenerator : MonoBehaviour
{
	#region PublicVariables
	public static BodyGenerator Instance;
	#endregion

	#region PrivateVariables
	[SerializeField] private GameObject bodyPrefab;
	private List<GameObject> bodies = new List<GameObject>();
	#endregion

	#region PublicMethod
	public void SpawnBody(Transform _transform, Vector2 _velocity, bool isGhost = true)
	{
		GameObject current = GetPrefab();
		current.transform.position = _transform.position;
		current.transform.localScale = _transform.localScale;
		Body body;
		current.TryGetComponent(out body);
		body.SetVelocity(_velocity);
		body.SetTransparency(isGhost);
	}
	#endregion

	#region PrivateMethod
	private void Awake()
	{
		if (Instance == null)
			Instance = this;
	}
	private GameObject GetPrefab()
	{
		GameObject current = null;
		for(int i = 0; i < bodies.Count; ++i)
		{
			if (bodies[i].activeSelf == false)
			{
				current = bodies[i];
				break;
			}
		}
		if(current == null)
		{
			current = Instantiate(bodyPrefab, transform) as GameObject;
			bodies.Add(current);
			return current;
		}
		else
		{
			current.SetActive(true);
			return current;
		}
	}
	#endregion
}
