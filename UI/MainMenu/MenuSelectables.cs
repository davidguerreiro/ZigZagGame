using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MenuSelectables : MonoBehaviour, ISelectHandler , IPointerEnterHandler
{
    public GameObject cursor;                           // Selectable cursor.
    private MenuCursor cursorClass;                     // Selectable cursor class component.
    public bool onLoaded = false;                      // Flag to fix the issue of the cursor sound when initialise.          

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
        cursorClass.inAnimation = false;

        // update description title and description content based on option chosen.
        UpdateDesc();

        if ( onLoaded ) {
            cursorClass.ReproduceSelectableSound();
        }

        onLoaded = true;
    }

    /// <summary>
    /// Update title and description in
    /// the description panel based on the
    /// option chosen.
    /// </summary>
    private void UpdateDesc() {

        if ( gameObject.name == "Selectable1" ) {
            // MainMenuManager.instance.UpdateDescTitle( "Standard Mode" );
            MainMenuManager.instance.UpdateDescContent( "The Vertex is destroying the world. Would you be able to discover the mistery behind ? ( Available soon ! )" );
        }

        if ( gameObject.name == "Selectable2" ) {
            // MainMenuManager.instance.UpdateDescTitle( "Survival Mode" );
            MainMenuManager.instance.UpdateDescContent( " No limit ! Survive and get the best score possible !" );
        }
    }
}
