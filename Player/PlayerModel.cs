using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    public Color[] colors = new Color[2];                           // Array of color for the main player.
    public ParticleSystem[] particles = new ParticleSystem[2];      // Array of particle system for animations.
    private Animation animation;                                    // Animation component.
    private Renderer renderer;                                      // Renderer component.
    private float colorTransitionDuration = 1f;                     // Color transition speed.
    private float fadeStart = 0f;                                   // Internal counter used for color transition animation.
    private float finishAnimationTime = 0.4f;                       // Time before we play the player bouncing animation again.


    // Start is called before the first frame update
    void Start() {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Rotate player to the right.
    /// </summary>
    public IEnumerator TurnRight() {

        // stop bouncing animation.
        //animation.Stop();

        // set current clip as turn right animation and play.
        animation.clip = animation.GetClip( "playerMoveRight" );
        animation.Play();

        // wait till animation finishes and then restore bouncing animation.
        yield return new WaitForSeconds( finishAnimationTime );
        //animation.clip = animation.GetClip( "playerBouncing" );
        //animation.Play();
    }

    /// <summary>
    /// Rotate player to the left.
    /// </summary>
    public IEnumerator TurnLeft() {

        // TODO: Add runnig fast animation.

        // stop bouncing animation.
        //animation.Stop();

        // set current clip as turn left animation and play.
        animation.clip = animation.GetClip( "playerMoveLeft" );
        animation.Play();

        // wait till animation finishes and then restore bouncing animation.
        yield return new WaitForSeconds( finishAnimationTime );
        //animation.clip = animation.GetClip( "playerBouncing" );
        //animation.Play();
    }

    /// <summary>
    /// Stop bouncing.
    /// </summary>
    public void StopBouncing() {
        if ( animation.clip.name == "playerBouncing" ) {
            animation.Stop();
        }
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    private void Init() {
        
        // get animation component.
        animation = GetComponent<Animation>();

        // get renderer component.
        renderer = GetComponent<Renderer>();
    }

    /// <summary>
    /// Fade player color material.
    /// </summary>
    /// <param name="color1">color1 - color from where you init the transition</param>
    /// <param name="color2">color2 - color where you finish the transition</param>
    private IEnumerator ChangeColor( Color color1, Color color2 ) {
         
        while ( fadeStart < colorTransitionDuration ) {
            fadeStart += Time.deltaTime * colorTransitionDuration;
            renderer.material.color = Color.Lerp( color1, color2, fadeStart );

            yield return null;
        }

        // fix variations in the animation.
        renderer.material.color = color2;
        fadeStart = 0;
    }

    /// <summary>
    /// Accumulate speed animation.
    /// </summary>
    public void AccumulateSpeedAnimation() {
        // display particles.
        particles[0].Play();

        // set player color to accumulate color.
        StartCoroutine( ChangeColor( colors[0], colors[1] ) );
    }

    /// <summary>
    /// Release speed animation.
    /// </summary>
    public void ReleaseSpeedAnimation() {
        // remove accumulation particles.
        particles[0].Stop();

        // TOOD: Play explosion particle effect here.
    }

    /// <summary>
    /// Set speed to normal value animation.
    /// </summary>
    public void SetSpeedToBaseSpeedAnimation() {
        // set player to original color when the speed is set to baseSpeed.
        StartCoroutine( ChangeColor( colors[1], colors[0] ) );
    }
}
