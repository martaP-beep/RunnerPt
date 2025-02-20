using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float worldScrollingSpeed = 0.2f;

    public Text scoreText;

    public bool inGame;

    public GameObject restartButton;

    public Text coinText;
    int coins;

    float score;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        InitializeGame();
    }

  
    void InitializeGame()
    {
        inGame = true;

        if (PlayerPrefs.HasKey("coins"))
        {
            coins = PlayerPrefs.GetInt("coins");
        }
        else
        {
            coins = 0;
        }
        coinText.text = coins.ToString();
    }

    public void GameOver()
    {
        inGame = false;
        restartButton.SetActive(true);
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    void FixedUpdate()
    {
        if (GameManager.instance.inGame == false) return;

        score += worldScrollingSpeed;
        scoreText.text = score.ToString("0");
    }

    public void CoinCollected()
    {
        coins += 1;
        coinText.text = coins.ToString();
        PlayerPrefs.SetInt("coins", coins);
    }
}
