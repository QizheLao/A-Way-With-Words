using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Words : MonoBehaviour
{
    public static int collectedWords = 0;
    public TextMeshProUGUI wordText;
    public bool Level2;

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
                collectedWords++;
                //Debug.Log("Words Collected: " + collectedWords);
                wordText.text = ("Words: " + collectedWords + "/5");
                Destroy(gameObject);
                if (collectedWords >= 5)
                {
                    if (!Level2)
                    {
                        SceneManager.LoadScene("OuterDemo");
                    }
                    else
                    {
                        SceneManager.LoadScene("Level2Outer");
                    }
                }
            }
        }
    }
}


