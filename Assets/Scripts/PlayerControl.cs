using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    // script referenced from chatgbt
    public float speed = 5f;
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
        controller.Move(movement.normalized * speed * Time.deltaTime);
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
