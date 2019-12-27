using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour {

    /// <summary>
    /// Load main menu from gameover.
    /// </summary>
    /// </returns>void</returns>
    public void LoadMainMenu() {
        if ( GetComponent<AnimationComponent>().IsDisplayed() ) {
            SceneManager.LoadScene( "MainMenu" );
        }
    }
}
