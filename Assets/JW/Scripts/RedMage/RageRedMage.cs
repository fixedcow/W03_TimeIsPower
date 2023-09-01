using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageRedMage : Boss
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	#endregion

	#region PublicMethod
	#endregion

	#region PrivateMethod
	private void OnEnable()
	{
		hpCurrent = hpMax * 3 / 10;
		BossHpGUI.instance.SetBossNameText(bossName);
		BossHpGUI.instance.SetHp(hpCurrent);
		GameManager.instance.SetBoss(this);
		PatternStart();
	}
	#endregion
}
