using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenApple : MonoBehaviour {  
    
    public AudioClip negativeSoundClip;                              // No effect sound clip reference.
    private Animation animation;                            // Animation component.
    private AudioSource audio;                              // Audion source component.
    private GameObject particles;                           // Golden apple particles gameObject.
    private float stateDuration = 6f;                       // Golden state boost duration.

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
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
    /// Method to run when the apple is collected.
    /// </summary>
    public void GetCollected() {

        // remove particles.
        Destroy( particles );

        // stop bouncing animation an trigger collected animation.
        animation.Stop();
        animation.clip = animation.GetClip( "apple-collected" );
        animation.Play();

        // set player in golden mode - double points for each collected apple.
        if ( BallController.instance.additionalState == "none" ) {

            // display collect sound.
            audio.Play();

            // set player 3d model in golden state.
            BallController.instance.SetGoldenState( stateDuration );
            
            // add text to the legend.
            Legend.instance.AddText( "Double  points  mode", "golden" );
        } else {
            
            // golden apple has no effect.
            ReproduceNoEffectSound();
        }

        Destroy( this.gameObject, 1f );
    }

    /// <summary>
    /// Display uncollected collectible sound.
    /// Usually this sound is displayed when
    /// the item has no effect.
    /// </summary>
    private void ReproduceNoEffectSound() {
        audio.clip = negativeSoundClip;
        audio.Play();
    }
    
}
