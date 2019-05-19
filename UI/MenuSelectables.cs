using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MenuSelectables : MonoBehaviour
{
    public GameObject cursor;                           // Selectable Cursor.
    private MenuCursor cursorClass;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Initialise class.
    /// </summary>
    private void Init() {
        
        // get selectable cursor class.
        if ( cursor != null ) {
            cursorClass = cursor.GetComponent<MenuCursor>();
        }
    }

    /// <summary>
    /// Set this item selectable.
    /// </summary>
    private void SetItemSelectable() {
        GameObject[] cursors = GameObject.FindGameObjectsWithTag( "menu_cursor");
    }
}
