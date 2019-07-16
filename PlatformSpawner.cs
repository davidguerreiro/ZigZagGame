using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;                     // Platforms gameObject.
    public GameObject basicApple;                   // Basic apple collectible.
    Vector3 lastPos;
    float size;
    bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        Init();
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnPlatforms() {
        int rand = Random.Range( 0, 6 );

        if ( rand < 3 ) {
            SpawnX();
        } else {
            SpawnZ();
        }
    }

    /// <summary>
    /// Spawn a platform in the X axis.
    /// </summary>
    private void SpawnX() {
        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = pos;
        Instantiate( platform, pos, Quaternion.identity );

        // instantiate basic apple.
        SpawnBasicApple( pos );
    }

    /// <summary>
    /// Spawn a basic apple collectible.
    /// </summary>
    /// <param name="pos">vector3 - current instantiate platform position to instantiate the basic apple</param>
    private void SpawnBasicApple( Vector3 pos ) {
        int rand = Random.Range( 0, 4 );

        if ( rand < 1 ) {
            Instantiate( basicApple, new Vector3( pos.x, pos.y + 1, pos.z ), basicApple.transform.rotation );
        }
    }

    /// <summary>
    /// Spawn a platform in the Z axis.
    /// </summary>
    private void SpawnZ() {
        Vector3 pos = lastPos;
        pos.z += size;
        lastPos = pos;
        Instantiate( platform, pos, Quaternion.identity );

        // instantiate diamond
        SpawnBasicApple( pos );
    }

    /// <summary>
    /// Initialise the class
    /// </summary>
    private void Init() {
        lastPos = platform.transform.position;
        size = platform.transform.localScale.x;
        gameOver = false;

        // spawn platforms.
        for ( int i = 0; i < 20; i++ ) {
            SpawnPlatforms();
        }

        InvokeRepeating( "SpawnPlatforms", 2f, 0.2f );
        
    }

    /// <summary>
    /// Check if spawn platforms
    /// has to be stopped
    /// </summary>
    private void CheckForGameOver() {
        if ( gameOver ) {
            CancelInvoke( "SpawnPlatforms" );
        }
    }
}
