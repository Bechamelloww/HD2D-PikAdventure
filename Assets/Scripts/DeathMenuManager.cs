using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _DeathCanvasGO;
    public string sceneName;
    public Animator playerAnimator;
    public AudioSource playerAudioSource;
    public AudioClip deathSound;
    public AudioClip damageSound;

    private int health = 3; // Vie initiale

    private void Start()
    {
        _DeathCanvasGO.SetActive(false);
    }

    public void Death()
    {
        health--;
        if (playerAudioSource != null && damageSound != null)
        {
            playerAudioSource.clip = damageSound;
            playerAudioSource.Play();
        }

        if (health <= 0)
        {
            if (playerAudioSource != null && deathSound != null)
            {
                if (playerAnimator != null)
                {
                    playerAnimator.SetTrigger("Death");
                }
                playerAudioSource.clip = deathSound;
                playerAudioSource.Play();
            }
            OpenDeathMenu();
        }
    }

    public void Again()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(sceneName);
        GlobalScore.ResetScore();
        ResetHealth();
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        GlobalScore.ResetScore();
        ResetHealth();
    }

    private void OpenDeathMenu()
    {
        Time.timeScale = 0f;
        _DeathCanvasGO.SetActive(true);
    }

    private void ResetHealth()
    {
        health = 3;
    }

    public void OnClickRe()
    {
        Again();
    }

    public void OnClickQuit()
    {
        QuitToMainMenu();
    }
}
