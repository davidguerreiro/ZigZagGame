using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text hours;                      // Hours for the timer text component.
    public Text minutes;                    // Minutes for the timer text component.
    public Text seconds;                    // Seconds for the timer text component.
    public Text miliseconds;                // Miliseconds fot the timer text component.
    public bool enabled = false;            // Wheter the timer is enabled or stoped.
    private IEnumerator timer;              // Asychonus method for adding units to the timer. 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( enabled ) {
            RunTimer();
        }
    }

    /// <summary>
    /// Sum +1 to timer counter.
    /// </summary>
    /// <param name="component">Text - text component for unit to add</param>
    private void UpdateComponent( Text component, float value ) {
        string sValue = ( value <= 9f ) ? "0" + value.ToString() : value.ToString();
        component.text = sValue;
    }

    /// <summary>
    /// Sum +1 to timer counter.
    /// </summary>
    /// <param name="component">Text - text component for unit to add</param>
    private void UpdateComponent( Text component, int value ) {
        string sValue = ( value <= 9 ) ?  "0" + value.ToString() : value.ToString();
        component.text = sValue;
    }

    /// <summary>
    /// Counter manager - add +1 if 
    /// component is enbled.
    /// </summary>
    private void RunTimer() {
        float currentMiliseconds = float.Parse( miliseconds.text );
        float currentSeconds = float.Parse(seconds.text );
        float currentMinutes = float.Parse( minutes.text );
        float currentHours = float.Parse( hours.text );

        currentMiliseconds += Mathf.Round( ( Time.deltaTime * 1000f ) / 10f );
        miliseconds.text = currentMiliseconds.ToString();

        // update seconds.
        if ( currentMiliseconds >= 100 ) {
            UpdateComponent( miliseconds, 0f );
            UpdateComponent( seconds, currentSeconds + 1 );
        }

        // update minutes.
        if ( currentSeconds >= 60 ) {
            UpdateComponent( seconds, 0 );
            UpdateComponent( minutes, currentMinutes + 1 );
        }

        // update hours.
        if ( currentMinutes >= 60 ) {
            UpdateComponent( minutes, 0 );
            UpdateComponent( hours, currentHours + 1 );
        }
    }
}
