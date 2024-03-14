using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerControl : MonoBehaviour
{
    // script referenced from chatgbt
<<<<<<< Updated upstream
    public float speed = 5f;
=======
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float jumpForce = 2f;
    public float gravity = -9.81f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    bool isGrounded;

    // SFX Handling - Sam M
    public GameObject SFXplayer;

    // referenced from module 1 - Jeevi
    private Vector3 velocity;
>>>>>>> Stashed changes
    public Transform cameraTransform;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
<<<<<<< Updated upstream
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // tracking camera direction to move accordly
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();
        Vector3 movement = forward * verticalInput + right * horizontalInput;
        controller.Move(movement.normalized * speed * Time.deltaTime);
=======
        var wasGrounded = isGrounded;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);
        
        if(!wasGrounded && isGrounded) {
            SFXplayer.GetComponent<WalkSFX>().playland();
        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        Vector3 move = transform.right * x + transform.forward * z;

        //walking sound
        if(move != Vector3.zero && isGrounded) {
            SFXplayer.GetComponent<WalkSFX>().playstep();
        }

        controller.Move(move * currentSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            SFXplayer.GetComponent<WalkSFX>().playjump();
        }

        velocity.y += gravity * Time.deltaTime;
        
        controller.Move(velocity * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            Take(2, false);
        }
        else if (other.gameObject.tag == "enemybullet")
        {
            Take(5, false);
        }
        else if (other.gameObject.tag == "healthpack")
        {
            Take(50, true);
        }
    }
    public void Take(int amount, bool heal)
    {
        if (heal)
        {
            health += amount;
        }
        else
        {
            health -= amount;
            if (health <= 0)
            {
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("Lose");
            }
        }
        healthdisplay.text = ("Health: " + health);
>>>>>>> Stashed changes
    }
}
