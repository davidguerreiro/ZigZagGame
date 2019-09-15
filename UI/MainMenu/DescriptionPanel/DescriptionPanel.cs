﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionPanel : MonoBehaviour {
    
    public bool isDisplayed = false;                                // Description panel status.
    public AnimatedBall[] animatedBalls = new AnimatedBall[3];      // UI Animated balls array reference.
    private Animation animation;

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
    /// Display panel and animated
    /// balls.
    /// </summary>
    /// <returns>IEnumerator</returns>
    public IEnumerator DisplayPanel() {
        float toWait = 1.5f;

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
            ball.DisplayBall();
            yield return new WaitForSeconds( toWait );
        }
    }
}
