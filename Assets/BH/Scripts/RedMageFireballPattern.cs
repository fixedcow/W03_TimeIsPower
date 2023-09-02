using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMageFireballPattern : BossPattern
{
    #region PublicVariables
    [HideInInspector] public GameObject fireball;
    #endregion

    #region PrivateVariables
    Transform _player;
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
        DynamicObjectManager.instance.objects.Add(go);
    }
    #endregion
}
