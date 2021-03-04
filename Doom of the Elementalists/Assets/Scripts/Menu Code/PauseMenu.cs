using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PuaseMenu;

    private int SceneNo;
    private void Start()
    {
        PuaseMenu.active = false;
        SceneNo = SceneManager.GetActiveScene().buildIndex;
    }

    public void RestartB()
    {
        SceneManager.LoadScene(SceneNo);
    }
    public void MainMenuB()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitB()
    {
        Application.Quit();
    }

    public void MenuCloseB()
    {
        PuaseMenu.active = false;
    }
}
