using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayPanel : MonoBehaviour {
    public bool isDisplayed = false;                    // Flag to controle wheter the panel is displayed in the game.
    private Animation animation;                        // Animation component reference.

    // Start is called before the first frame update
    void Start() {
        Init();
    }

    /// <summary>
    /// Display panel.
    /// </summary>
    /// <retruns>void</returns>
    public void DisplayPanel() {
        Utils.instance.TriggerAnimation( animation, "DisplayLevelHowToPlay" );
        isDisplayed = true;
    }

    /// <summary>
    /// Hide panel.
    /// </summary>
    /// <retruns>void</returns>
    public void HidePanel() {
        Utils.instance.TriggerAnimation( animation, "HideLevelHowToPlay" );
        isDisplayed = false;
    }


    /// <summary>
    /// Init class method.
    /// </summary>
    /// <retruns>void</returns>
    private void Init() {
        
        // get animation component reference.
        animation = GetComponent<Animation>();
    }
}
