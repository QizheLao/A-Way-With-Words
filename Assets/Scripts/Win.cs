using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    private void OnDestroy() // not working 
    {
        SceneManager.LoadScene("Win");
    }
    private void OnTriggerEnter(Collider other) // temperoy
    {
        if (other.gameObject.tag == "bullet")
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Win");
        }
    }
}
