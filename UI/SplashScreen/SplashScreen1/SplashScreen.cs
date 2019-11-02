using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    public GameObject splashText1;         // Splash screen text 1 GameObject.
    public GameObject splashText2;         // Splash screen text 1 GameObject.
    public GameObject subtitle;            // Subtitle Text GameObject.
    public GameObject rectangle1;          // Animation rectangle 1 GameObject.
    public GameObject rectangle2;          // Animation rectangle 2 GameObject.
    public float speed = 1500f;            // Rectangle movement speed.
    public float fadeSpeed = 15f;          // Fade speed.

    private AnimationRectangle rectangle1Class;     // Rectangle 1 AnimationRectangle class component.
    private AnimationRectangle rectangle2Class;     // Rectangle 2 AnimationRectangle class component.

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
    /// Moves rectangle to a given position.
    /// </summary>
    /// <param name="rectangle">GameObject - Rectangle GameObject instance.</param>
    /// <param name="toMove">float - where to move the rectangle.false</param>
    /// <param name="toDisplay">bool - not required - wheter we need to display an element during the animation</param>
    /// <param name="objectToDisplay">GameObject - not required - GameObject element to display during the animation</param>
    /// <param name="when">float - not required - Float value to check at which point the element has to be displayed. Uses rectangle x animation value as a reference</param>
    private IEnumerator MoveRectangle( GameObject rectangle, float toMove, bool toDisplay = false, GameObject objectToDisplay = null, float when = 0f ) {
        if ( rectangle.transform.localPosition.x < toMove ) {
            while ( rectangle.transform.localPosition.x < toMove ) {
                rectangle.transform.localPosition = new Vector2( rectangle.transform.localPosition.x + ( speed * Time.deltaTime ), rectangle.transform.localPosition.y );

                if ( toDisplay ) {
                    CheckIfElementIsDisplayed( rectangle.transform.localPosition.x, objectToDisplay, when, ref toDisplay );
                }

                yield return null;
            }
        } else {
            while( rectangle.transform.localPosition.x > toMove ) {
                rectangle.transform.localPosition = new Vector2( rectangle.transform.localPosition.x - ( speed * Time.deltaTime ), rectangle.transform.localPosition.y );

                if ( toDisplay ) {
                    CheckIfElementIsDisplayed( rectangle.transform.localPosition.x, objectToDisplay, when, ref toDisplay );
                }

                if ( rectangle.transform.position.x <= toMove ) {
                    break;
                } 

                yield return null;
            }
        }

        // after movement animation - set constant movement.
        rectangle.GetComponent<AnimationRectangle>().constantMovement = true;
    }

    /// <summary>
    /// Checks if an element needs to be displayed
    /// in the screen.
    /// </summary>
    /// <param name="rectanglePosition">float - Current rectangle x position</param>
    /// <param name="objectToDisplay">GameObject - Object to be displayed when the condition is meet</param>
    /// <param name="when">float - Used to check wheter the element has to be displayed using rectangle x position as a reference</param>
    /// <param name="toDisplay">bool - Reference to check when the parent method is awaiting for an element to be displayed</param>
    private void CheckIfElementIsDisplayed( float rectanglePosition, GameObject objectToDisplay, float when, ref bool toDisplay ) {
        if ( rectanglePosition > when ) {
            objectToDisplay.SetActive( true );
            toDisplay = false;
        }
    }

    /// <summary>
    /// Fade out element.
    /// </summary>
    /// <param name="element">Text - Text component to fade out</param>
    private IEnumerator FadeOut( Text element ) {
        while ( element.color.a > 0f ) {
            element.color = new Color( element.color.r, element.color.g, element.color.b, element.color.a - ( fadeSpeed * Time.deltaTime ) );
            yield return null;
        }
    }

    /// <summary>
    /// Main controller coroutine.
    /// This coroutine calls all the other
    /// coroutines and controls the whole animation.
    /// </summary>
    private IEnumerator AnimationController() {
        yield return new WaitForSeconds( 2f );

        // move rectangles to the center and display first splash text.
        StartCoroutine( MoveRectangle( rectangle1, 278f ) );
        yield return new WaitForSeconds( .8f );
        StartCoroutine( MoveRectangle( rectangle2, 10f, true, splashText1, -411f ) );

        yield return new WaitForSeconds( 1f );

        rectangle1Class.constantMovement = false;
        rectangle2Class.constantMovement = false;

        // move rectangles to the left.
        StartCoroutine( MoveRectangle( rectangle1, - 367f ) );

        // display second splash text.
        splashText2.SetActive( true );

        yield return new WaitForSeconds( 0.5f );
        StartCoroutine( MoveRectangle( rectangle2, - 747f ) );

        yield return new WaitForSeconds( 1f );

        // move rectangles out and display subtitle.
        rectangle1Class.constantMovement = false;
        rectangle2Class.constantMovement = false;
        StartCoroutine( MoveRectangle( rectangle1, 1460f ) );
        yield return new WaitForSeconds( .8f );
        StartCoroutine( MoveRectangle( rectangle2, 1460f, true, subtitle, 91f ) );

        yield return new WaitForSeconds( 2.5f );

        /// fade out all text.
        StartCoroutine( FadeOut( splashText1.GetComponent<Text>() ) );
        StartCoroutine( FadeOut( splashText2.GetComponent<Text>() ) );
        StartCoroutine( FadeOut( subtitle.GetComponent<Text>() ) );

        yield return new WaitForSeconds( 1.5f );

        // load main menu scene.
        SceneManager.LoadScene( "MainMenu" );

    }

    /// <summary>
    /// Initialise class.
    /// </summary>
    private void Init() {
        /// cache references to rentangle classes.
        rectangle1Class = rectangle1.GetComponent<AnimationRectangle>();
        rectangle2Class = rectangle2.GetComponent<AnimationRectangle>();

        // start animation controller coroutine.
        StartCoroutine( AnimationController() );
    }
}
