using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraLogic : MonoBehaviour {
    public LevelManager levelManager;                               // Main level manager class component reference.
    private Animation animation;                                    // Animation component reference.

    // Start is called before the first frame update
    void Start() {
        Init();
    }

    /// <summary>
    /// Display init scene animation.
    /// </summary>
    /// <returns>void</returns>
    public void DisplayInitSceneAnimation() {
        Utils.instance.TriggerAnimation( animation, "InitMainScene" );
    }

    /// <summary>
    /// Display UI elements.
    /// This method is called from
    /// InitMainScene animation as an event
    /// </summary>
    /// <returns>void</returns>
    public void EventDisplayUIElements() {
        StartCoroutine( levelManager.DisplayUIElements() );
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
