using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerSc : MonoBehaviour
{
    public int Money = 60;
    public static int Health = 20;

    private float GameSpeed = 1;

    public Text MoneyText;
    public Text Healthtext;

    public Sprite Speed1S;
    public Sprite Speed2S;

    public GameObject MainMenueGO;
    public GameObject SpeedUpButtonGO;

    public bool IsGamePaused;
    public bool IsGameSpedUp;

    private Image Image;

    void Start()
    {
        IsGamePaused = false;
        IsGameSpedUp = false;
        Time.timeScale = 1;
        MainMenueGO.active = false;
        Image = SpeedUpButtonGO.GetComponent<Image>();
    }
    void Update()
    {
        MoneyText.text = Money.ToString();
        Healthtext.text = Health.ToString();
    }

    public void PuaseGameB()
    {
        Time.timeScale = 0;
        IsGamePaused = true;
        MainMenueGO.active = true;
    }

    public void PuaseMenuClose()
    {
        Time.timeScale = GameSpeed;
        IsGamePaused = false;
        MainMenueGO.active = false;
    }

    public void SppedGameUp()
    {
        if(IsGameSpedUp == true)
        {
            IsGameSpedUp = false;
            Time.timeScale = 1f;
            Image.sprite =Speed1S;
            GameSpeed = Time.timeScale;
            Debug.Log("No");
        }
        else
        {
            IsGameSpedUp = true;
            Time.timeScale = 2f;
            Image.sprite = Speed2S;
            GameSpeed = Time.timeScale;
            Debug.Log("Yes");
        }
    }
}
