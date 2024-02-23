using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Words : MonoBehaviour
{
    public static int collectedWords = 0;
    public TextMeshProUGUI wordText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            collectedWords++;
            //Debug.Log("Words Collected: " + collectedWords);
            wordText.text = collectedWords.ToString();
            Destroy(gameObject);
            if (collectedWords >= 5)
            {
                SceneManager.LoadScene("OuterDemo");
            }
        }
    }
}


