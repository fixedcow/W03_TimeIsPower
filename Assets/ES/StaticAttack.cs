using System.Collections;
using UnityEngine;
using Sirenix.OdinInspector;
using DG.Tweening;

public class StaticAttack : MonoBehaviour
{
    [SerializeField]
    [Range(0, 20)]
    [OnValueChanged("OnValueChange")]
    private float scaleOffsetX;

    [SerializeField]
    [Range(0, 20)]
    [OnValueChanged("OnValueChange")]
    private float scaleOffsetY;

    [SerializeField] private GameObject cautionEffect;
	private SpriteRenderer cautionEffectRenderer;
    [SerializeField] private float cautionTime;
    private WaitForSeconds waitCautionTime;
    [SerializeField] private float blinkTime;
    [SerializeField] private ParticleSystem attackParticle;
    [SerializeField] private float attackTime;
    private WaitForSeconds waitAttackTime;
    private Sequence blinkSequence;

    private Vector3 defaultCautionScale;

    private Vector3 defaultCautionPosition;

	private void Awake()
	{
		cautionEffect.TryGetComponent(out cautionEffectRenderer);
	}
	private void Start()
    {

        waitCautionTime = new WaitForSeconds(cautionTime);
        waitAttackTime = new WaitForSeconds(attackTime);

        blinkSequence = DOTween.Sequence()
            .SetAutoKill(false)
            .Pause();
        /*		blinkSequence.Append(cautionEffectRenderer.DOFade(0, blinkTime / 2).SetEase(Ease.Linear))
					.Append(cautionEffectRenderer.DOFade(0.5f, blinkTime / 2).SetEase(Ease.Linear))
					.SetLoops(-1);*/
        int blinkCount = Mathf.RoundToInt(cautionTime / blinkTime);
        for(int i=0; i < blinkCount; i++)
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
        StartCoroutine(AttackPlay());
    }
    public IEnumerator AttackPlay()
    {
        blinkSequence.Play();
        cautionEffect.SetActive(true);
        yield return waitCautionTime;
        cautionEffect.SetActive(false);

        attackParticle.Play();
        yield return waitAttackTime;

        attackParticle.Stop();
        blinkSequence.Rewind();
    }

    public void OnValueChange()
    {
        cautionEffect.transform.localScale = defaultCautionScale;
        cautionEffect.transform.localPosition = defaultCautionPosition;

        Vector3 scale = cautionEffect.transform.localScale;
        scale.x += scaleOffsetX;
        scale.y += scaleOffsetY;
        cautionEffect.transform.localScale = scale;

        Vector3 position = cautionEffect.transform.localPosition;
        position.y += scaleOffsetY / 2;
        cautionEffect.transform.localPosition = position;

        scale.x += scaleOffsetX;
        scale.y += scaleOffsetY;

        position.y += scaleOffsetY / 2;
    }

    public void InitAttack()
    {
        blinkSequence.Rewind();
        StopCoroutine(AttackPlay());
        cautionEffect.SetActive(false);
        attackParticle.Stop();
    }
}
