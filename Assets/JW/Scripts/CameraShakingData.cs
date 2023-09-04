using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Camera shaking data", fileName = "New Camera shaking data")]
public class CameraShakingData : ScriptableObject
{
	public float duration;
	public float strength;
	public int vibrato;
	public float randomness;
}
