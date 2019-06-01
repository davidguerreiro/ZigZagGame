﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{   
    [SerializeField]
    private float speed;                    // Ball's speed.
    bool started;                           // Wheter the game has started or not.
    bool gameOver;                          // Wheter the game enters in game over mode.
    public GameObject particle;             // Particle effect used when a diamond is collected by the user.

    Rigidbody rb;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        rb = GetComponent<Rigidbody>();    
    }

    // Start is called before the first frame update.
    void Start()
    {
    
    }

    // Update is called once per frame.
    void Update()
    {
        // Lisen for user input.
        InputConroller();

        // Check if the ball is in the platform.
        CheckPlatformDown();
    
    }

    /// <summary>
    /// Change ball direction.
    /// </summary>
    public void SwitchDirection() {
        if ( rb.velocity.z > 0 ) {
            rb.velocity = new Vector3( speed, 0, 0 );
        } else {
            rb.velocity = new Vector3( 0, 0, speed );
        }
    }

    /// <summary>
    /// User input controller
    /// </summary>
    private void InputConroller() {

        // Check wheter the user starts playing.
        if ( ! started ) {
            if ( Input.GetMouseButtonDown( 0 ) ) {
                Init();
                started = true;
            }
        }

        // Change ball direction when clicking.
        if ( Input.GetMouseButtonDown(0) && ! gameOver ) {
            SwitchDirection();
        }
    }

    /// <summary>
    /// Drop a ray down to check if the ball is 
    /// still over the platform.
    /// </summary>
    private void CheckPlatformDown() {
        if ( ! Physics.Raycast( transform.position, Vector3.down, 1f ) ) {
            gameOver = true;
            rb.velocity = new Vector3( 0, -25f, 0 );

            Camera.main.GetComponent<CameraFollow>().gameOver = true;

            GameManager.instance.PlayerDefeated();
        }
    }

    /// <summary>
    /// Initialise class method.
    /// </summary>
    private void Init() {
        rb.velocity = new Vector3( speed, 0, 0 );
        started = false;
        gameOver = false;

        // start game.
        // GameManager.instance.StartGame();
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if ( other.tag == "Diamond" ) {
            GameObject particles = Instantiate( particle, other.gameObject.transform.position, Quaternion.identity );
            UIManager.instance.UpdateScore( 1 );
            Destroy( other.gameObject );
            Destroy( particles, 1f );
        }
    }
}
