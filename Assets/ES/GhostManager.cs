using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostManager : MonoBehaviour
{
	#region PublicVariables
	public static GhostManager instance;
	#endregion

	#region PrivateVariables
	[SerializeField] private float intervalTime;
	private GhostRecorder recorder;
	private GhostReplayer replayer;
	#endregion

	public GhostReplayer GetReplayer() => replayer;
	#region PublicMethod
	public void RecordAndReplay()
	{
		recorder.Record();
		replayer.Replay();
	}
	public void StopRecordAndReplay()
	{
		recorder.StopRecord();
		replayer.StopReplay();
	}
	#endregion

	#region PrivateMethod
	private void Awake()
	{
		if(instance == null)
			instance = this;
		TryGetComponent(out recorder);
		TryGetComponent(out replayer);
	}
	private void Start()
	{
		recorder.SetReplayer(replayer);
		recorder.SetInterval(intervalTime);
		replayer.SetInterval(intervalTime);
	}
	#endregion
}
