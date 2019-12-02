using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public MainCameraLogic cameraLogic;                         // Main camera logic class component reference.

    // Start is called before the first frame update
    void Start() {
        
        // set main camera sky color.
        Utils.instance.SetSkyColor();

        // display start level animation.
        StartLevelAnimation();
    }

    /// <summary>
    /// Start level animation.
    /// </summary>
    /// <returns>void</returns>
    public void StartLevelAnimation() {

        // hide screen cover and trigger init scene camera animation.
        UIManager.instance.screenCover.Hide();
        cameraLogic.DisplayInitSceneAnimation();
    }

    /// <summary>
    /// Display all UI elements
    /// in the game scene so the player
    /// can start playing.
    /// </summary>
    /// <returns>IEnumerator</returns>
    public IEnumerator DisplayUIElements() {
        yield return new WaitForSeconds( 0.5f );

        // display top bar.
        UIManager.instance.TopBar.DisplayTopBar();
        yield return new WaitForSeconds( 1f );

        // display score panel, click to start button and controls button.
        UIManager.instance.scorePanel.DisplayPanel();
        UIManager.instance.startText.DisplayElement();
        UIManager.instance.controlsButton.Display();

        // disable scene cover so user can click start playing button.
        UIManager.instance.DisableSceneCover();

        // set player character as playable to the player can start playing the game.
        BallController.instance.SetPlayableStatus( true );
    }
    

}
