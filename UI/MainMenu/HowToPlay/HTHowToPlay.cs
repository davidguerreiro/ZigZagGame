using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HTHowToPlay : MonoBehaviour {
    public bool displayed = false;                                // Flag to control whether the panel is displayed.
    public SceneCover sceneCover;                                   // Reference to scene cover class component.
    private Animation animation;                                    // Animation component reference.

    // Start is called before the first frame update
    void Start() {
        Init();
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    /// <returns>void</returns>
    public void Init() {

        // get animation component.
        animation = GetComponent<Animation>();
    }

    /// <summary>
    /// Get panel status.
    /// </summary>
    /// <returns>bool</returns>
    public bool isDisplayed() {
        return this.displayed;
    }

    /// <summary>
    /// Set panel status.
    /// </summary>
    /// <param name="newStatus">bool - panel new status</param>
    /// <returns>void</returns>
    public void SetPanelStatus( bool newStatus ) {
        this.displayed = newStatus;
    }

    /// <summary>
    /// Display panel.
    /// </summary>
    /// <returns>void</returns>
    public void DisplayPanel() {

        // display scene cover transparent.
        sceneCover.gameObject.SetActive( true );
        sceneCover.ShowTransparency();

        // display panel.
        Utils.instance.TriggerAnimation( animation, "DisplayPlanel" );
        this.SetPanelStatus( true );
    }

    /// <summary>
    /// Hide panel status.
    /// </summary>
    /// <returns>void</returns>
    public void HidePanel() {

        // remove scene cover transparency.
        StartCoroutine( sceneCover.HideTransparency() );

        // hide panel.
        Utils.instance.TriggerAnimation( animation, "HidePanel" );
        this.SetPanelStatus( false );
    }
}
