using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 5f;
    public float minDistance = 2f;

    private Rigidbody rb;
    private bool isColliding = false;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (player == null)
        {
            Debug.LogError("Le joueur n'est pas défini pour le suivi.");
        }
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        animator.SetFloat("Horizontal", horizontalInput);
        animator.SetFloat("Vertical", verticalInput);
        if (isColliding && player != null)
        {
            Vector3 direction = player.position - transform.position;

            if (direction.magnitude > minDistance)
            {
                direction.Normalize();

                Vector3 moveDirection = direction * followSpeed * Time.fixedDeltaTime;

                rb.MovePosition(transform.position + moveDirection);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
            if (!isColliding) { 
                GlobalScore.IncrementScore();
            }
            isColliding = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //player = null;
            //isColliding = false;
        }
    }
}
