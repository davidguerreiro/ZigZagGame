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
    public GameObject stopGamePanel;                // Stop game panel gameObject reference.
    public HowToPlayPanel howToPlayPanel;           // How to play panel class component reference.
    private StopGamePanel stopGamePanelClass;       // Stop game panel class component reference.


    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake() {
        if ( instance == null ) {
            instance = this;
        }
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start() {
        Init();
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
        // stop game panel might be disabled.
        if ( stopGamePanel.active == false ) {
            stopGamePanel.SetActive( true );
        }

        if ( ! stopGamePanelClass.isDisplayed && ! howToPlayPanel.isDisplayed ) {
            stopGamePanelClass.DisplayPanel();
            howToPlayPanel.DisplayPanel();
        }
    }

    /// <summary>
    /// Hide how to play panel in the
    /// game.
    /// </summary>
    /// <returns>void</returns>
    public void HideHowToPlay() {
        if ( stopGamePanelClass.isDisplayed && howToPlayPanel.isDisplayed ) {
            StartCoroutine( stopGamePanelClass.HidePanel() );
            howToPlayPanel.HidePanel();
        }
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    /// <returns>void</returns>
    private void Init() {
        // get stop game panel class reference - this is done beacuse this script needs the real gameobject to check if it is enabled before calling functions.
        if ( stopGamePanel.active == false ) {
            stopGamePanel.SetActive( true );
            stopGamePanelClass = stopGamePanel.GetComponent<StopGamePanel>();
            stopGamePanel.SetActive( false );
        }
    }
}
