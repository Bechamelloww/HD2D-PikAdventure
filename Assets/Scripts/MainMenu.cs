using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuCanvasGO;

    public void QuitGame()
    {
        Application.Quit();
    }

    private void CloseMenus()
    {
        _mainMenuCanvasGO?.SetActive(false);
    }

    public void OnClickBegin()
    {
        SceneManager.LoadScene("Intro");
    }

    public void OnClickQuit()
    {
        QuitGame();
    }
}
