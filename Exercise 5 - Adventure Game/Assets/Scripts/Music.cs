using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private static Music instance = null;
    private AudioSource _audioSource;

    public static Music Instance {
        get {return instance;}
    }

     void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        }
        
        instance = this;
        _audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }


    public void PlayMusic () {
        if(_audioSource.isPlaying) {
            return;
        }
        _audioSource.Play();
    }

    public void StopMusic () {
        _audioSource.Stop();
    }
}
