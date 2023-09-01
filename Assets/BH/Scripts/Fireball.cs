using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float delayTime = 1f;
    [SerializeField] private float delaySpeed = 0.1f;
    [SerializeField] private float speed = 10f;

    private float currentTime = 0;
    Player _player;
    Vector2 direction;

    private void Start()
    {
        _player = GameManager.instance.GetPlayer();
        currentTime = 0;
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime < delayTime)
        {
            direction = _player.gameObject.transform.position - this.transform.position;
            transform.Translate(direction.normalized * delaySpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
