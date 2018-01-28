using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour {

    [SerializeField]
    private AudioSource track1;
    [SerializeField]
    private AudioSource track2;

    private AudioSource thisTrack;

    void Start()
    {
        thisTrack = track1;
    }

    public void Play () {
        thisTrack.Play();
	}
	
	public void StopMusic () {
        track1.Stop();
        track2.Stop();
	}

    public void SwitchMusic()
    {
        if (thisTrack == track1) {
            track1.Stop();
            thisTrack = track2;
            Play();
        }
        else if (thisTrack == track2)
        {
            track2.Stop();
            thisTrack = track1;
            Play();
        }
    }
}
