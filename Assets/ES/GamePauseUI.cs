using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamePauseUI : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private Player player;
    private PlayerAction input;
    private bool isPause;

   
    private void Awake()
    {
        input = new PlayerAction();
    }
    private void OnEnable()
    {
        input.Enable();
        input.UI.ESC.performed += Pause;
    }

    private void OnDisable()
    {
        input.UI.ESC.performed -= Pause;
        input.Disable();
    }
    private void PauseGameUI()
    {
        Time.timeScale = 0;
        player.enabled = false;
        pauseUI.SetActive(true);
    }

    public void ResumeGameUI()
    {
        Time.timeScale = 1;
        player.enabled = true;
        pauseUI.SetActive(false);
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    private void Pause(InputAction.CallbackContext _context)
    {
        Debug.Log("key");
        if (isPause)
        {
            ResumeGameUI();
            isPause = !isPause;
        }
        else
        {
            PauseGameUI();
            isPause = !isPause;

        }
        
    }

}
