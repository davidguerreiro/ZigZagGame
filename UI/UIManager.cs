using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{  
    public static UIManager instance;               // Public instance for static calls from other components.
    public GameObject TopBar;                       // UI top bar component.
    public GameObject scorePanel;                   // UI score panel component.
    public GameObject startText;                    // UI start text component.
    public Score score;                             // Score class.
    public Lifes lifes;                             // Lifes class.

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        if ( instance == null ) {
            instance = this;
        }
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        
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
}
