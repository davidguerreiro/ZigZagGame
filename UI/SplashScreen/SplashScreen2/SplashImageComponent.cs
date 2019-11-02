using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashImageComponent : MonoBehaviour {
    public string type = "";                                        // Image type. It can be 'piskel' or 'unity'. This is used to set the display animation.
    private Animation animation;                                    // Animation component reference.

    // Start is called before the first frame update
    void Start() {
        Init();
    }

    /// <summary>
    /// Display image animation.
    /// Animation used is based
    /// on image type.
    /// </summary>
    /// <returns>void</returns>
    public void DisplayImage() {
        string animationName = "";

        switch ( this.type ) {
            case "piskel":
                animationName = "DisplayPiskelLogo";
                break;
            case "unity":
                animationName = "DisplayUnityLogo";
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
    /// Hide image animation.
    /// </summary>
    /// <returns>void</returns>
    public void HideImage() {
        Utils.instance.TriggerAnimation( animation, "HideImage" );
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    /// <returns>void</returns>
    private void Init() {

        // get animatio component reference.
        animation = GetComponent<Animation>();
    }
}
