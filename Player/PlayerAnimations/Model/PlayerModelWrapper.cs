using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelWrapper : MonoBehaviour {
    public PlayerModelBody body;                                // Player model body.
    private Animation animation;                                // Animation component reference.

    // Start is called before the first frame update
    void Start() {
        Init();
    }

    /// <summary>
    /// Display player bouncing animation
    /// event.This function is to be used
    /// as an event in the main menu
    /// animation.
    /// </summary>
    /// <returns>void</returns>
    public void PlayerBouncingAnimationEvent() {
        body.DisplayPlayerBouncingAnim();
    }

    /// <summary>
    /// Display main menu scene player
    /// animation.
    /// </summary>
    /// <returns>void</returns>
    public void DisplayMainMenuPlayerAnim() {
        Utils.instance.TriggerAnimation( animation, "PlayerMainMenuAnimation" );
    }

    /// <summary>
    /// Switch player mouth event wrapper.
    /// </summary>
    /// <param name="mouthName">string - mouth name to pass to the body function</param>
    /// <returns>void</returns>
    public void PlayerSwitchMouthEvent( string mouthName ) {
        body.SwitchMouth( mouthName );
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    /// <returns>void</returns>
    private void Init() {

        // get animation component.
        animation = GetComponent<Animation>();
    }
}
