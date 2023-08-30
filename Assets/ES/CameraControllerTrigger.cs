using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraControllerTrigger : MonoBehaviour
{
    private CameraController cameraController;
    [SerializeField] private Transform player;

    private void Start()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 endCameraPos = player.position;
            endCameraPos.y += cameraController.yOffset;
            endCameraPos.z = -10;
            cameraController.transform.DOMove(endCameraPos, 0.5f)
                .OnComplete(() =>
                {
                    cameraController.enabled = true;
                    gameObject.SetActive(false);
                }
                
                );
            
        }
    }

}
