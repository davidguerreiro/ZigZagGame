using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDEffects : MonoBehaviour
{
    public GameObject releaseSpeedEffect;                           // Release Speed gameoObject animation container.
    public bool inAnimation = false;                                // Wheter an animaiton is being played.

    /// <summary>
    /// Released Speed effect animation.
    /// </summary>
    public IEnumerator ReleaseSpeedEffectAnim() {
        float duration  = 0.5f;
        inAnimation = true;

        // animation in children gameObjects will be triggered in loop automatically.
        releaseSpeedEffect.SetActive( true );

        yield return new WaitForSeconds( duration );

        // wrapper animation gameObject can be disabled by other methods, so before
        // disabling it we have to check if it is still active.
        if ( releaseSpeedEffect.activeSelf ) {
            releaseSpeedEffect.SetActive( false );
        }

        inAnimation = false;
    }

    /// <summary>
    /// Stop Release Speed animation.
    /// </summary>
    public void StopReleaseEffectAnim() {
        
        // wrapper animation gameObject can be disabled by other methods
        // so we need to check if it is still active before disabling it.
        if ( releaseSpeedEffect.activeSelf ) {
            releaseSpeedEffect.SetActive( false );
        }

        inAnimation = false;
    }
}
