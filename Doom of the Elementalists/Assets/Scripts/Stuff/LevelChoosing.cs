using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChoosing : MonoBehaviour
{
    public GameObject GameOverScreen;

    private bool GameOver = false;

    [System.Obsolete]
    private void Start()
    {
        GameOverScreen.active = false;
        GameOver = false;
    }
}
