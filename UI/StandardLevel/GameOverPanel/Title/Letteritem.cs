using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letteritem : MonoBehaviour {

    private Animation animation;                        // Animation component reference.

    // Start is called before the first frame update
    void Start() {
        Init();
    }

    /// <summary>
    /// Display letter item.
    /// </summary>
    /// <returns>void</returns>
    public void Display() {
        Utils.instance.TriggerAnimation( animation, "Display" );
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
