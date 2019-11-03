using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {
    public static MainMenuManager instance;             // Create public instance for this manager to be called from other scripts.
    public Text maintTitle;                             // Main title text component.
    public AudioClip startGameSound;                    // Start game sound clip.
    public SceneCover sceneCover;                       // Scene cover class component to make screen transition smoother.
    private float fadeSpeed = 0.8f;                     // Main title fade in speed.
    private float descriptionMovementSpeed = 500f;      // Menu appaerance speed for animation.
    private float  mainMenuMovementSpeed = 1350f;        // Main menu appearence speed for animation.
    private AudioSource audio;                          // Audio Source component.

    // new components.
    public GameTitle gameTitle;                         // Game title image component class reference.
    public DescriptionPanel descriptionPanel;           // Description panel component class reference.
    public PressSpaceBar pressSpaceBarComponent;        // Press space bar game component class refernce.
    public MainMenu mainMenu;                           // Main menu game component class reference.



    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake() {
        if ( instance == null ) {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start() {
        Init();
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    private void Init() {

        // get audio component.
        audio = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Update description content. 
    /// </summary>
    /// <param name="text">string - text to update</param>
    public void UpdateDescContent( string text ) {
        descriptionPanel.UpdateDescription( text );
    }

    /// <summary>
    /// Display main title text
    /// in the scene.
    /// </summary>
    public IEnumerator DisplayMainTitle() {
        float toWait = 1f;

        // display main title.
        gameTitle.DisplayTitle();
        yield return new WaitForSeconds( toWait );

        // display press space bar text.
        pressSpaceBarComponent.DisplayPanel();
        yield return new WaitForSeconds( 1f );

        // start press space bar text animation.
        StartCoroutine( pressSpaceBarComponent.animatedText.Animate() );
    }

    /// <summary>
    /// Load main level in survival
    /// mode once the user selects 
    /// survival mode in main menu.
    /// </summary>
    public void LoadSurvivalMode() {
        // stop background music.
        Camera.main.GetComponent<AudioSource>().Stop();

        // display start playing soung.
        audio.clip = startGameSound;
        audio.Play();

        // fade in scene cover for smoother transition.
        sceneCover.gameObject.SetActive( true );
        StartCoroutine( sceneCover.FadeIn() );

        // load survival level.
        StartCoroutine( CorToLoadLevel() );
    }

    /// <summary>
    /// Coroutine to load level.
    /// </summary>
    private IEnumerator CorToLoadLevel() {
        yield return new WaitForSeconds( 2.5f );
        SceneManager.LoadScene( "StandardLevel" );
    }

}
