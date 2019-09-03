using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGamePanel : MonoBehaviour {

    public bool isDisplayed = false;                        // Flag to check whether the panel is displayed in the game.
    private Animation animation;                            // Animation component reference.

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake() {
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
    public IEnumerator HidePanel() {
        Utils.instance.TriggerAnimation( animation, "HideStopGamePanel" );

        // disable panel when the animation is done.
        yield return new WaitForSeconds( 1f );
        isDisplayed = false;
        gameObject.SetActive( false );
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
