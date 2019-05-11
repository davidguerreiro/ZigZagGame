using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationRectangle : MonoBehaviour
{
    public float speed = 1f;               // Constant movement speed.
    public bool constantMovement = false;   // Flag to set wheter the rectangle can be in constant movement.
    public string direction = "right";      // Direction to move the rectangle.

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ( constantMovement ) {
            MoveRectangle( direction );
        }
    }

    /// <summary>
    /// Moves the rectangle in the
    /// X axis.
    /// </summary>
    /// <param name="direction">string - Wheter the rectangles moves to left or right.</param>
    private void MoveRectangle( string direction ) {
        if ( direction == "right" ) {
            transform.localPosition = new Vector2( transform.localPosition.x + ( speed * Time.deltaTime ), transform.localPosition.y );
        } else {
            transform.localPosition = new Vector2( transform.localPosition.x - ( speed * Time.deltaTime ), transform.localPosition.y );
        }
    }
}
