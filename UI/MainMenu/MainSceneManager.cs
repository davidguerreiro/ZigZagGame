using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    public SceneCover sceneCover;                           // Scene cover used to make the scene transition smoother.
    public Animation scenePlayerAnimation;                  // Player main scene animation component.
    private AudioSource audio;                              // Audio source component.
    private bool readyForMenu = false;                      // Flag to control when the player can open the menu.
    private bool readyForTitle = false;                     // Flag to control when the game title and the press space bar text have to be displayed in the screen.


    // Start is called before the first frame update.
    void Start() {
        Init();

        // Start Scene anmation.
        StartCoroutine( StartScene() );
    }

    // Update is called once per frame.
    void Update() {
        
        // check if the title and the space bar have to be displayed.
        if ( readyForTitle ) {
            StartCoroutine( DisplayTitleAndText() );
            readyForTitle = false;
        }

        // check if the player can open the menus.
        if ( readyForMenu && Input.GetKeyDown( "space" ) ) {
            DisplayMainMenus();
            readyForMenu = false;
        }
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    private void Init() {
        
        // get auidio source component.
        audio = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Display main scene camera animation.
    /// </summary>
    private IEnumerator StartScene() {

        sceneCover.Init();
        StartCoroutine( sceneCover.FadeOut() );

        // display player going to the center animation.
        yield return new WaitForSeconds( 9.5f );
        scenePlayerAnimation.Play();

        // camera animation finished.
        yield return new WaitForSeconds( 3f );
        readyForTitle = true;
    }

    /// <summary>
    /// Display game title and press
    /// space bar text.
    /// </summary>
    private IEnumerator DisplayTitleAndText() {

        // display main title.
        StartCoroutine( MainMenuManager.instance.DisplayMainTitle() );
        yield return new WaitForSeconds( 0.5f );

        // display space bar text.
        MainMenuManager.instance.ToggleSpaceBarText( true );
        readyForMenu = true;
    }

    /// <summary>
    /// Display main menu and 
    /// description bar panel.
    /// </summary>
    private void DisplayMainMenus() {
        // remove space bar text
        MainMenuManager.instance.ToggleSpaceBarText( false );

        // display enter menu SFX.
        audio.Play();

        // display menus.
        StartCoroutine( MainMenuManager.instance.DisplayMainMenu() );
        StartCoroutine( MainMenuManager.instance.displayDescriptionBar() );
    }
}
