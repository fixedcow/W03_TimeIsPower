using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMageFireballPattern : BossPattern
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	[SerializeField] public GameObject fireball;
	Transform _player;
	[SerializeField] private float delay;
	[SerializeField] private float speed;
    #endregion

    #region PublicMethod
    
    #endregion

    #region PrivateMethod
    protected override void OnEnable()
    {
        base.OnEnable();
    }
    protected override void ActionContext()
    {
        GameObject go =  Instantiate(fireball, (Vector2)this.transform.position + Vector2.up * 3f, Quaternion.identity);
		go.GetComponent<Fireball>().SetInitStat(delay, speed);
        DynamicObjectManager.instance.objects.Add(go);
    }
    #endregion
}
