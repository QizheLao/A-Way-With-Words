using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSFX : MonoBehaviour
{

    public AudioSource SFXPlayer;

    public AudioClip[] SFXList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void playfire(){
        SFXPlayer.clip = SFXList[0];
        SFXPlayer.Play();
    }

    public void playreload(){
        SFXPlayer.clip = SFXList[1];
        SFXPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
