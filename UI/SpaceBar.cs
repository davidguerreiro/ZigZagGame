using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceBar : MonoBehaviour
{
    public float interval = 1f;                     // Blink interval.
    private Text text;                              // Text component.
    private bool inAnimation = false;               // Animation flag - Whether the text is in an animation or not.

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if ( ! inAnimation ) {
            StartCoroutine( BlinkText() );
        }
    }

    /// <summary>
    /// Initialise function.
    /// </summary>
    private void Init() {
        text = GetComponent<Text>();
    }

    /// <summary>
    /// Blink text coroutine.
    /// </summary>
    private IEnumerator BlinkText() {
        inAnimation = true;

        if ( text.color.a == 1f ) {
            text.color = new Color( text.color.r, text.color.g, text.color.b, 0 );
        } else {
            text.color = new Color( text.color.r, text.color.g, text.color.b, 1f );
        }

        yield return new WaitForSeconds( interval );
        inAnimation = false;
    }
}
