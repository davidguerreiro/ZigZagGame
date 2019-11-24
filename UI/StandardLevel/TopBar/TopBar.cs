using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopBar : MonoBehaviour {
    private bool displayed = false;                         // Flag to check wheter the top bar is displayed.
    private Animation animation;                            // Animation component reference.


    // Start is called before the first frame update
    void Start() {
        Init();
    }

    /// <summary>
    /// Get displayed status.
    /// </summary>
    /// <returns>void</returns>
    public bool IsDisplayed() {
        return this.displayed;
    }

    /// <summary>
    /// Display top bar in the
    /// game scene.
    /// </summary>
    /// <returns>void</returns>
    public void DisplayTopBar() {
        Utils.instance.TriggerAnimation( animation, "DisplayBar" );
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    /// </returns>void</returns>
    private void Init() {

        // get animation component reference.
        animation = GetComponent<Animation>();
    }
}
