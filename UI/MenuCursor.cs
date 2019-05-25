using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCursor : MonoBehaviour
{
    public float speed = 30f;                           // Cursor static animation speed.
    public float amplitude = 20f;                       // Static animation amplitude.
    private float originPosition;                       // Static animation origin position.
    private float maxPosition;                          // Static animation maximun position.
    public bool inAnimation;                           // Animation Flag - wheter the cursor is in an animation coroutine or not.
    private AudioSource audioSource;                    // Audio source component.

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        Init();
        inAnimation = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        // trigger static cursor floating movement.
        if ( ! inAnimation ) {
            StartCoroutine( StaticCursorAnimation() );
        }

        // testing
        if ( Input.GetKeyDown( "c" ) ) {
            ReproduceSelectableSound();
        }
    }

    /// <summary>
    /// Initialise cursor class.
    /// </summary>
    private void Init() {
        // calculate origin position and max position for static animation.
        originPosition = transform.localPosition.x;
        maxPosition = originPosition + amplitude;

        // get audio source component.
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Reproduce change selectable
    /// sound
    /// </summary>
    public void ReproduceSelectableSound() {
        audioSource.Play();
    }

    /// <summary>
    /// Display static cursor floating
    /// animation.
    /// </summary>
    public IEnumerator StaticCursorAnimation() {
        inAnimation = true;

        while ( transform.localPosition.x < maxPosition ) {
            transform.localPosition = new Vector2( transform.localPosition.x + ( speed * Time.deltaTime ), transform.localPosition.y );
            yield return null;
        }

        // fix variations in the movement.
        transform.localPosition = new Vector2( maxPosition, transform.localPosition.y );

        while ( transform.localPosition.x > originPosition ) {
            transform.localPosition = new Vector2( transform.localPosition.x- ( speed * Time.deltaTime ), transform.localPosition.y );
            yield return null;
        }

        // fix variations in the movement.
        transform.localPosition = new Vector2( originPosition, transform.localPosition.y );

        inAnimation = false;
    }
}
