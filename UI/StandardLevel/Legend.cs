using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legend : MonoBehaviour
{
    public static Legend instance;                      // Class instance to access this class component from other scripts.
    public GameObject textModel;                        // Text model to instantiate.

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        if ( instance ==  null ) {
            instance = this;
        }
    }

    /// <summary>
    /// Display a new text
    /// in the legend.
    /// </summary>
    /// <param name="text">string - text to display</param>
    /// <param name="type">string - optional - text type. Type defines the text layout</param>
    public void AddText( string text, string type = "standard" ) {

        // instantiate text on children position.
        GameObject addedText = Instantiate( textModel, transform.position, transform.rotation, this.transform );

        // update text values.
        LegendText textClass = addedText.GetComponent<LegendText>();
        textClass.UpdateText( text );
        textClass.type = type;
    }

}
