using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedBall : MonoBehaviour {

    public bool isDisplayed = false;                // Whether the ball is displayed in the scene or hidden.
    public string displayAnimation;                 // Display ball animation name.
    public string bouncingAnimation;                // Bouncing ball animation name.
    private Animation animation;                    // Animation component reference.

    // Start is called before the first frame update
    void Start() {
        Init();
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    /// <returns>void</returns>
    private void Init() {

        // get animation component reference.
        animation = GetComponent<Animation>();
    }

    /// <summary>
    /// Display ball and animate ball with bounciness.
    /// </summary>
    /// <returns>IEnumerator</returns>
    public IEnumerator DisplayBall() {
        float toWait = 2f;

        // show display ball animation.
        Utils.instance.TriggerAnimation( animation, displayAnimation );
        yield return new WaitForSeconds( toWait );
        isDisplayed = true;

        // show bounciness animation.
        Utils.instance.TriggerAnimation( animation, bouncingAnimation );
    }
}
