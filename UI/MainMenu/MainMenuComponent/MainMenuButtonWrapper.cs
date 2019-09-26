using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonWrapper : MonoBehaviour {
    private Animation animation;                         // Animation component reference.

    // Start is called before the first frame update
    void Start() {
        Init();
    }


    /// <summary>
    /// Set button on focus when
    /// the cursor is over this item.
    /// </summary>
    /// <returns>void</returns>
    public void onFocus() {
        Utils.instance.TriggerAnimation( animation, "ButtonFocus" );
    }

    /// <summary>
    /// Set botton on unFocus
    /// when this item lost the cursor.
    /// </summary>
    /// <returns>void</returns>
    public void onFocusLost() {
        Utils.instance.TriggerAnimation( animation, "BUttonUnFocus" );
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    /// <returns>void</returns>
    private void Init() {

        // get animation component reference.
        animation = GetComponent<Animation>();
    }
}
