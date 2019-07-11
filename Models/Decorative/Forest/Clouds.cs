using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    public float speed = 5f;                        // Clouds speed movement.
    public bool direction = true;                   // If true, the move to the right, otherwise the movement happens on the left
    public float secondsToChange = 10f;             // Seconds that the clouds are moving in the same direction.
    private bool inAwaiting = false;                // Whether the script is waiting for changing direction.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move clouds.
        MoveClouds();

        if ( ! inAwaiting ) {
            // call coroutine here.
            StartCoroutine( ChangeDirection() );
        }
    }

    /// <summary>
    /// Move clouds.
    /// </summary>
    private void MoveClouds() {
        if ( direction ) {
            transform.position = new Vector3( transform.position.x, transform.position.y, transform.position.z + ( speed * Time.deltaTime )  ); 
        } else {
            transform.position = new Vector3( transform.position.x, transform.position.y, transform.position.z - ( speed * Time.deltaTime ) );
        }
    }

    /// <summary>
    /// Change clouds movement direction.
    /// </summary>
    private IEnumerator ChangeDirection() {
        inAwaiting = true;

        yield return new WaitForSeconds( secondsToChange );
        direction = ! direction;

        inAwaiting = false;
    }
}
