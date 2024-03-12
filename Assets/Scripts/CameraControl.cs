using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CameraControl : MonoBehaviour
{
    // script referenced from Module 1 (Jeevi)
    float rX = 0f;
    float rY = 0f;
    float sens = 1f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        sens = PlayerPrefs.GetFloat("Sens", 1.0f);
    }

    void Update()
    {
        if (!MainMenu.isPaused)
        {
        // used an online YouTube guide to track camera with mouse
        rY += Input.GetAxis("Mouse X") * sens;
        rX += Input.GetAxis("Mouse Y") * -1 * sens;
        transform.localEulerAngles = new Vector3(rX, rY, 0);
        }
    }
}
