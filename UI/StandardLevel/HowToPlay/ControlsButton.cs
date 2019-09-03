using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsButton : MonoBehaviour {

    /// <summary>
    /// Disable button.
    /// </summary>
    /// <returns>void</returns>
    public void DisableButton() {
        gameObject.SetActive( false );
    }

}
