using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccumulatingSpeedBoostParticles : MonoBehaviour
{
    private float speed = 100f;                             // Particle gameObject rotation speed.
    
    /// this method is called when the gameObject is enabled.
    void OnEnable() {
        StartCoroutine( BoostParticlesSpeed() );
    }

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable() {
        StopAllCoroutines();
    }
    

    /// <summary>
    /// Rotates particle effect.
    /// </summary>
    private IEnumerator BoostParticlesSpeed() {
        while ( true ) {
            transform.Rotate( new Vector2( transform.rotation.x, transform.rotation.y + ( speed * Time.deltaTime ) ) );
            yield return null;
        }
    }
}
