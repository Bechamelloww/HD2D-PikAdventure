using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnAudioFinish : MonoBehaviour
{
    public AudioClip audioClip;
    private AudioSource audioSource;

    public string sceneToLoad;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.playOnAwake = false;

        audioSource.Play();
        Invoke("LoadNextScene", audioClip.length);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
