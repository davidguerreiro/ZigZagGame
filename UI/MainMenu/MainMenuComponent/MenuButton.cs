using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, ISelectHandler {

    public bool onFocus = false;                                    // Flag to control when this button is on focus.
    private MainMenuButtonWrapper buttonWrapper;                    // Button wrapper class component refernce. Coming from the parent, it is used for selectable button animations.
    private Animation animation;                                    // Animation component reference.
    private AudioSource audio;                                      // Audio source component reference.

    // Start is called before the first frame update
    void Start() {
        Init();
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    /// <returns>void</returns>
    private void Init() {

        // get button wrapper class component reference from parent.
        buttonWrapper = GetComponentInParent<MainMenuButtonWrapper>();

        // get animation component reference.
        animation = GetComponent<Animation>();
    }

    /// <summary>
    /// Selectable button has
    /// the game cursor.
    /// </summary>
    /// <returns>IEnumerator</returns>
    private IEnumerator ButtonOnFocus() {
        float toWait = 2f;

        // set button new status.
        onFocus = true;

        // play sound effect and trigger animations.
        audio.Play();
        buttonWrapper.onFocus();
        
        yield return new WaitForSeconds( toWait );
        Utils.instance.TriggerAnimation( animation, "ButtonInFocus" );

        // check if the button has lost the focus during the time the coroutine was being executed.
        if ( ! onFocus ) {
            animation.Stop();
        }
    }

    /// <summary>
    /// Selectable button has lost
    /// the game cursor.
    /// </summary>
    /// <returns>void</returns>
    private void ButtonLostFocus() {
        
        // set button new status.
        onFocus = false;
        
        // stop focus animation and display lost focus animation.
        animation.Stop();
        buttonWrapper.onFocusLost();
    }

    /// <summary>
    /// Event handler for mouse pointer
    /// enter event.
    /// </summary>
    /// <param name="eventData">PointerEventData - event data reference</param>
    /// <returns>void</returns>
    public void OnPointerEnter( PointerEventData eventData ) {
        StartCoroutine( ButtonOnFocus() );
    }

    /// <summary>
    /// Event handler for hover
    /// event on button using
    /// the keyboard.
    /// </summary>
    /// <param name="eventData">BaseEventData - event data reference</param>
    /// <returns>void</returns>
    public void OnSelect( BaseEventData eventData ) {
        StartCoroutine( ButtonOnFocus() );
    }

    /// <summary>
    /// Event handler for mouse pointer
    /// exit event.
    /// </summary>
    /// <param name="eventData">PointerEventData - event data reference</param>
    /// <returns>void</returns>
    public void OnPointerExit( PointerEventData eventData ) {
        ButtonLostFocus();
    }

    /// <summary>
    /// Event handler for unHover
    /// event on button using
    /// the keyboard.
    /// </summary>
    /// <param name="eventData">BaseEventData - event data reference</param>
    /// <returns>void</returns>
    public void OnDeselect( BaseEventData eventData ) {
        ButtonLostFocus();
    }
}
