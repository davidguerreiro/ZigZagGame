using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramirillo : MonoBehaviour {
    public GameObject body;                                     // Body gameObject reference.
    public GameObject eyes;                                     // Eyes gameObject reference.
    public GameObject mouth;                                    // Mouth gameObject reference.
    public float rotateSpeed;                                   // Body rotate speed.

    // Start is called before the first frame update
    void Start() {
        
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    /// <returns>void</returns>
    void FixedUpdate() {
        RotateBody();
    }

    /// <summary>
    /// Rotate body.
    /// </summary>
    /// <returns>void</returns>
    private void RotateBody() {
        float rotationValue = ( this.rotateSpeed * Time.deltaTime ) * - 1f;
        body.transform.Rotate( rotationValue, 0f, 0f );
    }
}
