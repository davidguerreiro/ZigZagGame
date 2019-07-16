using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    private Animation animation;                            // Animation component.
    private float finishAnimationTime = 0.4f;               // Time before we play the player bouncing animation again.


    // Start is called before the first frame update
    void Start()
    {
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
            Debug.Log( "stop bouncing" );
            animation.Stop();
        }
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    private void Init() {
        
        // get animation component.
        animation = GetComponent<Animation>();
    }
}
