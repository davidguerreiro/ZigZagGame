using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicApple : MonoBehaviour
{
    public AudioClip boostSound;                            // Audio clips to be used by this collectible.
    private int scoreToAdd = 1;                             // score to add when the apple is collected
    private Animation animation;                            // Animation component.
    private AudioSource audio;                              // Audion source component.

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
    }

    /// <summary>
    /// Method to run when the apple is collected.
    /// </summary>
    public void GetCollected() {

        // stop bouncing animation an trigger collected animation.
        animation.Stop();
        animation.clip = animation.GetClip( "apple-collected" );
        animation.Play();

        // set score and sound based on player boost status.
        // score is duplicated if in boost mode.
        // audio sound changes.
        if ( BallController.instance.inBoost ) {
            scoreToAdd = 2;
            audio.clip = boostSound;
        }

        // display collect sound.
        audio.Play();

        // score is duplicated if in boost mode.
        UIManager.instance.UpdateScore( scoreToAdd );

        // add text to the legend.
        string legendText = ( BallController.instance.inBoost ) ? "points" : "point";
        Legend.instance.AddText( "+" + scoreToAdd + " " + legendText );

        Destroy( this.gameObject, 1f );
    }
}
