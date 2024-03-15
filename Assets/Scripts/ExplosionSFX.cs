using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSFX : MonoBehaviour
{
    public AudioSource SFXPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void playboom() {
        SFXPlayer.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
