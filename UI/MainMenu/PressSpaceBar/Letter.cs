using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour {

    private Animation animation;                    // Animation component reference.

    // Start is called before the first frame update
    void Start() {
        Init();
    }

    /// <summary>
    /// Init class animation.
    /// </summary>
    /// <returns>void</returns>
    private void Init() {

        // get animation component reference.
        animation = GetComponent<Animation>();
    }

    /// <summary>
    /// Display letter animation.
    /// </summary>
    /// <returns>void</returns>
    public void Animate() {
        Utils.instance.TriggerAnimation( animation, "LetterBounce" );
    }
}
