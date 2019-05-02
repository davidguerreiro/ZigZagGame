using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{

    Rigidbody rigibody;                 // Rigibody component.s

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
            Invoke( "FallDown", 0.5f );
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
