using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    public bool isDisplayed = false;                            // Flag to control whether the main menu is displayed in the game scence.
    public MainMenuButtonWrapper playButton;                    // Play button class component reference.
    private Animation animation;                                // Animation component reference.

    // Start is called before the first frame update
    void Start() {
        Init();
    }

    /// <summary>
    /// Display main menu in the
    /// game scene and put the focus in
    /// the play button.
    /// </summary>
    /// <returns>IEnumerator</returns>
    public IEnumerator DisplayMainMenu() {

        // display menu component.
        Utils.instance.TriggerAnimation( animation, "DisplayMenu" );
        isDisplayed = true;

        yield return new WaitForSeconds( .5f );

        // set the navigation focus in the play button.
        playButton.onFocus();

    }

    /// <summary>
    /// Init class method.
    /// </summary>
    /// <returns>void</returns>
    private void Init() {

        // get animation component.
        animation = GetComponent<Animation>();
    }
}
