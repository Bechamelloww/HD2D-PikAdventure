using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    public DeathMenuManager deathMenuManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            deathMenuManager.Death();
        }
    }
}
