using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGamePanel : MonoBehaviour {

    public bool isDisplayed = false;                        // Flag to check whether the panel is displayed in the game.
    private Animation animation;                            // Animation component reference.

    // Start is called before the first frame update
    void Start() {
        Init();
    }

    /// <summary>
    /// Display stop game panel.
    /// </summary>
    /// <returns>void</returns>
    public void DisplayPanel() {
        Utils.instance.TriggerAnimation( animation, "DisplayStopGamePanel" );
        isDisplayed = true;
    }

    /// <summary>
    /// Hide stop game panel.
    /// </summary>
    /// <returns>void</returns>
    public void HidePanel() {
        Utils.instance.TriggerAnimation( animation, "HideStopGamePanel" );
        isDisplayed = false;
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    /// <returns>void></return>
    private void Init() {

        // get animation component reference.
        animation = GetComponent<Animation>();
    }

}
