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

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("coins"))
        {
            coins = PlayerPrefs.GetInt("coins");
        }
        coinsText.text = "Coins: " + coins;
    }

   public void PlayButton()
    {
        Debug.Log("Klik");
        SceneManager.LoadScene("Game");
    }
    public void SoundButton()
    {

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
