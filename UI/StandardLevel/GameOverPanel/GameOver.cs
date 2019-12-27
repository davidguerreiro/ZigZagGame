using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
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
    /// Display game over panel and
    /// all the animations and components inside
    /// the panel.
    /// </summary>
    /// <returns>IEnumeratir</returns>
    public IEnumerator DisplayGameOver() {
        
        // update values.
        dataPanel.UpdateValues( score.text, hours.text, minutes.text, seconds.text );

        // display screen cover.
        screenCover.Display();
        yield return new WaitForSeconds( .2f );

        // display game over title.
        titleWrapper.DisplayTitleAnimation();
        yield return new WaitForSeconds( 1f );

        // display data panel components.
        dataPanel.DisplayElements();
        yield return new WaitForSeconds( .5f );

        // display buttons.
        playAgainButton.Display();
        yield return new WaitForSeconds( .1f );
        mainMenuButton.Display();
    }
}
