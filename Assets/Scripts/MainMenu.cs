using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string Scene;
    public GameObject pausemenu;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(Scene);
        }

    }
    public void Load(string Scene)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(Scene);
    }
    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pausemenu.SetActive(false);
        Time.timeScale = 1;
    }
}
