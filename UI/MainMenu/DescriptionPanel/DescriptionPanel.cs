using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionPanel : MonoBehaviour {
    
    public bool isDisplayed = false;                                // Description panel status.
    public Text description;                                        // Description text component reference.
    public AnimatedBall[] animatedBalls = new AnimatedBall[3];      // UI Animated balls array reference.
    private Animation animation;                                    // Animation component reference.

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
    /// Update description in the
    /// description panel.
    /// </summary>
    /// <param name="content">string - new description text</param>
    /// <returns>void</returns>
    public void UpdateDescription( string content ) {
        description.text = content;
    }

    /// <summary>
    /// Display panel and animated
    /// balls.
    /// </summary>
    /// <returns>IEnumerator</returns>
    public IEnumerator DisplayPanel() {
        float toWait = 1f;

        Utils.instance.TriggerAnimation( animation, "DisplayDescriptionPanel" );
        yield return new WaitForSeconds( toWait );
        
        // display animated balls in the UI.
        StartCoroutine( DisplayAnimatedBalls() );

        isDisplayed = true;
    }

    /// <summary>
    /// Display animated balls in the UI.
    /// </summary>
    /// <returns>IEnumerator</returns>
    private IEnumerator DisplayAnimatedBalls() {
        float toWait = 0.8f;

        // display balls.
        foreach ( AnimatedBall ball in animatedBalls ) {
            StartCoroutine( ball.DisplayBall() );
            yield return new WaitForSeconds( toWait );
        }
    }
}
