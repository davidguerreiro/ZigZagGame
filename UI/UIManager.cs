using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;           // Set this clas as an instance - it can be accessed by any other script automatically.
    public GameObject zigzagPanel;              // Game panel gameObject.
    public GameObject gameOverPanel;            // Game Over panel gameObject.
    public GameObject tapText;                  // Tap Text gameObject.
    public Text score;                          // Score component.
    public Text highscore1;                     // High Score component.
    public Text highScore2;                     // High Score component.

    /// <summary>
    /// Ensure there is only one instance of this
    /// class - singleton pattern.
    /// </summary>
    void Awake() {
        if ( instance == null ) {
            instance = this;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Game start logic method
    /// </summary>
    public void GameStart() {
        tapText.SetActive( false );
        zigzagPanel.GetComponent<Animator>().Play( "panelUp" );
    }

    /// <summary>
    /// Game over logic method.
    /// </summary>
    public void GameOver() {
        gameOverPanel.SetActive( true );
    }

    /// <summary>
    /// Reset the current scene on game over.
    /// </summary>
    public void Reset() {
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
    }
}
