using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f;
    public Animator animator;
    public CharacterController characterController;
    private Vector3 playerVelocity;
    [SerializeField] public float jumpHeight = 0.3f;
    public float gravity = -9.81f;
    public float groundCheckDistance = 0.1f;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        animator.SetFloat("Horizontal", horizontalInput);
        animator.SetFloat("Vertical", verticalInput);
        animator.SetBool("Grounded", characterController.isGrounded);

        Debug.Log(characterController.isGrounded);
        if (Input.GetButtonDown("Jump") && characterController.isGrounded == true)
        {
            Debug.Log("JUMPINGGG");
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }
        Debug.Log(playerVelocity.y);

        Vector3 move = new Vector3(horizontalInput, 0f, verticalInput);
        move = transform.TransformDirection(move);
        characterController.Move(move * Time.deltaTime * speed);
        
        
        
        playerVelocity.y += gravity * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);
    }
}
