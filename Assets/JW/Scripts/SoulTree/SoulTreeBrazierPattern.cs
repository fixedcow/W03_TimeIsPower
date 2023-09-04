using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class SoulTreeBrazierPattern : BossPattern
{
    [SerializeField] private GameObject zombiePrefab;
    [SerializeField] private Vector3 zombieSpawnPoint;
    [SerializeField] List<Vector3> brazierPosList = new();

    [Button]
    protected override void ActionContext()
    {
        GameObject zombie = Instantiate(zombiePrefab, zombieSpawnPoint, Quaternion.identity);
        Vector3 pos = brazierPosList[Random.Range(0, brazierPosList.Count)];
        zombie.GetComponent<Zombie>().SetBrazierPosition(pos);
    }

}
