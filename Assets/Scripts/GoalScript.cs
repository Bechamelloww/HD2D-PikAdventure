using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public AudioSource playerAudioSource;
    public AudioClip goalSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            playerAudioSource.clip = goalSound;
            playerAudioSource.Play();
        }
    }
}
