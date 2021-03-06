﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    public SceneCover sceneCover;                           // Scene cover used to make the scene transition smoother.
    public Animation scenePlayerAnimation;                  // Player main scene animation component.
    private AudioSource audio;                              // Audio source component.
    public PlayerModelBody playerModel;                     // Player model body class component reference.
    private bool readyForMenu = false;                      // Flag to control when the player can open the menu.
    private bool readyForTitle = false;                     // Flag to control when the game title and the press space bar text have to be displayed in the screen.


    // Start is called before the first frame update.
    void Start() {
        Init();

        // set camera background sky color.
        Utils.instance.SetSkyColor();

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
            StartCoroutine( DisplayMainMenus() );
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
        sceneCover.gameObject.SetActive( false );
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

        readyForMenu = true;

        // trigger random player animations in the menu coroutine.
        StartCoroutine( DisplayRandomPlayerAnimations() );
    }

    /// <summary>
    /// Display main menu and 
    /// description bar panel.
    /// </summary>
    private IEnumerator DisplayMainMenus() {
        // remove space bar text
        MainMenuManager.instance.pressSpaceBarComponent.HidePanel();

        // display enter menu SFX.
        audio.Play();
        yield return new WaitForSeconds( 1f );

        // display menus.
        StartCoroutine( MainMenuManager.instance.mainMenu.DisplayMainMenu() );
        StartCoroutine( MainMenuManager.instance.descriptionPanel.DisplayPanel() );
    }

    /// <summary>
    /// Display random player animations
    /// after the menu is displayed in
    /// the screen.
    /// </summary>
    /// <returns>IEnumerator</returns>
    private IEnumerator DisplayRandomPlayerAnimations() {

        // endless loop - animaitons will be displayed until the user choose an option.
        while ( true )  {
            yield return new WaitForSeconds( 6f );
            playerModel.DisplayPlayerInterestedAnim();
            yield return new WaitForSeconds( 2f );
            playerModel.DisplayPlayerBouncingAnim();
        }
    }
    
}
