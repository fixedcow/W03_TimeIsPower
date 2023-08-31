using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class FireWallAtack : MonoBehaviour
{
    [SerializeField] private GameObject cautionEffect;
    [SerializeField] private float cautionTime;
    private WaitForSeconds waitCautionTime;
    [SerializeField] private ParticleSystem attackParticle;
    [SerializeField] private GameObject attackCollider;
    [SerializeField] private float attackTime;
    private WaitForSeconds waitAttackTime;


    private void Start()
    {

        waitCautionTime = new WaitForSeconds(cautionTime);
        waitAttackTime = new WaitForSeconds(attackTime);
    }

    [Button]
    public void StartAttack()
    {
        StartCoroutine(AttackPlay());
    }
    public IEnumerator AttackPlay()
    {
        cautionEffect.SetActive(true);
        yield return waitCautionTime;
        cautionEffect.SetActive(false);

        attackCollider.SetActive(true);
        attackParticle.Play();
        yield return waitAttackTime;

        attackCollider.SetActive(false);
        attackParticle.Stop();
    }

    public void InitAttack()
    {
        cautionEffect.SetActive(false);
        attackCollider.SetActive(false);
        attackParticle.Stop();
    }
}
