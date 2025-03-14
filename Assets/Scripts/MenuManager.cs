using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject storePanel;

    public Text coinsText;
    int coins = 0;

    public Powerup magnet;
    public Powerup immortality;

    public Text magnetLevel;
    public Text magnetButton;

    public Text immortalityLevel;
    public Text immortalityButton;

    public Text soundText;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("coins"))
        {
            coins = PlayerPrefs.GetInt("coins");
        }
        coinsText.text = "Coins: " + coins;

        immortalityLevel.text = immortality.ToString();
        immortalityButton.text = immortality.UpgradeCostString();

        magnetLevel.text = magnet.ToString();
        magnetButton.text = magnet.UpgradeCostString();
    }

   public void PlayButton()
    {
        Debug.Log("Klik");
        SceneManager.LoadScene("Game");
    }
    public void SoundButton()
    {
        SoundManager.instance.ToggleMuted();

        if (SoundManager.instance.GetMuted())
        {
            soundText.text = "Turn on sound";
        }
        else
        {
            soundText.text = "Turn off sound";
        }

    }


    void UpgradePowerup(Powerup powerup)
    {
        if(coins >= powerup.GetNextUpgradeCost()
            && powerup.IsMaxedOut() == false)
        {
            powerup.Upgrade();
            coins -= powerup.GetNextUpgradeCost();
            PlayerPrefs.SetInt("coins", coins);

            immortalityLevel.text = immortality.ToString();
            immortalityButton.text = immortality.UpgradeCostString();

            magnetLevel.text = magnet.ToString();
            magnetButton.text = magnet.UpgradeCostString();
        }
    }

    public void UpgradeMagnet()
    {
        UpgradePowerup(magnet);
    }

    public void UpgradeImmortality()
    {
        UpgradePowerup(immortality);
    }

    public void OpenStore()
    {
        storePanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void CloseStore()
    {
        storePanel.SetActive(false);
        menuPanel.SetActive(true);
    }

}
