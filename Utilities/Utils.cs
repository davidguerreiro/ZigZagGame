using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour {

    public static Utils instance;                       // Public class instance reference to make this class available in other scripts.

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake() {
        if ( instance == null ) {
            instance = this;
        }
    }

    /// <summary>
    /// Trigger an animation.
    /// </summary>
    /// <param name="animation">Animation - animation component reference.</param>
    /// <param name="clipName">string - clip name to be played</param>
    /// <returns>void</returns>
    public void TriggerAnimation( Animation animation, string clipName ) {
        if ( animation.isPlaying ) {
            animation.Stop();
        }

        // get clip from animation array of clips.
        animation.clip = animation.GetClip( clipName );

        animation.Play();
    }
}
