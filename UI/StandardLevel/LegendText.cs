using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LegendText : MonoBehaviour {
    private Text text;                              // Text component.
    private bool inScreen = true;                   // Flag to control wheter the text can be in the screen.
    private float lifespan = 2f;                    // Number of seconds that the text can be in the screen.
    private float speed = 120f;                     // Text movement speed.
    private float fadeSpeed = 0.8f;                 // Text fade speed for fade in/our animation.
    public string type = "standard";                // Type defines the visual layout of the text.

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        Init();

        // trigger coroutines to fade in, move and remove text.
        InitialiseText();   
    }

    // Start is called before the first frame update
    void Start()
    {
        // Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    public void Init() {

        // get text component.
        text = GetComponent<Text>();
        
    }

    /// <summary>
    /// Display text.
    /// </summary>
    private IEnumerator FadeInText() {

        // get text component if init fails.
        if ( text == null ) {
            text = GetComponent<Text>();
        }
        
        while ( text.color.a < 1f ) {
            text.color = new Color( text.color.r, text.color.g, text.color.b, text.color.a + ( fadeSpeed * Time.deltaTime ) );
            yield return null;
        }

        // fix variations in the animation.
        text.color = new Color( text.color.r, text.color.g, text.color.b, 1f );
    }

    /// <summary>
    /// Fade out text.
    /// </summary>
    private IEnumerator FadeOutText() {

        // get text component if init fails.
        if ( text == null ) {
            text = GetComponent<Text>();
        }
        
        while ( text.color.a > 0f ) {
            text.color = new Color( text.color.r, text.color.g, text.color.b, text.color.a - ( fadeSpeed * Time.deltaTime ) );
            yield return null;
        }

        // fix variations in the animation.
        text.color = new Color( text.color.r, text.color.g, text.color.b, 0f );

        inScreen = false;
        Destroy( this.gameObject );
    }

    /// <summary>
    /// Move text up whilist
    /// the text is in the screen.
    /// </summary>
    private IEnumerator MoveText() {
        
        while ( inScreen ) {
            transform.localPosition = new Vector2( transform.localPosition.x, transform.localPosition.y + ( speed * Time.deltaTime ) );
            yield return null;
        }

        yield break;
    }

    /// <summary>
    /// Count lifespan and then remove
    /// text from the screen.
    /// </summary>
    private IEnumerator CountLifesSpan() {
        yield return new WaitForSeconds( lifespan );

        // fade out text.
        StartCoroutine( FadeOutText() );
    }

    /// <summary>
    /// Initialise this text in the screen.
    /// </summary>
    public void InitialiseText() {
        
        // set flag for text to be available in the screen.
        inScreen = true;

        // call coroutines to fade in text, move text and count the lifespam before it is removed.
        StartCoroutine( FadeInText() );
        StartCoroutine( MoveText() );
        StartCoroutine( CountLifesSpan() );
    }

    /// <summary>
    /// Update displayed text.
    /// </summary>
    /// <param name="newText">string - new text to display.</param>
    public void UpdateText( string newText ) {
        text.text = newText;
    }

    /// <summary>
    /// Set text color.
    /// </summary>
    /// <param name="newColor">Color - new color to set for the new text</param>
    public void SetTextColor( Color newColor ) {
        text.color = newColor;
    }

}
