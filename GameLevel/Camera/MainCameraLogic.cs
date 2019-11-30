using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraLogic : MonoBehaviour {
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
    /// Init class method.
    /// </summary>
    /// <returns>void</returns>
    private void Init() {

        // get animation component.
        animation = GetComponent<Animation>();
    }
}
