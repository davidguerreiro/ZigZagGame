using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    public bool animated = true;                                // Wheter the grass is animated.
    public bool frontDirection = true;                          // Initial rotation direction.
    private float amplitude = 3f;                               // Rotation movement amplitude.
    private float speed = 0.8f;                                   // Animation speed.
    private float max;                                          // Rotation max value.                  
    private float min;                                          // Rotation min value.

    // Start is called before the first frame update
    void Start()
    {
        if ( animated ) {
            Init();
            StartCoroutine( RotateGrass() );
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Rotate grass to give wind effect.
    /// </summary>
    private IEnumerator RotateGrass() {
        float grades;
        Quaternion q = transform.rotation;
        
        while ( animated ) {
            grades = ( frontDirection ) ? 1 : - 1;

            transform.Rotate( grades, 0, 0 );

            // check if rotation direction needs to change.
            if ( transform.rotation.x > 0.001f ) {
                frontDirection = false;
            } else if ( transform.rotation.x < - 0.001f ) {
                frontDirection = true;
            }

            yield return new WaitForSeconds( 0.3f );
            yield return null;
            
        }
        
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    private void Init() {
        /// calculate max and min for rotation.
        max = transform.rotation.eulerAngles.x + amplitude;
        min = transform.rotation.x - amplitude;
    }
}
