using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedText : MonoBehaviour {
    public Letter[] letters = new Letter[13];               // Letters which compounds the animated text array reference.
    public bool inAnimation = false;

    /// <summary>
    /// Animate text.
    /// </summary>
    /// <returns>IEnumerator</returns>
    public IEnumerator Animate() {
        float toWait = 1f;                          // Seconds to wait between letters animaiton in animation loop.
        float toWaitAfter = 2f;                     // Seconds to wait between each set of animation.

        inAnimation = true;

        while ( inAnimation ) {

            foreach ( Letter letter in letters ) {
                letter.Animate();
                yield return new WaitForSeconds( toWait );

                // check if the coroutine has been stopped.
                if ( ! inAnimation ) {
                    yield break;
                }
            }

            // check if the coroutine has been stopped.
            if ( ! inAnimation ) {
                yield break;
            }

            yield return new WaitForSeconds( toWaitAfter );
            yield return null;
        }
    }

}
