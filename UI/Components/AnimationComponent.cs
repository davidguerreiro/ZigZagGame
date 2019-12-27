using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationComponent : MonoBehaviour {

    public string displayAnimationName = "Display";             // Display animation default name.
    public string hideAnimationName = "Hide";                   // Hide animation default name.
    [SerializeField]
    private bool displayed = false;                             // Flag to control displayed status.
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
    /// <param name="newStatus">bool - new displayed status</param>
    /// <returns>void</returns>
    public void SetDisplayed( bool newStatus ) {
        this.displayed = newStatus;
    }

    /// <summary>
    /// Display element.
    /// </summary>
    /// <returns>void</returns>
    public void Display() {
        Utils.instance.TriggerAnimation( animation, displayAnimationName );
        this.displayed = true;
    }
    
    /// <summary>
    /// Hide element.
    /// </summary>
    /// <returns>void</returns>
    public void Hide() {
        Utils.instance.TriggerAnimation( animation, hideAnimationName );
        this.displayed = false;
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    /// <returns>void</returns>
    public void Init() {

        // get animation component.
        animation = GetComponent<Animation>();
    }
}
