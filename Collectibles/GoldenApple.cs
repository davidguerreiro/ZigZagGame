using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenApple : MonoBehaviour
{
    private Animation animation;                            // Animation component.
    private AudioSource audio;                              // Audion source component.
    private GameObject particles;                           // Golden apple particles gameObject.

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
            // TODO: call enter golden state here.

            // add text to the legend.
            Legend.instance.AddText( "Double  points  mode", "golden" );
        }

        // display collect sound.
        audio.Play();

        Destroy( this.gameObject, 1f );
    }
}
