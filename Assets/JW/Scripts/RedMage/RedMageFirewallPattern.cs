using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Sirenix.OdinInspector;

public class RedMageFirewallPattern : BossPattern
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	[SerializeField] List<StaticAttack> firewalls = new List<StaticAttack>();
    [SerializeField] int activeWallCount;
	#endregion

	#region PublicMethod
	#endregion

	#region PrivateMethod
	[Button]
    protected override void OnDisable()
    {
        base.OnDisable();
        foreach (StaticAttack attack in firewalls)
        {
            attack.InitAttack();
        }
    }
	[Button]
    protected override void ActionContext()
    {
		List<StaticAttack> deepcopyList = firewalls.ToList();

		for(int i = 0; i < activeWallCount;)
		{
			int rand = Random.Range(0, deepcopyList.Count);
			if(rand == 1 || rand == 2)
			{
				deepcopyList[rand].StartAttack();
				deepcopyList.RemoveAt(1);
				deepcopyList.RemoveAt(1);
				++i;
			}
			else
			{
				deepcopyList[rand].StartAttack();
				deepcopyList.RemoveAt(rand);
				++i;
			}
		}
    }
    #endregion
}
