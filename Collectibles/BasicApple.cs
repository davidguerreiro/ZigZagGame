using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicApple : MonoBehaviour
{
    private Animation animation;                            // Animation component.

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
        // rotate collectible every frame.
        RotateCollectible();
    }

    /// <summary>
    /// Rotate collectible every frame.
    /// </summary>
    private void RotateCollectible() {
        transform.Rotate( new Vector3( 0, 3f, 0 ) );
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    private void Init() {

        // get animation component.
        animation = GetComponent<Animation>();
    }

    /// <summary>
    /// Method to run when the apple is collected.
    /// </summary>
    public void GetCollected() {

        // stop bouncing animation an trigger collected animation.
        animation.Stop();
        animation.clip = animation.GetClip( "apple-collected" );
        animation.Play();

        // TODO: Add sound.

        // score is duplicated if in boost mode.
        int scoreToAdd = ( BallController.instance.inBoost ) ? 2 : 1;
        UIManager.instance.UpdateScore( scoreToAdd );

        // add text to the legend.
        string legendText = ( BallController.instance.inBoost ) ? "points" : "point";
        Legend.instance.AddText( "+" + scoreToAdd + " " + legendText );

        Destroy( this.gameObject, 1f );
    }
}
