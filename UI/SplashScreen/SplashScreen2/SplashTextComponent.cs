using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashTextComponent : MonoBehaviour {
    public string type;                                         // Splash screen text type. It can be 'upper', 'main' or 'content'. Used to check which animation has to be played.
    private Animation animation;                                // Animaiton component reference.

    // Start is called before the first frame update
    void Start() {
        Init();
    }

    /// <summary>
    /// Display text animation.
    /// Animation used varies depending
    /// of the text type.
    /// </summary>
    /// <returns>void</returns>
    public void DisplayText() {
        string animationName = "";

        switch ( this.type ) {
            case "upper":
                animationName = "DisplayUpperText";
                break;
            case "main":
                animationName = "DisplayMainText";
                break;
            case "content":
                animationName = "DisplayContentText";
                break;
            default:
                animationName = "";
                break;
        }

        if ( animationName != "" ) {
            Utils.instance.TriggerAnimation( animation, animationName );
        }
    }

    /// <summary>
    /// Hide text animation.
    /// </summary>
    /// <returns>void</returns>
    public void HideText() {
        Utils.instance.TriggerAnimation( animation, "HideText" );
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
