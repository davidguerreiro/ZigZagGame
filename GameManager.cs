using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameOver;

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
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Start game.
    /// </summary>
    public void StartGame() {
        UIManager.instance.GameStart();
        ScoreManager.instance.StartScore();
    }

    /// <summary>
    /// Game Over
    /// </summary>
    public void GameOver() {
        UIManager.instance.GameOver();
        ScoreManager.instance.StopScore();
    }
}
