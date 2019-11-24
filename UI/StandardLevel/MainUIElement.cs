using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIElement : MonoBehaviour {
    public string id;                                               // UI element id.
    private Animation animation;                                    // Animation component reference.

    // Start is called before the first frame update
    void Start() {
        Init();
    }

    /// <summary>
    /// Display animation manager.
    /// </summary>
    /// <returns>void</returns>
    public void DisplayElement() {
        string animationName = "";

        switch ( id ) {
            case "speedPanel":
                animationName = "DisplaySpeedPanel";
                break;
            case "scorePanel":
                animationName = "DisplayScorePanel";
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
    /// Hide element animation manager.
    /// </summary>
    /// <returns>void</returns>
    public void HideElement() {
        string animationName = "";

        switch ( id ) {
            case "speedPanel":
                animationName = "HideSpeedPanel";
                break;
            case "scorePanel":
                animationName = "HideScorePanel";
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
    /// Init class method.
    /// </summary>
    /// <returns>void</returns>
    public void Init() {

        // get animation component reference.
        animation = GetComponent<Animation>();
    }
}
