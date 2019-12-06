using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {
    public GameObject topDecorative;                    // Top decorative prefab gameObject reference. This decorative can only be displayed with top oriented platforms.
    public GameObject rightDecorative;                  // Right decorative prefab gameObject reference. This decorative can only be displayed with right oriented platforms.
    private string orientation;                         // Platform orientation. Values can be "top" or "right".

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    /// <returns>void</returns>
    void Start() {
        Init();
    }

    /// <summary>
    /// Get orientation value.
    /// </summary>
    /// <returns>string</returns>
    public string GetOrientation() {
        return this.orientation;
    }

    /// <summary>
    /// Set orientation value.
    /// </summary>
    /// <param name="newOrientation">string - new platform orientation</param>
    /// <returns>void</returns>
    public void SetOrientation( string newOrientation ) {
        this.orientation = newOrientation;
    }

    /// <summary>
    /// Display decorative in this platform.
    /// </summary>
    /// <returns>void</returns>
    public void DisplayDecorative() {
        if ( this.orientation == "top" ) {
            topDecorative.SetActive( true );
        } else {
            rightDecorative.SetActive( true );
        }
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    /// <returns>void</returns>
    private void Init() {

        // set orientation default value to "top".
        this.orientation = "top";
    }
}
