using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialEnterTrigger : MonoBehaviour
{
    public Vector3 cameraPos;
    public GameObject gate;
    public GameObject fixedGate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Camera.main.transform.DOMove(cameraPos, 1f);
        gate.SetActive(false);
        fixedGate.SetActive(true);
        if(collision.transform.position.x < -9)
        {
            TutorialManager.Instance.Stage2EnterTrigger = true;
            GhostManager.instance.RecordAndReplay();
        }

        if(collision.transform.position.x > 29)
        {
            SceneManager.LoadScene("Main");
        }
    }
}
