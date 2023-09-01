using System.Collections;
using UnityEngine;
using Sirenix.OdinInspector;
using DG.Tweening;

public class FireWallAtack : MonoBehaviour
{

    [SerializeField]
    [Range(0, 3)]
    [OnValueChanged("OnValueChange")]
    private float scaleOffsetX;

    [SerializeField]
    [Range(0, 3)]
    [OnValueChanged("OnValueChange")]
    private float scaleOffsetY;

    [SerializeField] private GameObject cautionEffect;
    [SerializeField] private float cautionTime;
    private WaitForSeconds waitCautionTime;
    [SerializeField] private float blinkTime;
    [SerializeField] private ParticleSystem attackParticle;
    [SerializeField] private GameObject attackCollider;
    [SerializeField] private float attackTime;
    private WaitForSeconds waitAttackTime;
    private Sequence blinkSequence;

    private Vector3 defaultColliderScale;
    private Vector3 defaultCautionScale;

    private Vector3 defaultColliderPosition;
    private Vector3 defaultCautionPosition;

    private void Start()
    {

        waitCautionTime = new WaitForSeconds(cautionTime);
        waitAttackTime = new WaitForSeconds(attackTime);

        blinkSequence = DOTween.Sequence();
        blinkSequence.Append(DOTween.ToAlpha(() => cautionEffect.GetComponent<SpriteRenderer>().color,
                color => cautionEffect.GetComponent<SpriteRenderer>().color = color, 0f, blinkTime / 2));
        blinkSequence.Append(DOTween.ToAlpha(() => cautionEffect.GetComponent<SpriteRenderer>().color,
            color => cautionEffect.GetComponent<SpriteRenderer>().color = color, 0.5f, blinkTime / 2));
        blinkSequence.SetLoops(-1);

        defaultCautionScale = cautionEffect.transform.localScale;
        defaultColliderScale = attackCollider.transform.localScale;

        defaultCautionPosition = cautionEffect.transform.position;
        defaultColliderPosition = attackCollider.transform.position;


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

    public void OnValueChange()
    {
        cautionEffect.transform.localScale = defaultCautionScale;
        attackCollider.transform.localScale = defaultColliderScale;
        cautionEffect.transform.position = defaultCautionPosition;
        attackCollider.transform.position = defaultColliderPosition;

        Vector3 scale = cautionEffect.transform.localScale;
        scale.x+= scaleOffsetX;
        scale.y += scaleOffsetY;
        cautionEffect.transform.localScale= scale;

        Vector3 position = cautionEffect.transform.position;
        position.y += scaleOffsetY / 2;
        cautionEffect.transform.position = position;

        scale = attackCollider.transform.localScale;
        scale.x += scaleOffsetX;
        scale.y += scaleOffsetY;
        attackCollider.transform.localScale = scale;

        position = attackCollider.transform.position;
        position.y += scaleOffsetY / 2;
        attackCollider.transform.position = position;
    }

    public void InitAttack()
    {
        StopCoroutine(AttackPlay());
        cautionEffect.SetActive(false);
        attackCollider.SetActive(false);
        attackParticle.Stop();
    }
}
