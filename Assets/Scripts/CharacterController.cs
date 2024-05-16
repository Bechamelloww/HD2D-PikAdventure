using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 5f;
    public Animator animator;
    public CharacterController characterController;
    public Vector3 playerVelocity;
    public bool groundedPlayer;
    [SerializeField] public float jumpHeight = 5.0f;
    public bool jumpPressed = false;
    public float gravity = -9.81f;


    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * speed * Time.deltaTime;

        transform.Translate(movement);
    }

    void Jump()
    {
        if (!groundedPlayer)
        {

        }
    }

}
