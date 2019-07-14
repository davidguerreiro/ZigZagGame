using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DefeatedPanel : MonoBehaviour
{

    public float toMoveY;                               // Where to move the defeated panel once is enabled.
    public float speed = 10f;                           // Animation speed.
    public float fadeSpeed = 10f;                       // Fade in speed.
    private float initialYPosition;                     // Panel initial Y position.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Display defeated panel
    /// on the screen.
    /// </summary>
    public void DisplayPanel() {
        StartCoroutine( MovePanel() );
        // StartCoroutine( FadeInPanel() );
        
    }

    /// <summary>
    /// Move the inside the canvas.
    /// </summary>
    private IEnumerator MovePanel() {
        while ( transform.localPosition.y > toMoveY ) {
            transform.localPosition = new Vector2( transform.localPosition.x, transform.localPosition.y - ( speed * Time.deltaTime ) );
            yield return null;
        } 
    }

    /// <summary>
    /// Fade in panel.
    /// </summary>
    private IEnumerator FadeInPanel() {
        Image image = GetComponent<Image>();

        while ( image.color.a < 1f ) {
            image.color = new Color( image.color.r, image.color.g, image.color.b, image.color.a + ( fadeSpeed * Time.deltaTime ) );
            yield return null;
        }
    }

    /// <summary>
    /// Initialise class method.
    /// </summary>
    private void Init() {
        initialYPosition = transform.localPosition.y;
    }

    /// <summary>
    /// Restart current scene
    /// when the user clicks Restart
    /// button.
    /// </summary>
    public void RestartLevel() {
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
    }
}
