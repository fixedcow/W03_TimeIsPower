using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    protected override void OnDisable()
    {
        base.OnDisable();
        foreach (StaticAttack attack in firewalls)
        {
            attack.InitAttack();
        }
    }
    protected override void ActionContext()
    {
        int randomCount = 0;
        List<int> indexList = new();
        while (randomCount < activeWallCount)
        {
            int rand = GetRandom();

            if (indexList.Contains(rand))
            {
                break;
            }

            indexList.Add(rand);
			if(rand == 1)
			{
				indexList.Add(2);
			}
			else if(rand == 2)
			{
				indexList.Add(1);
			}
            randomCount++;
        }

        
        foreach (int i in indexList)
        {
            firewalls[i].StartAttack();
        }
    }

    private int GetRandom()
    {
        System.Random random = new System.Random();
        return random.Next(0, firewalls.Count);
    }
    #endregion
}
