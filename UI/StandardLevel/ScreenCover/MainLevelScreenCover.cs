using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLevelScreenCover : MonoBehaviour {

    private bool displayed;                                     // Flag to control display status.
    private Animation animation;                                // Animation component reference.

    // Start is called before the first frame update
    void Start() {
        Init();
    }

    /// <summary>
    /// Get displayed status.
    /// </summary>
    /// <returns>bool</returns>
    public bool IsDisplayed() {
        return this.displayed;
    }

    /// <summary>
    /// Set displayed status.
    /// </summary>
    /// <param name="newStatus">bool - new status value</param>
    /// <returns>void</returns>
    public void SetDisplayStatus( bool newStatus ) {
        this.displayed = newStatus;
    }

    /// <summary>
    /// Display screen cover
    /// semi transparent. Used
    /// for game over panel.
    /// </summary>
    /// <returns>void</returns>
    public void Display() {
        Utils.instance.TriggerAnimation( animation, "DisplayTransparent" );
        this.displayed = true;
    }

    /// <summary>
    /// Hide screen cover.
    /// </summary>
    /// <returns>void</returns>
    public void Hide() {
        Utils.instance.TriggerAnimation( animation, "Hide" );
        this.displayed = false;
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    /// <returns>void</returns>
    private void Init() {
        animation = GetComponent<Animation>();
        this.displayed = false;
    }
}
