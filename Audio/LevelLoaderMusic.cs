using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoaderMusic : MonoBehaviour
{
    public static LevelLoaderMusic instance;                // Public static instance to make this class available for other scripts.
    public AudioClip[] songs = new AudioClip[3];            // Songs availables for the level.
    private AudioSource audio;                              // AudioSource component.

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake() {
        if ( instance == null ) {
            instance = this;
        }
    }

    // Start is called before the first frame update.
    void Start() {
        
        // set which song will be used in this level.
        SetLevelSong();
    }

    /// <summary>
    /// Set level music randomly.
    /// </summary>
    private void SetLevelSong() {
        int songToDisplay = 0;                  // Song to display key to get the song from the songs array.

        // get source component.
        audio = GetComponent<AudioSource>();

        songToDisplay = Random.Range( 0, songs.Length );
        audio.clip = songs[ songToDisplay ];
    }

    /// <summary>
    /// Play level music.
    /// </summary>
    public void PlayLevelMusic() {
        if ( ! audio.isPlaying ) {
            audio.Play();
        }
    }

    /// <summary>
    /// Stop playing level music.
    /// </summary>
    public void StopLevelMusic() {
        if ( audio.isPlaying ) {
            audio.Stop();
        }
    }
}
