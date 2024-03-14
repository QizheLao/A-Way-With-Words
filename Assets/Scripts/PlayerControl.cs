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
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    bool isGrounded;

    // referenced from module 1 - Jeevi
    private Vector3 velocity;
    public Transform cameraTransform;
    private CharacterController controller;
    public static int health = 100;
    public TextMeshProUGUI healthdisplay;


    void Start()
    {
        healthdisplay.text = ("Health: " + health);
        controller = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * currentSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
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
    }
}
