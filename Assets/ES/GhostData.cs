using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostData : MonoBehaviour
{
    public Transform ghostTransform;
    public Animator ghostAnimator;
    public List<Vector3> recordPosition = new List<Vector3>();
    public List<bool> dodgeTrigger= new List<bool>();
    public List<bool> moveTrigger = new List<bool>();
    public List<bool> jumpTrigger = new List<bool>();
    public List<bool> attackTrigger = new List<bool>();

}
