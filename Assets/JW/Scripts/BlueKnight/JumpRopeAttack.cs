using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

public class JumpRopeAttack : MonoBehaviour
{
    [SerializeField] private GameObject cautionEffect;
    [SerializeField] private Collider2D attackCollider;
    private SpriteRenderer cautionEffectRenderer;
    [SerializeField] private SpriteRenderer attackEffectRenderer;
    [SerializeField] private float cautionTime;
    private WaitForSeconds waitCautionTime;
    [SerializeField] private float blinkTime;
    [SerializeField] private Animator attackAnimation;
    [SerializeField] private float attackTime;
    private WaitForSeconds waitAttackTime;
    private Sequence blinkSequence;

    private Vector3 defaultCautionScale;

    private Vector3 defaultCautionPosition;


    private void Start()
    {

        waitCautionTime = new WaitForSeconds(cautionTime);
        waitAttackTime = new WaitForSeconds(attackTime);

        blinkSequence = DOTween.Sequence()
            .SetAutoKill(false)
            .Pause();
        int blinkCount = Mathf.RoundToInt(cautionTime / blinkTime);
        for (int i = 0; i < blinkCount; i++)
        {
            blinkSequence.Append(DOTween.ToAlpha(() => cautionEffect.GetComponent<SpriteRenderer>().color,
                color => cautionEffect.GetComponent<SpriteRenderer>().color = color, 0.5f, blinkTime / 2));
            blinkSequence.Append(DOTween.ToAlpha(() => cautionEffect.GetComponent<SpriteRenderer>().color,
                color => cautionEffect.GetComponent<SpriteRenderer>().color = color, 0f, blinkTime / 2));
        }




        defaultCautionScale = cautionEffect.transform.localScale;

        defaultCautionPosition = cautionEffect.transform.localPosition;
    }

    [Button]
    public void StartAttack()
    {
        StartCoroutine(nameof(AttackPlay));
    }
    public IEnumerator AttackPlay()
    {
        
        blinkSequence.Play();
        cautionEffect.SetActive(true);
        yield return waitCautionTime;
        attackCollider.enabled = true;
        //attackEffectRenderer.enabled = true;
        cautionEffect.SetActive(false);
        attackAnimation.Rebind();
        attackAnimation.Play("Thunder_Linear");
        yield return waitAttackTime;
        attackCollider.enabled = false;
        //attackEffectRenderer.enabled = false;
        blinkSequence.Rewind();
    }

    public void InitAttack()
    {
        attackAnimation.Rebind();
        blinkSequence.Rewind();
        attackCollider.enabled = false;
        attackEffectRenderer.enabled = false;
        StopCoroutine(nameof(AttackPlay));
        cautionEffect.SetActive(false);
    }
}
