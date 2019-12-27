using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainButton : MonoBehaviour {

    /// <summary>
    /// Restart level.
    /// This method is called
    /// when clicking the 
    /// button.
    /// </summary>
    /// <returns>void</returns>
    public void ResetLevel() {
        if ( GetComponent<AnimationComponent>().IsDisplayed() ) {
            SceneManager.LoadScene( SceneManager.GetActiveScene().name );
        }
    }

}
