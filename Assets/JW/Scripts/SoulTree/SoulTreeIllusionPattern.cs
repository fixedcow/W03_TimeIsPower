using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class SoulTreeIllusionPattern : BossPattern
{
    [SerializeField] private GameObject illusionPrefab;
    [SerializeField] private int illusionCount;
    [SerializeField] private float illusionDelay;
    [SerializeField] private float illusionDelayInterval;
    [SerializeField] private Vector3 illusionStartPosition;

    [Button]
    protected override void ActionContext()
    {
        float angleSpace = 360f / illusionCount;
        float angle = 0;
        for(int i = 0; i < illusionCount; i++)
        {
            GameObject illusion = Instantiate(illusionPrefab);
            illusion.GetComponent<Illusion>().SetIllusion(illusionStartPosition, angle, illusionDelay + i* illusionDelayInterval);
            angle += angleSpace;
            DynamicObject dynamic = illusion.GetComponent<DynamicObject>();
            DynamicObjectManager.instance.objects.Add(dynamic);

        }
    }
}
