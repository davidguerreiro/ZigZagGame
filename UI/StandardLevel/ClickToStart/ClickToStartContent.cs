using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToStartContent : MonoBehaviour {

    private Animation animation;                                    // Animation component reference.s

    // Start is called before the first frame update
    void Start() {
        Init();
    }

    /// <summary>
    /// Display flashing text
    /// animation.
    /// </summary>
    /// <returns>void</returns>
    public void DisplayClickTextAnim() {
        Utils.instance.TriggerAnimation( animation, "ClickToStartEnabled" );
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
