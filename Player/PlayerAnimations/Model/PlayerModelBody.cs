using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelBody : MonoBehaviour {
    public GameObject[] mouths = new GameObject[2];                                 // Player mouths to use in the animations.
    public GameObject[] eyes = new GameObject[4];                                   // Player eyes to use in the animations.
    private Animation animation;                                                    // Animation component reference.

    // Start is called before the first frame update
    void Start() {
        Init();
    }


    /// <summary>
    /// Switch player mouth.
    /// </summary>
    /// <param name="mouthName">string - mouth name to be displayed</param>
    /// <returns>void</returns>
    public void SwitchMouth( string mouthName ) {

        foreach ( GameObject mouth in mouths ) {
            mouth.SetActive( false );
        }

        switch ( mouthName ) {
            case "happy":
                mouths[0].SetActive( true );
                break;
            case "surprise":
                mouths[1].SetActive( true );
                break;
            default:
                mouths[0].SetActive( true );
                break;
        }
    }

    /// <summary>
    /// Switch player eyes.
    /// </summary>
    /// <param name="eyesTipe">strng - eyes name to be displayed</returns>
    /// <returns>void</returns>
    public void SwitchEyes( string eyesType ) {

        foreach ( GameObject eye in eyes ) {
            eye.SetActive( false );
        }

        switch ( eyesType ) {
            case "standard":
                eyes[0].SetActive( true );
                eyes[1].SetActive( true );
                break;
            case "happy":
                eyes[2].SetActive( true );
                eyes[3].SetActive( true );
                break;
            default:
                eyes[0].SetActive( true );
                break;
        }
    }
    

    /// <summary>
    /// Display player bouncing animation.
    /// </summary>
    /// <returns>void</returns>
    public void DisplayPlayerBouncingAnim() {
        Utils.instance.TriggerAnimation( animation, "playerBouncing", true );
    }

    /// <summary>
    /// Display player interested animation.
    /// </summary>
    /// <returns>void</returns>
    public void DisplayPlayerInterestedAnim() {
        Utils.instance.TriggerAnimation( animation, "PlayerInterested" );
    }

    /// <summary>
    /// Display player happy animation.
    /// </summary>
    /// <returns>void</returns>
    public void DisplayPlayerHappyAnim() {
        Utils.instance.TriggerAnimation( animation, "PlayerHappy" );
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    /// <returns>void</returns>
    private void Init() {

        // get animation component reference.
        animation = GetComponent<Animation>();
    }
}
