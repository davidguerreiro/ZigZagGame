using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToStart : MonoBehaviour {
    public ClickToStartContent content;                                 // Text content class component reference.
    private Animation animation;                                        // Animation component reference.

    // Start is called before the first frame update
    void Start() {
        Init();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update() {
        
        // check if the player has started playing and if so, then remove this item from the game scene.
        CheckIfPlayerStarted();
    }

    /// <summary>
    /// Display click to
    /// start element animation.
    /// </summary>
    /// <returns>void</returns>
    public void DisplayElement() {
        // add code to display animation here.
        Utils.instance.TriggerAnimation( animation, "Display" );
        
        // play text flash animation.
        content.DisplayClickTextAnim();
    }

    /// <summary>
    /// Check if the player has
    /// started playing, and if so
    /// then remove this gameObject
    /// from the scene.
    /// </summary>
    /// <returns>void</returns>
    private void CheckIfPlayerStarted() {
        if ( BallController.instance.PlayerHasStarted() ) {
            this.gameObject.SetActive( false );
        }
     }

    /// <summary>
    /// Init class method.
    /// </summary>
    /// <returns>void</returns>
    private void Init() {

        // get animation component.
        animation = GetComponent<Animation>();
    }

}
