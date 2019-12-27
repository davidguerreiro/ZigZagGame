using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeWrapper : MonoBehaviour {
    public TextComponent hours;                         // Hours text class component reference.
    public TextComponent minutes;                       // Minutes text class component reference.
    public TextComponent seconds;                       // Seconds text class component reference.

    /// <summary>
    /// Update time values.
    /// </summary>
    /// <param name="newHours">string - new hours value</param>
    /// <param name="newMinutes">string - new minutes value</param>
    /// <param name="newSeconds">string - new seconds value</param>
    /// <returns>void</returns>
    public void UpdateTimeValues( string newHours, string newMinutes, string newSeconds ) {
        hours.UpdateContent( newHours );
        minutes.UpdateContent( newMinutes );
        seconds.UpdateContent( newSeconds );
    }
}
