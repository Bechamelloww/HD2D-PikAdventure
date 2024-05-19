using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuCanvasGO;

    private bool isPaused;

    private void Start()
    {
        _mainMenuCanvasGO.SetActive(false);
    }

    private void Update()
    {
        if (InputManager.instance.MenuOpenCloseInput)
        {
            if (!isPaused)
            {
                Pause();
            } else
            {
                Unpause();
            }
        }
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;
        OpenMainMenu();
    }

    public void Unpause()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
        CloseMenus();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void OpenMainMenu()
    {
        _mainMenuCanvasGO.SetActive(true);
    }

    private void CloseMenus()
    {
        _mainMenuCanvasGO?.SetActive(false);
    }

    public void OnClickResume()
    {
        Unpause();
    }

    public void OnClickQuit()
    {
        QuitGame();
    }
}
