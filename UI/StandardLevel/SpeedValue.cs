using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedValue : MonoBehaviour
{
    public static SpeedValue instance;                                  // Static instance of this class to be called from other scripts.
    public float uiSpeed = 1f;                                          // Current UI speed.
    public float baseUISpeed = 1f;                                      // Base UI speed.
    public float minUISpeed = 0f;                                       // Min value for UI speed.
    public float maxUISpeed = 2f;                                       // Max value for the UI speed.
    private float animationSpeed = 0.02f;                                // Counter animation speed.
    private Text content;                                               // Text component.

    // Animation coroutines flags.
    bool stopMaxReducer = false;                                        // Reducer from 1 to 0 speed control flag.
    bool stopNormalReducer = false;                                     // Reducer from 2 to 1 speed control flag.
    bool stopMaxIncreaser = false;                                      // Increaser from current UI speed to 2 speed control flag.

    bool inMaxReducer = false;                                          // Whether a max reducer coroutine is in place.
    bool inNormalReducer = false;                                       // Wheter a min reducer coroutine is in place.
    bool inMaxIncreaser = false;                                        // Wheter a max increased coroutine is in place.

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
    /// Update speed value in the
    /// UI element.
    /// </summary>
    /// <param name="speed">float - speed value</param>
    /// <param name="external">bool - optional - wheter the value comes from external function or script</param>
    public void UpdateUISpeed( float speed, bool external = false ) {

        // ensure local UI speed is in line with 
        if ( external ) {
            uiSpeed = speed;
        }

        string toFix = ( Mathf.Approximately( speed, Mathf.RoundToInt( speed ) ) ) ? "F0" : "F1";
        content.text = speed.ToString( toFix );
    }

    /// <summary>
    /// Check running UI speed coroutines.
    /// </summary>
    public void CheckRunningCoroutines() {
        if ( inMaxIncreaser ) {
            stopMaxIncreaser = true;
        }

        if ( inNormalReducer ) {
            stopNormalReducer = true;
        }

        if ( inMaxReducer ) {
            stopMaxReducer = true;
        }
    }

    /// <summary>
    /// Trigger different actions
    /// and animations for the 
    /// UI speed component.
    /// </summary>
    /// <param name="action">string - which action to trigger</param>
    public void TriggerUISpeedAction( string action ) {
        // disable other coroutines in action before starting a new one.
        CheckRunningCoroutines();

        // decrease speed to 0.
        if ( action == "maxReducer" && ! inMaxReducer ) {
            StartCoroutine( MaxReducer() );
        }

        // decrease speed to baseSpeed.
        if ( action == "normalReducer" && ! inNormalReducer ) {
            StartCoroutine( NormalReducer() );
        }

        // increase speed to maxSpeed.
        if ( action == "maxIncrease" && ! inMaxIncreaser ) {
            StartCoroutine( MaxIncreaser() );
        }
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    private void Init() {

        // get text component.
        content = GetComponent<Text>();
        
        // update UI value.
        content.text = uiSpeed.ToString(); 
    }

    /// <summary>
    /// Reduce UI speed from current speed to 
    /// min UI speed.
    /// </summary>
    private IEnumerator MaxReducer() {
        inMaxReducer = true;

        while ( uiSpeed > minUISpeed ) {

            // controler to avoid this coroutine to overlap other animations.
            if ( stopMaxReducer ) {
                stopMaxReducer = false;
                inMaxReducer = false;
                yield break;
            }

            uiSpeed = uiSpeed - 0.1f;
            UpdateUISpeed( uiSpeed );

            yield return new WaitForSeconds( animationSpeed );
            yield return null;
        }

        // fix variations in the speed.
        uiSpeed = minUISpeed;
        UpdateUISpeed( uiSpeed );

        inMaxReducer = false;
    }

    /// <summary>
    /// Reduce UI speed from max speed
    /// to base speed.
    /// </summary>
    private IEnumerator NormalReducer() {
        inNormalReducer = true;

        while ( uiSpeed > baseUISpeed ) {

            // controller to avoid this coroutine to overlap other animations.
            if ( stopNormalReducer ) {
                stopMaxReducer = false;
                inNormalReducer = false;
                yield break;
            }

            uiSpeed = uiSpeed - 0.1f;
            UpdateUISpeed( uiSpeed );

            yield return new WaitForSeconds( animationSpeed );
            yield return null;
        }

        // fix variations in the speed.
        uiSpeed = baseUISpeed;
        UpdateUISpeed( uiSpeed );

        inNormalReducer = false;
    }

    /// <summary>
    /// Increase UI speed from current UI
    /// speed to max UI speed.
    /// </summary>
    private IEnumerator MaxIncreaser() {
        inMaxIncreaser = true;

        while ( uiSpeed < maxUISpeed ) {

            // controller to avoid this coroutine to overlap other coroutines.
            if ( stopMaxIncreaser ) {
                stopMaxIncreaser = false;
                inMaxIncreaser = false;
                yield break;
            }

            uiSpeed = uiSpeed + 0.1f;
            UpdateUISpeed( uiSpeed );

            yield return new WaitForSeconds( animationSpeed );
            yield return null;
        }

        // fix variations in the speed.
        uiSpeed = maxUISpeed;
        UpdateUISpeed( uiSpeed );

        inMaxIncreaser = true;
    }

}
