using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public Pileczka ball;
    bool gameRunning = false;

    LevelHolder levelHolder;
    int level = 1;

    private void Start()
    {
        levelHolder = GetComponent<LevelHolder>();
        levelHolder.SetLevel(level - 1);
    }

    private void Update()
    {
        if (!gameRunning)
        {
            //jeszcze gra nie wystartowa³a
            if(Input.GetKeyDown(KeyCode.Space))
            {
                gameRunning = true;
                ball.RunBall();
            }
        }
        else
        {
            if(levelHolder.IloscKlockow == 0)
            {
                gameRunning = false;
                ball.StopBall();
                ball.BallReady();

                level++;
                if(level > levelHolder.MaxLevel)
                {
                    //Wygrana
                    gameOverPanel.SetActive(true);
                    gameOverText.text = "You Win!";
                }
                else
                {
                    levelHolder.SetLevel(level - 1);
                }
            }
        }
    }

    public GameObject gameOverPanel;
    public Text gameOverText;
    public Text lifeText;
    int lives = 3;
    public void Dead()
    {
        gameRunning = false;
        lives--;
        if(lives > 0) 
        { 
            ball.BallReady();
        }
        else
        {
            //Game Over
            gameOverPanel.SetActive(true);
            gameOverText.text = "Game Over";
        }

        lifeText.text = "¯ycie: " + lives.ToString();
    }
}
