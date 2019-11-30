using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePanel : MonoBehaviour {
    private bool displayed = false;                                 // Flag to control whether the score panel is displayed.
    private Animation animation;                                    // Animation component reference.

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
    /// Display score panel animation.
    /// </summary>
    /// <returns>void</returns>
    public void DisplayPanel() {
        Utils.instance.TriggerAnimation( animation, "DisplayScorePanel" );
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
