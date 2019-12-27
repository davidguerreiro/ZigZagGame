using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPanel : MonoBehaviour {
    public AnimationComponent timeText;                     // Time text animation class component reference.
    public AnimationComponent timeWrapper;                  // Time values wrapper animation class component reference.
    public AnimationComponent scoreText;                    // Score text animation class component reference.
    public AnimationComponent score;                        // Score value animation class component reference.

    /// <summary>
    /// Display elements in the game
    /// over panel.
    /// </summary>
    /// <returns>IEnumerator</returns>
    public IEnumerator DisplayElements() {
        float gap = .2f;

        // display time text and time values.
        timeText.Display();
        timeWrapper.Display();
        yield return new WaitForSeconds( gap );

        // display score text and score values.
        scoreText.Display();
        score.Display();
        yield return new WaitForSeconds( gap );
    }
}
