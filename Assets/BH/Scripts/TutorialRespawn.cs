using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialRespawn : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player _player = collision.GetComponent<Player>();
            _player.Hit();
        }
            

        
    }
}
