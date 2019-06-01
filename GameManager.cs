using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;         // Instance to make the gameManager accessible from other scripts.
    public int currentLevel = 1;                // Current level the player is playing.
    public int lifes = 3;                       // Current lifes the played has.

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        if ( instance == null ) {
            instance = this;
        }
    }

    /// <summary>
    /// Player is defeated.
    /// </summary>
    public void PlayerDefeated() {
        if ( lifes > 0 ) {
            UIManager.instance.DisplayDefeatedPanel();
        }
    }
    
}
