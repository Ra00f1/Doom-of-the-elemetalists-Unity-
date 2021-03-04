using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSpeed : MonoBehaviour
{
    public bool IsSpeedUp = false;

    public Sprite SpeedOne;
    public Sprite SpeedTwo;
    public Button Button;

    public void Start()
    {
        Time.timeScale = 1f;
    }
    /*public void IncreaseGameSpeed()
    {
        if (IsSpeedUp == true)
        {
            IsSpeedUp = false;
            Time.timeScale = 1f;
            Button.image.sprite = SpeedOne;
        }
        else
        {
            IsSpeedUp = true;
            Time.timeScale = 2f;
            Button.image.sprite = SpeedTwo;
        }
    }*/
}
