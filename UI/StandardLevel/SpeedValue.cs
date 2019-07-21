using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedValue : MonoBehaviour
{
    public static SpeedValue instance;                                  // Static instance of this class to be called from other scripts.
    private Text content;                                               // Text component.
    // Start is called before the first frame update
    void Start() {
        Init();
    }

    /// <summary>
    /// Update speed value in the
    /// UI element.
    /// </summary>
    public void UpdateUISpeed( float speed ) {
        content.text = speed.ToString();
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    private void Init() {

        // get text component.
        content = GetComponent<Text>();
    }
}
