using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MenuSelectables : MonoBehaviour, ISelectHandler , IPointerEnterHandler
{
    public GameObject cursor;                           // Selectable cursor.
    private MenuCursor cursorClass;                     // Selectable cursor class component.

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    /// <summary>
    /// Display cursor when item is highlight with the mouse.
    /// </summary>
    public void OnPointerEnter( PointerEventData eventData ) {
        SetItemSelectable();
    }

    /// <summary>
    /// Display cursor when item is selected by keyboard controls.
    /// </summary>
    public void OnSelect( BaseEventData eventData ) {
        SetItemSelectable();
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

        // disable all menu cursors.
        GameObject[] cursors = GameObject.FindGameObjectsWithTag( "menu_cursor");

        foreach( GameObject localCursor in cursors ) {
            localCursor.SetActive( false );
        }

        // active current selectable cursor.
        cursor.SetActive( true );
        cursorClass.ReproduceSelectableSound();
    }
}
