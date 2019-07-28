using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{   
    public static BallController instance;                  // Class instance to be used by other components.

    [SerializeField]
    private float speed;                                    // Current Ball's speed.
    [SerializeField]
    private float baseSpeed = 7f;                           // Base speed used to move the character.
    bool started;                                           // Wheter the game has started or not.
    bool gameOver;                                          // Wheter the game enters in game over mode.
    public GameObject particle;                             // Particle effect used when a diamond is collected by the user.
    public bool accumulating = false;                       // Wheter the ball is acummulating speed to be released.
    public bool inBoost = false;                            // Wheter the ball is in boost mode. During boost mode score you get by taking collectibles is multiplied by 2.
    public bool canBoost = false;                           // Wheter the player can use the boost.
    public string orientation = "front";                    // Which direction the ball is moving / facing.
    public AudioClip[] soundEffects;                        // Sound effects coming from the player.
    public string additionalState = "none";                 // Any additional state is saved in this string. No two additional states can be hold at the same time.

    [SerializeField]
    private float accumulator = 0f;                         // Speed accumulated by the player to release in the boost mechanic.

    private float minSpeed = 0f;                            // Base movement speed.
    private float maxSpeed = 11f;                           // Max speed the player can get by boost.
    private float maxAccumulator = 6f;                      // Max seconds the player can stay in boost mode.
    private float boostAcummulationSpeed = 0.08f;           // Reduced speed animation time.
    private PlayerModel playerModel;                        // Player 3D model logic class component.
    private AudioSource audioSource;                        // AudioSource component.
    
    

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
    void Start() {
        InitClass();
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    private void InitClass() {

        // set min speed as player base speed.
        minSpeed = baseSpeed;

        // get audio component.
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame.
    void Update() {
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
        // set switch quick direction speed sound and play it only if in boost mode.
        SetSoundClip( 2 );

        if ( inBoost ) {
            PlaySound();
        }

        if ( rb.velocity.z > 0 ) {
            rb.velocity = new Vector3( speed, 0, 0 );
            orientation = "right";

            // rotate the player to the right.
            StartCoroutine( playerModel.TurnRight() );
        } else {
            rb.velocity = new Vector3( 0, 0, speed );
            orientation = "front";

            // rotate player to the right.
            StartCoroutine( playerModel.TurnLeft() );
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

            // stop camera.
            Camera.main.GetComponent<CameraFollow>().gameOver = true;

            // stop timer.
            Timer.instance.StopTimer();

            // run gameOver logic in the game manager.
            GameManager.instance.PlayerDefeated();
        }
    }

    /// <summary>
    /// Initialise class method.
    /// </summary>
    private void Init() {
        rb.velocity = new Vector3( baseSpeed, 0, 0 );
        started = false;
        gameOver = false;
        canBoost = true;

        // get 3D model logic class component for animations.
        playerModel = GetComponentInChildren<PlayerModel>();

        // stop bouncing animation - to replace in the future for fast movement bouncing.
        playerModel.StopBouncing();

        // start timer.
        Timer.instance.RunTime();

        // start playing level music.
        LevelLoaderMusic.instance.PlayLevelMusic();


        // start game.
        // GameManager.instance.StartGame();
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other) {  

        // collect basic apple.
        if ( other.tag == "basicApple" ) {
            other.gameObject.GetComponentInChildren<BasicApple>().GetCollected();
        }

        // collect golden apple.
        if ( other.tag == "goldenApple" ) {
            other.gameObject.GetComponentInChildren<GoldenApple>().GetCollected();
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
        float uiSpeed = 0f;
        canBoost = false;

        // display accumulate energy animation.
        playerModel.AccumulateSpeedAnimation();

        // set accumulate energy soundclip.
        SetSoundClip( 0 );
        PlaySound();

        // reduce speed and accumulate as long as the player holds the right button in the mouse.
        while ( accumulating ) {

            if ( speed > 0f ) {
                speed--;
                
                // Update UI speed value.
                SpeedValue.instance.TriggerUISpeedAction( "maxReducer" );
            }

            UpdateSpeed();
            yield return new WaitForSeconds( boostAcummulationSpeed );
            
        }

        // StopSound();
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

        // set release energy sound clip and play it.
        SetSoundClip( 2 );
        PlaySound();

        // display release bost animation.
        playerModel.ReleaseSpeedAnimation();

        // update UI speed to max speed after any other speed animation is removed.
        SpeedValue.instance.CheckRunningCoroutines();
        SpeedValue.instance.UpdateUISpeed( SpeedValue.instance.maxUISpeed, true );
        
        inBoost = true;
        
        // reset accumulator for future boosts.
        accumulator = 0;
    
        // stay in boost as much seconds as accumulated by the player.
        yield return new WaitForSeconds( toWait / reducer );

        // reduce maxSped to baseSpeed in the UI.
        SpeedValue.instance.TriggerUISpeedAction( "normalReducer" );
        while ( speed > minSpeed ) {
            speed--;
            UpdateSpeed();

            // trigger UI speed reduce speed animation.
            yield return new WaitForSeconds( boostAcummulationSpeed );
        }

        // display get back to base speed animation.
        playerModel.SetSpeedToBaseSpeedAnimation();

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

    /// <summary>
    /// Update player sound.
    /// Set sound effect in the Audio
    /// source component.
    /// </summary>
    /// <param name="clipKey">int - clip key in sfx array</param>
    private void SetSoundClip( int clipKey ) {
        audioSource.clip = soundEffects[ clipKey ];
    }

    /// <summary>
    /// Play player sound.
    /// </summary>
    private void PlaySound() {
        audioSource.Play();
    }

    /// <summary>
    /// Stop playing sound.
    /// </summary>
    private void StopSound() {
        if ( audioSource.isPlaying ) {
            audioSource.Stop();
        }
    }

    /// <summary>
    /// Update player additional
    /// state.
    /// </summary>
    /// <param name="newState">string - player new state</param>
    public void UpdateAdditionalState( string newState ) {
        this.additionalState = newState;
    }

    /// <summary>
    /// Set golden state.
    /// </summary>
    /// <param name="duration">float - golde state duration. Value coming from the collectible class.</param>
    public void SetGoldenState( float duration ) {
        StartCoroutine( playerModel.TriggerGoldenStateAnimation( duration ) );
    } 
    

}
