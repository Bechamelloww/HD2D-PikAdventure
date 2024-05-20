using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f;
    public Animator animator;
    public CharacterController characterController;
    private Vector3 playerVelocity;
    [SerializeField] public float jumpHeight = 0.8f;
    [SerializeField] private AudioSource jumpingSound;
    public float gravity = -9.81f;
    public int maxJumps = 2;
    private int jumpsRemaining;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        jumpsRemaining = maxJumps;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        animator.SetFloat("Horizontal", horizontalInput);
        animator.SetFloat("Vertical", verticalInput);
        animator.SetBool("Grounded", characterController.isGrounded);

        if (characterController.isGrounded)
        {
            jumpsRemaining = maxJumps;
        }

        if (Input.GetButtonDown("Jump") && jumpsRemaining > 0)
        {
            if (jumpingSound != null)
            {
                jumpingSound.Play();
            }
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
            jumpsRemaining--;
        }

        Vector3 move = new Vector3(horizontalInput, 0f, verticalInput);
        move = transform.TransformDirection(move);
        characterController.Move(move * Time.deltaTime * speed);

        playerVelocity.y += gravity * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);
    }
}
