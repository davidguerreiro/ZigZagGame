﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{   
    public float standingTime = 0.5f;             // Time the platforms stands before failling down.
    private Rigidbody rigibody;                 // Rigibody component.
    

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    /// </summary>
    /// <param name="col">The other Collider involved in this collision.</param>
    void OnTriggerExit( Collider col )
    {
        if ( col.gameObject.tag == "Ball" ) {
            Invoke( "FallDown", standingTime );
        }
    }

    /// <summary>
    /// Make the platform fall down.
    /// </summary>
    private void FallDown() {
        rigibody.useGravity = true;
        rigibody.isKinematic = false;

        Destroy( transform.parent.gameObject, 2f );
    }

    /// <summary>
    /// Initialise trigger checker class.
    /// </summary>
    private void Init() {
        rigibody = GetComponentInParent<Rigidbody>();
    }
}
