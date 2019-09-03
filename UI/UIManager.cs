using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {  
    public static UIManager instance;               // Public instance for static calls from other components.
    public GameObject TopBar;                       // UI top bar gameObject.
    public GameObject scorePanel;                   // UI score panel gameObject.
    public GameObject defeatedPanel;                // UI defeated panel gameObject.
    public GameObject startText;                    // UI start text gameObject.
    public Score score;                             // Score class.
    public Lifes lifes;                             // Lifes class.
    public StopGamePanel stopGamePanel;             // Stop game panel class component refernce.
    public HowToPlayPanel howToPlayPanel;           // How to play panel class component reference.


    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake() {
        if ( instance == null ) {
            instance = this;
        }
    }

    /// <summary>
    /// Update score UI manager method.
    /// </summary>
    /// <param name="amount">int - amount to update</param>
    public void UpdateScore( int amount ) {
        score.UpdateScore( amount );
    }

    /// <summary>
    /// Update lifes UI manager method.
    /// </summary>
    /// <param name="amount">int - amount to update</param>
    public void UpdateLifes( int amount ) {
        lifes.UpdateLifes( amount );
    }

    /// <summary>
    /// Display player defeated
    /// panel.
    /// </summary>
    public void DisplayDefeatedPanel() {
        defeatedPanel.GetComponent<DefeatedPanel>().DisplayPanel();
    }

    /// <summary>
    /// Diplay how to play panel in the
    /// game.
    /// </summary>
    /// <returns>void</returns>
    public void DisplayHowToPlay() {
        if ( ! stopGamePanel.isDisplayed && ! howToPlayPanel.isDisplayed ) {
            stopGamePanel.DisplayPanel();
            howToPlayPanel.DisplayPanel();
        }
    }

    /// <summary>
    /// Hide how to play panel in the
    /// game.
    /// </summary>
    /// <returns>void</returns>
    public void HideHowToPlay() {
        if ( stopGamePanel.isDisplayed && howToPlayPanel.isDisplayed ) {
            stopGamePanel.HidePanel();
            howToPlayPanel.HidePanel();
        }
    }
}
