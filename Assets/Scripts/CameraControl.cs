using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CameraControl : MonoBehaviour
{
    public Transform playerBody;
    float xRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log(SensSlider.sens);
    }

    void Update()
    {
        if (!MainMenu.isPaused)
        {
            float mouseX = Input.GetAxis("Mouse X") * SensSlider.sens * 100f * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * SensSlider.sens * 100f * Time.deltaTime;

            xRotation -=mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
