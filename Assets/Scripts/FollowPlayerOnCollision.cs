using UnityEngine;
using System.Collections.Generic;

public class FollowPlayerOnCollision : MonoBehaviour
{
    public float followDistance = 2.0f;
    public float moveSpeed = 5.0f;
    public float minimumDistance = 1.5f; // Distance minimale avec les autres objets et le joueur
    private Transform playerTransform;
    private bool shouldFollow = false;

    void Start()
    {
        // Initialisation des variables si nécessaire
    }

    void Update()
    {
        if (shouldFollow && playerTransform != null)
        {
            // Calculer la direction et la distance vers le joueur
            Vector3 directionToPlayer = playerTransform.position - transform.position;
            float distanceToPlayer = directionToPlayer.magnitude;

            // Vérifier la distance minimale avec le joueur
            if (distanceToPlayer > followDistance)
            {
                Vector3 targetPosition = playerTransform.position - directionToPlayer.normalized * followDistance;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            }

            Collider[] hitColliders = Physics.OverlapSphere(transform.position, minimumDistance);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject != gameObject && hitCollider.gameObject != playerTransform.gameObject)
                {
                    Vector3 directionAwayFromCollider = transform.position - hitCollider.transform.position;
                    transform.position += directionAwayFromCollider.normalized * (minimumDistance - directionAwayFromCollider.magnitude);
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTransform = other.transform;
            shouldFollow = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shouldFollow = false;
            playerTransform = null;
        }
    }
}
