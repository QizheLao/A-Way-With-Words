using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    // script referenced from chatgbt
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float jumpForce = 2f;
    public float gravity = -9.81f;
    public LayerMask groundLayer;

    // referenced from module 1 - Jeevi
    private Vector3 velocity;
    public Transform cameraTransform;
    private CharacterController controller;
    public int health = 100;
    public TextMeshProUGUI healthdisplay;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
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
        // sprinting
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        controller.Move(movement.normalized * currentSpeed * Time.deltaTime);
        // jumping 
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }
        // rigid body didnt work..? using own gravity 
        velocity.y += gravity * Time.deltaTime;
        if (controller.isGrounded && velocity.y < 0) // making sure player is always grounded
        {
            velocity.y = -2f; 
        }
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
        healthdisplay.text = health.ToString();
    }
}
