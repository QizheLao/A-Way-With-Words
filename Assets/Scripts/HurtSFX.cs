using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtSFX : MonoBehaviour
{
    public AudioSource SFXPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void playhit(){
        SFXPlayer.Play();
    }
}