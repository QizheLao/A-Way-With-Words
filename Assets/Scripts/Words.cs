using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Words : MonoBehaviour
{
    public static int collectedWords = 0;
    public TextMeshProUGUI wordText;
    public bool Level2;
    private string sceneName;

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        if (sceneName == "Level2Inner")
        {
            collectedWords = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            if (gameObject.tag == "healthpack")
            {
                Destroy(gameObject);
            }
            else
            {
                GameObject.Find("BookSFX").GetComponent<BookSFX>().playget();
                collectedWords++;
                //Debug.Log("Words Collected: " + collectedWords);
                wordText.text = ("Words: " + collectedWords + "/5");
                Destroy(gameObject);
                if (collectedWords >= 5)
                {
                    collectedWords = 0;
                    if (Level2)
                    {
                        SceneManager.LoadScene("Level2Outer");
                    }
                    else
                    {
                        SceneManager.LoadScene("OuterDemo");
                    }
                }
            }
        }
    }
}


