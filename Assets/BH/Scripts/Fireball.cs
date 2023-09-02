using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Fireball : MonoBehaviour
{
	private float delayTime;
    private float delaySpeed = 0.1f;
	private float speed;

    private float currentTime = 0;
    Player _player;
    Vector2 direction;
	[SerializeField] private Collider2D col;

	public void SetInitStat(float _delay, float _speed)
	{
		delayTime = _delay;
		speed = _speed;
	}
    private void Start()
    {
        _player = GameManager.instance.GetPlayer();
        currentTime = 0;
		Invoke(nameof(DestroySelf), 5f);
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime < delayTime)
        {
			col.enabled = false;
            direction = _player.gameObject.transform.position - this.transform.position;
            transform.Translate(direction.normalized * delaySpeed * Time.deltaTime);
        }
        else
        {
			col.enabled = true;
            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
		DestroySelf();
    }
	private void DestroySelf()
	{
		Destroy(gameObject);
	}
}
