using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    public Color[] colors = new Color[2];                           // Array of color for the main player.
    public TwoDEffects twoDEffects;                                 // Player effects and animations in 2D class component.
    public ParticleSystem[] particles = new ParticleSystem[2];      // Array of particle system for animations.
    private Animation animation;                                    // Animation component.
    private Renderer renderer;                                      // Renderer component.
    private float colorTransitionDuration = 0.05f;                  // Color transition speed.
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

        // stop speed animation if applicable.
        if ( twoDEffects.inAnimation ) {
            twoDEffects.StopReleaseEffectAnim();
        }

        // set current clip as turn right animation and play.
        animation.clip = animation.GetClip( "playerMoveRight" );
        animation.Play();

        // wait till animation finishes and then restore bouncing animation.
        yield return new WaitForSeconds( finishAnimationTime );
        //animation.clip = animation.GetClip( "playerBouncing" );
        //animation.Play();

        // display player dust particle animation.
        EnableDust();
    }

    /// <summary>
    /// Rotate player to the left.
    /// </summary>
    public IEnumerator TurnLeft() {

        // TODO: Add runnig fast animation.

        // stop speed animation if applicable.
        if ( twoDEffects.inAnimation ) {
            twoDEffects.StopReleaseEffectAnim();
        }

        // stop bouncing animation.
        //animation.Stop();

        // set current clip as turn left animation and play.
        animation.clip = animation.GetClip( "playerMoveLeft" );
        animation.Play();

        // wait till animation finishes and then restore bouncing animation.
        yield return new WaitForSeconds( finishAnimationTime );
        //animation.clip = animation.GetClip( "playerBouncing" );
        //animation.Play();

        // display player dust particle animation.
        EnableDust();
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
        float counter = 0f;

        while ( counter < 1f ) {
            counter = counter + 0.1f;
            renderer.material.color = Color.Lerp( color1, color2, counter );

            yield return new WaitForSeconds( colorTransitionDuration );
        }

        // fix variations in the animation.
        renderer.material.color = color2;
        fadeStart = 0;
    }

    /// <summary>
    /// Accumulate speed animation.
    /// </summary>
    public void AccumulateSpeedAnimation() {
        // get current color.
        Color currentColor = GetCurrentColor();

        // display particles.
        particles[0].gameObject.SetActive( true );

        // set player color to accumulate color.
        StartCoroutine( ChangeColor( currentColor, colors[1] ) );
    }

    /// <summary>
    /// Get current color.
    /// </summary>
    public Color GetCurrentColor() {
        Color _currentColor = colors[0];

        // check if the current color is the boost color.
        if ( BallController.instance.inBoost ) {
            _currentColor = colors[1];
        } else {
            _currentColor = colors[2];
        }

        // check if the current color is the golden state color.
        if ( BallController.instance.additionalState == "golden" ) {
            _currentColor = colors[2];
        } else {
            _currentColor = colors[0];
        }

        // check if the current color is the chilo state color.
        if ( BallController.instance.additionalState == "chili" ) {
            _currentColor = colors[3];
        } else {
            _currentColor = colors[0];
        }

        return _currentColor;
    }

    /// <summary>
    /// Release speed animation.
    /// </summary>
    public void ReleaseSpeedAnimation() {

        // remove accumulation particles.
        particles[0].gameObject.SetActive( false );
        
        // display speed animation.
        if ( ! twoDEffects.inAnimation ) {
            StartCoroutine( twoDEffects.ReleaseSpeedEffectAnim() );
        }
        
    }

    /// <summary>
    /// Set speed to normal value animation.
    /// </summary>
    public void SetSpeedToBaseSpeedAnimation() {
        // current color.
        Color currentColor = GetCurrentColor();

        // set player to original color when the speed is set to baseSpeed.
        StartCoroutine( ChangeColor( colors[1], currentColor ) );
    }

    /// <summary>
    /// Set player in chili mode.
    /// In this state the base speed is the
    /// boost speed for 10 seconds.
    /// Typically this mode is set after
    /// the player collects a chili apple.
    /// </summary>
    /// <param name="duration">float - chili state boost duration</param>
    public IEnumerator TriggerChiliStateAnimation( float duration ) {

        // get current color.
        Color currentColor = GetCurrentColor();

        // set player state.
        BallController.instance.UpdateAdditionalState( "chili" );

        // change player color to golden state.
        StartCoroutine( ChangeColor( currentColor, colors[3] ) );

        yield return new WaitForSeconds( duration );
        StartCoroutine( RemoveChiliStatus() );
    }

    /// <summary>
    /// Remove chili status and set
    /// player in normal status.
    /// </summary>
    public IEnumerator RemoveChiliStatus() {

        // get current color.
        Color currentColor = GetCurrentColor();

        // set player state to default.
        BallController.instance.UpdateAdditionalState( "none" );

        // set player to default color.
        StartCoroutine( ChangeColor( currentColor, colors[0] ) );

        // set speed to base speed.
        StartCoroutine( BallController.instance.ToBaseSpeed() );

        // allow boost again.
        yield return new WaitForSeconds( 1f );
        BallController.instance.canBoost = true;
    }


    /// <sumamry>
    /// Set player in double score mode.
    /// Typically this mode is set after the
    /// player collects a golden apple.
    /// </summary>
    /// <param name="duration">float - golden apple boost duration</param>
    public IEnumerator TriggerGoldenStateAnimation( float duration ) {
        // get current color.
        Color currentColor = GetCurrentColor();

        // set player state.
        BallController.instance.UpdateAdditionalState( "golden" );

        // change player color to golden state.
        if ( ! BallController.instance.inBoost ) {
            StartCoroutine( ChangeColor( currentColor, colors[2] ) );
        }

        yield return new WaitForSecondsRealtime( duration );
        RemoveGoldenState();
    }

    /// <summary>
    /// Remove golden mode and set player
    /// in base mode.
    /// </summary>
    public void RemoveGoldenState() {
        // get current color.
        Color currentColor = GetCurrentColor();

        // set player state to default.
        BallController.instance.UpdateAdditionalState( "none" );

        // set player to default color.
        StartCoroutine( ChangeColor( currentColor, colors[0] ) );
    }

    /// <summary>
    /// Play / Enable dust particle effect
    /// in the player.
    /// </summary>
    public void EnableDust() {
        if ( ! particles[1].gameObject.activeSelf ) {
            particles[1].gameObject.SetActive( true );
        }

        particles[1].Play();
    }

    /// <summary>
    /// Stop dust. To disable particles
    /// pass true as a parameter.
    /// </summary>
    /// <param name="toDisable">bool - optional. Whether to totally disable the particle system. False by default</param>
    public void StopDust( bool toDisable = false ) {
        particles[1].Stop();
        Debug.Log( "called stop" );

        if ( toDisable ) {
            particles[1].gameObject.SetActive( false );
        }
    }
}
