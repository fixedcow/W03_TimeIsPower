using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brazier : MonoBehaviour
{

	[SerializeField] private SpriteRenderer fadeSprite;
	[SerializeField] private int maxBrazier;
	[SerializeField] private int nowBrazier;
	[SerializeField] private float HealTimeInterval;
	private float timer;

    private void Start()
    {
		nowBrazier = maxBrazier;
    }

	public void Init()
    {
		nowBrazier = maxBrazier;
	}
    public void Hit(int _damage, GameObject _source)
	{
        if (nowBrazier >= 1)
        {
			nowBrazier -= _damage;
			fadeOut();
		}
		
	}

	private void fadeOut()
    {
		float alpha = 1f-((float)nowBrazier / maxBrazier);
		Color fadeColor = Color.black;
		fadeColor.a = alpha;
		fadeSprite.color = fadeColor;
    }

	private void fadeIn()
    {
		timer += Time.deltaTime;
        if (timer >= HealTimeInterval&&nowBrazier<maxBrazier)
        {
			nowBrazier += 1;
			fadeOut();
			timer = 0;
        }
    }

    private void Update()
    {
		fadeIn();
    }

}
