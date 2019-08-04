using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{

    public static PlayerAnimations instance;                           // Static instance of this class.
    public string status = "standard";                                 // Current player status. Player status defines the state in which the player is. Different states trigger animations.
    private bool inAnimatio = false;                                   // Whether the player is in an async event for animation or not.
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine( StandardAnimation() );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Update player status.
    /// This will also trigger the animation associated
    /// with this new status, if there is any.
    /// </summary>
    /// <param name="newStatus">string - new status</param>
    public void UpdateStatus( string newStatus ) {
        status = newStatus;
    }

    /// <summary>
    /// Standard animation. The ball floates
    /// in the air and slides smoothly.false It also
    /// has normal eyes and an smile in the face.
    /// </summary>
    public IEnumerator StandardAnimation() {
        float speed = 10f;
        float movementAmplitude = 3f;
        float gradesAmplitude = 10f;

        string direction = "up";

        while ( status == "standard" ) {
            Quaternion q = transform.rotation;
            transform.Rotate( 1f, 0, 0 );
            yield return null;
        }
    }
}
