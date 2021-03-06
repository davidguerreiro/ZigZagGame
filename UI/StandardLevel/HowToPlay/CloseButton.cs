﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour {

    private Animation animation;                            // Animation component reference.

    // Start is called before the first frame update
    void Start() {
        Init();
    }

    /// <summary>
    /// Hover animation trigger method.
    /// </summary>
    /// <returns>void</returns>
    public void HoverAnimation() {
        Utils.instance.TriggerAnimation( animation, "CloseHowToPlayHover" );
    }

    /// <summary>
    /// Unhover animation trigger method.
    /// </summary>
    /// <returns>void</returns>
    public void UnHoverAnimation() {
        Utils.instance.TriggerAnimation( animation, "CloseHowToPlayUnHover" );
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
