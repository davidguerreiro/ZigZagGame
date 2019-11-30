using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsButton : MonoBehaviour {

    private bool displayed = false;                                         // Flag to control displaying status.
    private Animation animation;                                            // Animation component reference.

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    /// <returns>void</returns>
    void Start() {
        Init();
    }

    /// <summary>
    /// Display button animation.
    /// </summary>
    /// <returns>void</returns>
    public void Display() {
        Utils.instance.TriggerAnimation( animation, "Display" );
        this.displayed = true;
    }

    /// <summary>
    /// Hide button animation.
    /// </summary>
    /// <returns>void</returns>
    public void Hide() {
        Utils.instance.TriggerAnimation( animation, "Hide" );
        this.displayed = false;
    }

    /// <summary>
    /// Disable button.
    /// </summary>
    /// <returns>void</returns>
    public void DisableButton() {
        gameObject.SetActive( false );
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
