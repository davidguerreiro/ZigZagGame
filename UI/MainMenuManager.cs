using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager instance;                    // Create public instance for this manager to be called from other scripts.
    public Text descriptionTitle;                 // Game mode description title.
    public Text description;                      // Game mode description.

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        if ( instance == null ) {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Update description title.
    /// </summary>
    /// <param name="text">string - text to update</param>
    public void UpdateDescTitle( string text ) {
        if ( descriptionTitle != null ) {
            descriptionTitle.text = text;
        }
    }

    /// <summary>
    /// Update description content. 
    /// </summary>
    /// <param name="text">string - text to update</param>
    public void UpdateDescContent( string text ) {
        if ( description != null ) {
            description.text = text;
        }
    }
}
