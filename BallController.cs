using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{   
    public static BallController instance;                  // Class instance to be used by other components.

    [SerializeField]
    private float speed;                                    // Ball's speed.
    bool started;                                           // Wheter the game has started or not.
    bool gameOver;                                          // Wheter the game enters in game over mode.
    public GameObject particle;                             // Particle effect used when a diamond is collected by the user.
    public bool accumulating = false;                       // Wheter the ball is acummulating speed to be released.
    public bool inBoost = false;                            // Wheter the ball is in boost mode. During boost mode score you get by taking collectibles is multiplied by 2.
    public bool canBoost = false;                           // Wheter the player can use the boost.
    public string orientation = "front";                    // Which direction the ball is moving / facing.

    [SerializeField]
    private float accumulator = 0f;                         // Speed accumulated by the player to release in the boost mechanic.

    private float minSpeed = 0f;                            // Base movement speed.
    private float maxSpeed = 11f;                           // Max speed the player can get by boost.
    private float maxAccumulator = 6f;                      // Max seconds the player can stay in boost mode.
    private float boostAcummulationSpeed = 0.08f;           // Reduced speed animation time.
    

    Rigidbody rb;                           // Rigibody component.

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake() {
        if ( instance == null ) {
            instance = this;
        }

        // get rigibody component.
        rb = GetComponentInChildren<Rigidbody>();    
    }

    // Start is called before the first frame update.
    void Start()
    {
        InitClass();
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    private void InitClass() {

        // set min speed as player base speed.
        minSpeed = speed;
    }

    // Update is called once per frame.
    void Update()
    {
        // Lisen for user input.
        InputConroller();

        // Check if the ball is in the platform.
        CheckPlatformDown();

        // check if player can boost the speed and init boost if so.
        CheckInputForBoostMechanic();
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate() {
    }

    /// <summary>
    /// Check user input for boost
    /// mechanic
    /// </summary>
    private void CheckInputForBoostMechanic() {
        // check if player can boost the speed and init boost if so.
        if ( Input.GetMouseButton( 1 ) && ! accumulating && canBoost ) {
            accumulating = true;
            StartCoroutine( ReduceSpeed() );
            StartCoroutine( AccumulateTime() );
        }

        // check if the player stops accumulating speed so the boost is released.
        if ( Input.GetMouseButtonUp( 1 ) && accumulating && ! inBoost ) {
            accumulating = false;
            StartCoroutine( ReleaseBost() );
        }
    }

    /// <summary>
    /// Change ball direction.
    /// </summary>
    public void SwitchDirection() {
        if ( rb.velocity.z > 0 ) {
            rb.velocity = new Vector3( speed, 0, 0 );
            orientation = "right";
        } else {
            rb.velocity = new Vector3( 0, 0, speed );
            orientation = "front";
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
        if ( Input.GetMouseButtonDown(0) && ! gameOver && ! accumulating ) {
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
        canBoost = true;

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

            // score is duplicated if in boost mode.
            int scoreToAdd = ( BallController.instance.inBoost ) ? 2 : 1;
            UIManager.instance.UpdateScore( scoreToAdd );

            // add text to the legend.
            string legendText = ( BallController.instance.inBoost ) ? "points" :  "point";
            Legend.instance.AddText( "+" + scoreToAdd + " " + legendText );

            Destroy( other.gameObject );
            Destroy( particles, 1f );
        }
    }

    /// <summary>
    /// Bost mechanic. The player accumulates
    /// speed whilist the secondary button in
    /// the mouse is hold clicked. Until the button
    /// is released, the player will reduced the
    /// speed, but that speed will be accumulated
    /// and the more the player accumulates, the longer
    /// the boost will be. Player speed boost will be max
    /// speed and then after the boost time is done the speed
    /// will be gradually recovered.
    /// </summary>
    private IEnumerator ReduceSpeed() {
        canBoost = false;
        
        // reduce speed and accumulate as long as the player holds the right button in the mouse.
        while ( accumulating ) {

            if ( speed > 0f ) {
                speed--;
            }

            UpdateSpeed();
            yield return new WaitForSeconds( boostAcummulationSpeed );
        }

        speed = maxSpeed;
        UpdateSpeed();
    }

    /// <summary>
    /// Acummulates boost time.
    /// </summary>
    private IEnumerator AccumulateTime() {
        while ( accumulating ) {

            if ( accumulator < maxAccumulator ) {
                accumulator++;
            }

            yield return new WaitForSeconds( 0.5f );
        }
    }

    /// <summary>
    /// Release accumulated speed during
    /// the boost phase. Reduce speed after the boost is
    /// completed.
    /// </summary>
    private IEnumerator ReleaseBost() {
        float toWait = accumulator;
        float reducer = 2.5f;
        
        inBoost = true;
        
        // reset accumulator for future boosts.
        accumulator = 0;
    
        // stay in boost as much seconds as accumulated by the player.
        yield return new WaitForSeconds( toWait / reducer );

        while ( speed > minSpeed ) {
            speed--;
            UpdateSpeed();
            yield return new WaitForSeconds( boostAcummulationSpeed );
        }

        canBoost = true;
        inBoost = false;
    }

    /// <summary>
    /// Update player speed
    /// based in player direction
    /// and boost.
    /// </summary>
    private void UpdateSpeed() {
        if ( orientation == "front" ) {
            rb.velocity = new Vector3( 0, 0, speed );
        } else {
            rb.velocity = new Vector3( speed, 0, 0 );
        }
    }

}
