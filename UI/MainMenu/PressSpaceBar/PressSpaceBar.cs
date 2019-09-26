using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressSpaceBar : MonoBehaviour {

    public bool isDisplayed = false;                    // Component status flag.
    public AnimatedText animatedText;                   // Animated text component reference.
    private Animation animation;                        // Animation component reference.

    // Start is called before the first frame update
    void Start() {
        Init();
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    /// <returns>void</returns>
    private void Init() {

        // get animation component.
        animation = GetComponent<Animation>();
    }

    /// <summary>
    /// Display press start panel.
    /// </summary>
    /// <returns>void</returns>
    public void DisplayPanel() {
        Utils.instance.TriggerAnimation( animation, "DisplaySpaceBarComponent" );
        isDisplayed = true;
    }

    /// <summary>
    /// Hide press start panel.
    /// </summary>
    /// <returns>void</returns>
    public void HidePanel() {
        Utils.instance.TriggerAnimation( animation, "HideSpaceBarComponent" );
    }
}
