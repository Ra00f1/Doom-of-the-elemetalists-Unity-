using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject LevelSelect;
    public GameObject Mainmenu;

    public void BStart()
    {
        SceneManager.LoadScene("First Level");
    }

    public void BEXIT()
    {
        Application.Quit();
    }
    public void BLevelSelect()
    {
        Mainmenu.active = false;
        LevelSelect.active = true;
    }
    public void BLevelSelectBack()
    {
        Mainmenu.active = true;
        LevelSelect.active = false;
    }
}
