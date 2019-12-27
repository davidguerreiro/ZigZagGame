using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    private bool displayed;                           // Flag to control when the gameOver panel is displayed.
    public TitleWrapper titleWrapper;                   // Title wrapper class component reference.
    public DataPanel dataPanel;                         // Data panel class component reference.
    public AnimationComponent playAgainButton;          // Play again button animation component reference.
    public AnimationComponent mainMenuButton;           // Main menu button animation component reference.
    public Text score;                                  // Score text component reference.
    public Text hours;                                  // Hours text component reference.
    public Text minutes;                                // Minutes text component reference.
    public Text seconds;                                // Seconds text component reference.
    public MainLevelScreenCover screenCover;            // Screen cover component reference.

    /// <summary>
    /// Get displayed status.
    /// </summary>
    /// <returns>bool</returns>
    public bool IsDisplayed() {
        return this.displayed;
    }
    
    /// <summary>
    /// Display game over panel and
    /// all the animations and components inside
    /// the panel.
    /// </summary>
    /// <returns>IEnumerator</returns>
    public IEnumerator DisplayGameOver() {

        this.displayed = true;
        
        // update values.
        yield return new WaitForSeconds( .1f );
        dataPanel.UpdateValues( score.text, hours.text, minutes.text, seconds.text );

        // display screen cover.
        screenCover.gameObject.SetActive( true );
        screenCover.Display();
        yield return new WaitForSeconds( .2f );

        // display game over title.
        StartCoroutine( titleWrapper.DisplayTitleAnimation() );
        yield return new WaitForSeconds( 1f );

        // display data panel components.
        StartCoroutine( dataPanel.DisplayElements() );
        yield return new WaitForSeconds( .5f );

        // display buttons.
        playAgainButton.Display();
        yield return new WaitForSeconds( .1f );
        mainMenuButton.Display();
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    /// <returns>void</returns>
    public void Init() {

        // set attributes default values.
        this.displayed = false;
    }
}
