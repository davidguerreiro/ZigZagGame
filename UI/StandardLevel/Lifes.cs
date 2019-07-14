using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lifes : MonoBehaviour
{
    public int lifesLimit = 99;                         // Limit of lives the player can have in one single game.
    private Text lifesText;                             // Lifes Text compontent.

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    /// <summary>
    /// Update lifes.
    /// </summary>
    /// <param name="amount">int - amount to update</param>
    public void UpdateLifes( int amount ) {
        int currentLives = int.Parse( lifesText.text );
        currentLives += amount;

        if ( currentLives > lifesLimit ) {
            currentLives = lifesLimit;
        }

        lifesText.text = currentLives.ToString();
    }

    /// <summary>
    /// Init class method.
    /// </summary>
    private void Init() {
        lifesText = GetComponent<Text>();
    }
}
