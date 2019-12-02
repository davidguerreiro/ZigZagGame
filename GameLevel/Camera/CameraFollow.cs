using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public GameObject ball;                             // GameObject to follow.
    private Vector3 offset;                             // Difference between the ball and the camera.
    public float lerpRate;                              // Movement speed.
    public bool gameOver;                               // GameOver flag.`

    // Start is called before the first frame update
    void Start() {
        Init();
    }

    // Update is called once per frame
    void Update() {
        if ( BallController.instance.PlayerHasStarted() && ! gameOver ) {
            Follow();
        }
    }

    /// <summary>
    /// Initialise method.
    /// </summary>
    /// <returns>void</returns>
    private void Init() {
        offset = ball.transform.position - transform.position;
        gameOver = false;
    }

    /// <summary>
    /// Update camera position with
    /// player movement.
    /// </summary>
    /// <returns>void</returns>
    private void Follow() {
        Vector3 pos = transform.position;
        Vector3 targetPos = ball.transform.position - offset;
        pos = Vector3.Lerp( pos, targetPos, lerpRate * Time.deltaTime );
        transform.position = pos;
    }
}
