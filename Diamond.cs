using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{

    public float rotationSpeed = 3.5f;                      // Rotation speed.
    
    // Update is called once per frame
    void Update()
    {
        RotateDiamond();
    }

    /// <summary>
    /// Rotate diamond.
    /// </summary>
    private void RotateDiamond() {
        transform.Rotate( 0, rotationSpeed, 0 );
    }
}
