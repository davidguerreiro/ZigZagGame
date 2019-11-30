﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {
    public GameObject platform;                     // Platforms gameObject.
    public GameObject basicApple;                   // Basic apple collectible.
    public GameObject goldenApple;                  // Golden apple collectible.
    public GameObject chiliApple;                   // Chili apple collectible.
    public Material alternative;                    // Alternative material to use on the spawned platform when it has an item.
    public bool hasItem = false;                    // Checks if the platform has already spawned an item.

    private Vector3 lastPos;
    private float size;
    private bool gameOver;
    private GameObject platformReference;           // Reference to the last instantiate platform.

    // random items rations.
    private int basicAppleRatio = 4;                // Maximun ratio for spawning basic apples.
    private int goldenAppleRatio = 56;              // Maximun ratio for spawning golden apples.
    private int chiliAppleRatio = 75;               // Maximun ratio for spawning chili apples.

    // Start is called before the first frame update
    void Start() {
        Init();
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
        platformReference = Instantiate( platform, pos, Quaternion.identity );

        // instantiate basic apple.
        SpawnBasicApple( pos );

        // instantiate golden apple if possible.
        if ( ! hasItem ) {
            SpawnGoldenApple( pos );
        }

        // instantiate chili apple if possible.
        if ( ! hasItem ) {
            SpawnChiliApple( pos );
        }

        // if the platform has item, set material as alternative.
        if ( hasItem ) {
            platformReference.GetComponent<Renderer>().material = alternative;
        }
    }

    /// <summary>
    /// Spawn a basic apple collectible.
    /// </summary>
    /// <param name="pos">vector3 - current instantiate platform position to instantiate the basic apple</param>
    private void SpawnBasicApple( Vector3 pos ) {
        int rand = Random.Range( 0, basicAppleRatio );

        if ( rand < 1 ) {
            Instantiate( basicApple, new Vector3( pos.x, pos.y + 1, pos.z ), basicApple.transform.rotation );
            hasItem = true;
        } else {
            hasItem = false;
        }
    }

    /// <summary>
    /// Spawn a golden apple collectible.
    /// </summary>
    /// <param name="pos">vector3 - current instantiate platform position to instantiate the golden apple</param>
    private void SpawnGoldenApple( Vector3 pos ) {
        int rand = Random.Range( 0, goldenAppleRatio );

        if ( rand < 1 ) {
            Instantiate( goldenApple, new Vector3( pos.x, pos.y + 1, pos.z ), goldenApple.transform.rotation );
            hasItem = true;
        } else {
            hasItem = false;
        }
    }

    /// <summary>
    /// Spawn a chili appple collectible.
    /// </summary>
    /// <param name="pos">Vector3 - current instantiate platform position to instantiate the chili apple</param>
    private void SpawnChiliApple( Vector3 pos ) {
        int rand = Random.Range( 0, chiliAppleRatio );

        if ( rand < 1 ) {
            Instantiate( chiliApple, new Vector3( pos.x, pos.y + 1, pos.z ), chiliApple.transform.rotation );
            hasItem = true;
        } else {
            hasItem = false;
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

        // instantiate normal apple.
        SpawnBasicApple( pos );

        // instantiate a golden apple if no item has been instantiated.
        if ( ! hasItem ) {
            SpawnGoldenApple( pos );
        }

        // instantiate chili apple if possible.
        if ( ! hasItem ) {
            SpawnChiliApple( pos );
        }
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