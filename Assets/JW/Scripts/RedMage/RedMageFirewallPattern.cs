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
        int randonCount = 0;
        List<int> indexList = new();
        while (randonCount < activeWallCount)
        {
            int rand = GetRandom();

            if (indexList.Contains(rand))
            {
                break;
            }

            indexList.Add(rand);
            randonCount++;
        }

        
        foreach (int i in indexList)
        {
            Debug.Log(i);
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
