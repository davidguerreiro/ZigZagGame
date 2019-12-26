using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleWrapper : MonoBehaviour {

    public Letteritem[] letterItems = new Letteritem[8];        // Letter items array - used to display game over animation.
    private bool completed;                                     // Flag to control whether the title display animation has been completed.

    // Start is called before the first frame update
    void Start() {
        Init();
    }

    /// <summary>
    /// Get animation completed
    /// status.
    /// </summary>
    /// <returns>void</returns>
    public bool IsCompleted() {
        return this.completed;
    }

    /// <summary>
    /// Display game over title
    /// animation.
    /// </summary>
    /// <returns>IEnumerator</returns>
    public IEnumerator DisplayTitleAnimation() {
        float gap = .1f;

        foreach ( Letteritem item in letterItems ) {
            item.Display();
            yield return new WaitForSeconds( gap );
        }

        this.completed = true;
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    /// <returns>void</returns>
    private void Init() {

        // set attributes default values.
        this.completed = false;
    }

}
