using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour {
    public SongData song;
    public AudioSource audioSource;

    private void Start() {
        transform.position = Vector3.forward * (song.speed * GameManager.instance.startTime);
        Invoke("StartSong", GameManager.instance.startTime - song.startTime);
        Invoke("SongIsOver", song.song.length);
    }

    void StartSong(){
        audioSource.PlayOneShot(song.song);
    }
    private void Update() {
        transform.position += Vector3.back * song.speed * Time.deltaTime;
    }

    void SongIsOver(){
        GameManager.instance.WinGame();
    }

    private void OnDrawGizmos() {
        for ( int i = 0; i<100; i++){
            float beatLength = 60.0f / (float)song.bpm;
            float beatDist = beatLength * song.speed;

            Gizmos.DrawLine(transform.position + new Vector3(-1, 0 , i* beatDist), transform.position + new Vector3(1, 0, i*beatDist));
        }
    }
}
