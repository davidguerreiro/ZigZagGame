using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HTCloseButton : MonoBehaviour {
    
    private Animation animation;                            // Animation component reference.

    // Start is called before the first frame update
    void Start() {
        Init();
    }

    /// <summary>
    /// Hover button animation.
    /// </summary>
    /// <returns>void</returns>
    public void HoverAnimation() {
        Utils.instance.TriggerAnimation( animation, "CloseButtonHover" );
    }

    /// <summary>
    /// Lost hover button animation.
    /// </summary>
    /// <returns>void</returns>
    public void LostHoverAnimation() {
        Utils.instance.TriggerAnimation( animation, "CloseButtonLostHover" );
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    /// <returns>void</returns>
    public void Init() {

        // get animation component.
        animation = GetComponent<Animation>();
    }
}
