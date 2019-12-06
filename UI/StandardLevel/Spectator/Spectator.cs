using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spectator : MonoBehaviour {

    public Material[] colors;                                   // Possible materials to appy to the spectator.
    private Renderer body;                                       // Spectator's body renderer component.
    private Animation animation;                                // Animation component reference.
    private Transform player;                                  // Player gameObject.

    // Start is called before the first frame update
    void Start() {
        Init();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    /// <returns>void</returns>
    void Update() {
        
        // look at the player
        LookAtPlayer();
    }

    /// <summary>
    /// Set spectator color
    /// randomly from colors
    /// material array.
    /// </summary>
    /// <returns>void</returns>
    private void SetBodyColor() {
        int num = Random.Range( 0, colors.Length - 1 );
        body.material = colors[ num ];
    }

    /// <summary>
    /// Display bouncing animation.
    /// </summary>
    /// <returns>void</returns>
    private void Bounce() {
        if ( animation != null ) {
            Utils.instance.TriggerAnimation( animation, "playerBouncing" );
        }
    }

    /// <summary>
    /// Look at the player gameObject.
    /// This method must be called in
    /// update to ensure the spectator
    /// is looking at the player at all
    /// times.
    /// </summary>
    /// <returns>void</returns>
    private void LookAtPlayer() {
        if ( player != null ) {
            transform.LookAt( player );
        }
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    /// <returns>void</returns>
    private void Init() {

        // get animation componet reference.
        animation = GetComponentInChildren<Animation>();

        // get a reference of player transform component to ensure spectator is all the time looking at the player.
        player = GameObject.FindGameObjectWithTag( "Player" ).GetComponent<Transform>();

        // get children renderer component.
        body = GetComponentInChildren<Renderer>(); 

        // set spectator body color.
        SetBodyColor();

        // display bouncing animation.
        // Bounce();
    }
}
