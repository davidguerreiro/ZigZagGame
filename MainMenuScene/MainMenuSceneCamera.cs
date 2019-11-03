using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSceneCamera : MonoBehaviour {

    public PlayerModelWrapper playerModel;                              // Player model wrapper class component reference.

    /// <summary>
    /// Event function to trigger
    /// main menu scene player animation
    /// during camera animation.
    /// </summary>
    /// <returns>void</returns>
    public void PlayPlayerModelAnimaitonEvent() {
        playerModel.DisplayMainMenuPlayerAnim();
    }
}
