using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager instance;       // Create public instance for this manager to be called from other scripts.
    public Text descriptionTitle;                 // Game mode description title.
    public Text description;                      // Game mode description.
    public Text maintTitle;                       // Main title text component.
    public GameObject pressSpaceBar;              // Press space bar text component.
    public GameObject mainMenu;                   // Main menu UI panel gameObject.
    public GameObject descriptionPanel;           // Game option description UI panel gameObject.
    public AudioClip startGameSound;              // Start game sound clip.
    public SceneCover sceneCover;                 // Scene cover class component to make screen transition smoother.
    private float fadeSpeed = 0.8f;               // Main title fade in speed.
    private float movementSpeed = 500f;           // Menu appaerance speed for animation.
    private AudioSource audio;                    // Audio Source component.



    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        if ( instance == null ) {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    private void Init() {
        // get audio component.
        audio = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Update description title.
    /// </summary>
    /// <param name="text">string - text to update</param>
    public void UpdateDescTitle( string text ) {
        if ( descriptionTitle != null ) {
            descriptionTitle.text = text;
        }
    }

    /// <summary>
    /// Update description content. 
    /// </summary>
    /// <param name="text">string - text to update</param>
    public void UpdateDescContent( string text ) {
        if ( description != null ) {
            description.text = text;
        }
    }

    /// <summary>
    /// Display main title text
    /// in the scene.
    /// </summary>
    public IEnumerator DisplayMainTitle() {
        while ( maintTitle.color.a < 1f ) {
            maintTitle.color = new Color( maintTitle.color.r, maintTitle.color.g, maintTitle.color.b, maintTitle.color.a + ( fadeSpeed * Time.deltaTime ) );
            yield return null;
        }

        // display press space bar text.
        ToggleSpaceBarText( true );
    }

    /// <summary>
    /// Display / hide press bar
    /// button to open menu.
    /// </summary>
    /// <param name="state">bool - new state for the gameObject</param>
    public void ToggleSpaceBarText( bool state ) {
        pressSpaceBar.SetActive( state );
    }

    /// <summary>
    /// Display main menu in
    /// the scene.
    /// </summary>
    public IEnumerator DisplayMainMenu() {
        float toMove = 1507f;                   // Final position for the main menu in the screen.
        mainMenu.SetActive( true );

        while ( mainMenu.transform.position.x > toMove ) {
            mainMenu.transform.position = new Vector2( mainMenu.transform.position.x - ( movementSpeed * Time.deltaTime ), mainMenu.transform.position.y );
            yield return null;
        }

        // fix variants in the position after the animation.
        mainMenu.transform.position =  new Vector2( toMove, mainMenu.transform.position.y );
    }

    /// <summary>
    /// Display description bar 
    /// panel in the scene.
    /// </summary>
    public IEnumerator displayDescriptionBar() {
        float toMove = 59.7002f;
        
        while (descriptionPanel.transform.position.y < toMove ) {
            descriptionPanel.transform.position = new Vector2( descriptionPanel.transform.position.x, descriptionPanel.transform.position.y + ( movementSpeed * Time.deltaTime ) );
            yield return null;
        }

        // fix variatns in the position after the animation.
        descriptionPanel.transform.position = new Vector2( descriptionPanel.transform.position.x, toMove );
    }


}
