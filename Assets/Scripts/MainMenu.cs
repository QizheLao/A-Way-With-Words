using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public string Scene;
    public GameObject pausemenu;
    public static bool isPaused;
    void Start()
    {
        if(pausemenu != null)
        {
            pausemenu.SetActive(false);
        }
        isPaused = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isPaused)
            {
                Pause();
            }
        }
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(Scene);
        }

    }*/
    public void Load(string Scene)
    {
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene(Scene);
    }
    public void Pause()
    {
        pausemenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }
    public void Resume()
    {
        pausemenu.SetActive(false);
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }
}
