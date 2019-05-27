using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text scoreText;                     // Score text component.
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    /// <summary>
    /// Update score.
    /// </summary>
    /// <param name="amount">int - how much the score is updated</param>
    public void UpdateScore( int amount ) {
        int currentScore = int.Parse( scoreText.text );
        currentScore += amount;

        scoreText.text = currentScore.ToString();
    }

    /// <summary>
    /// Initialise class method.
    /// </summary>
    private void Init() {
        scoreText = GetComponent<Text>();
    }
}
