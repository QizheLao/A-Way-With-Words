using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WalkSFX : MonoBehaviour
{
    public AudioClip[] walkSFX;
    public AudioClip[] jumpSFX;
    public AudioClip[] landSFX;

    public AudioSource sfxPlayer;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void playstep() {
        gameObject.SetActive(true);
        if(!sfxPlayer.isPlaying) {
        var n = Random.Range(0, 10);
        sfxPlayer.clip = walkSFX[n];
        sfxPlayer.Play(0);
        }
        
    }

    public void playjump() {
        if(!sfxPlayer.isPlaying) {
        var n = Random.Range(0, 2);
        sfxPlayer.clip = jumpSFX[n];
        sfxPlayer.Play(0);
        }
    }

    public void playland() {
        if(!sfxPlayer.isPlaying) {
        var n = Random.Range(0, 2);
        sfxPlayer.clip = landSFX[n];
        sfxPlayer.Play(0);
        }
    }


    // Update is called once per frame
    void Update()
    {
    }
}
