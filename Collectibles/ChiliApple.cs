using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChiliApple : MonoBehaviour {

    private Animation animation;                        // Animation component reference.
    private AudioSource audio;                          // Audio component reference.
    private GameObject particles;                       // Chili apple particles gameObject reference.
    private float stateDuration = 6f;                  // Chili state boost duration.

    // Start is called before the first frame update
    void Start() {
        Init();   
    }

    // Update is called once per frame
    void Update() { 
        
        // rotate collectible every frame.
        RotateCollectible();
    }

    /// <summary>
    /// Rotate collectible every frame.
    /// </summary>
    private void RotateCollectible() {
        transform.Rotate( new Vector3( 0, 3f, 0 ) );
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    private void Init() {

        // get animation component.
        animation = GetComponent<Animation>();

        // get audio source component.
        audio = GetComponent<AudioSource>();

        // get particles child gameObject.
        particles = transform.GetChild(1).gameObject;
    }

    /// <summary>
    /// Method to run when the chili apple
    /// is collected.
    /// </summary>
    public void GetCollected() {

        // remove particles.
        Destroy( particles );

        // stop bouncing animation and trigger collected animation.
        animation.Stop();
        animation.clip = animation.GetClip( "apple-collected" );
        animation.Play();

        // set player in chili mode - speed is set to max speed for 10 seconds. No boost allowed and no boost bonifications.
        if ( BallController.instance.additionalState == "none" ) {

            // set player 3D model in chili state.
            BallController.instance.SetChiliStatus( stateDuration );

            // add text to legend.
            Legend.instance.AddText( "Double speed mode", "golden" );
        }

        // display collected sound.
        audio.Play();

        Destroy( this.gameObject, 1f );
    }
}
