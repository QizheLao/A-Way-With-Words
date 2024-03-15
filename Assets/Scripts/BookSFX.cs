using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSFX : MonoBehaviour
{
    public AudioSource SFXPlayer;

    public AudioClip[] SFXList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void playget(){
        SFXPlayer.clip = SFXList[0];
        SFXPlayer.Play();
    }

    public void playheal(){
        SFXPlayer.clip = SFXList[1];
        SFXPlayer.Play();
    }

}
