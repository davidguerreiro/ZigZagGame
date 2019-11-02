using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTitle : MonoBehaviour {
    private Animation animation;                                        // Animation component reference.

    // Start is called before the first frame update
    void Start() {
        Init();
    }

    /// <summary>
    /// Display title animation.
    /// </summary>
    /// <returns>void</returns>
    public void DisplayTitle() {
        Debug.Log( "display called" );
        Utils.instance.TriggerAnimation( animation, "DisplayGameTitle" );
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    /// <returns>void</returns>
    private void Init() {

        // get animation component reference.
        animation = GetComponent<Animation>();
    }
}
