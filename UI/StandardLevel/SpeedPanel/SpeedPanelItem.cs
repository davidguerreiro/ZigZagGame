using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPanelItem : MonoBehaviour {
    private bool displayed = false;                                 // Flag to check displayed status.
    private Animation animation;                                    // Animation component reference.

    // Start is called before the first frame update.
    void Start() {
        Init();
    }

    /// <summary>
    /// Check if the item
    /// is displayed in the
    /// game scene.
    /// </summary>
    /// <returns>bool</returns>
    public bool IsDisplayed() {
        return this.displayed;
    }

    /// <summary>
    /// Display speed panel item in
    /// the game scene.
    /// </summary>
    /// <returns>void</returns>
    public void DisplayItem() {
        Utils.instance.TriggerAnimation( animation, "DisplaySpeedItem" );
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
