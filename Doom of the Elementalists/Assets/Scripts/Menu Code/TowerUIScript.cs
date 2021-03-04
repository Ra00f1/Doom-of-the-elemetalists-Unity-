using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUIScript : MonoBehaviour
{
    public GameObject TowerUI;
    public bool IsOpenNow;
    public TowerUIScriptClose TowerUIScriptClose;
    void Start()
    {
        TowerUI.active = false;
        IsOpenNow = false;
    }
    public void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && IsOpenNow == false)
        {
            TowerUI.active = true;
            TowerUIScriptClose.BuildMenuOpen = true;
            IsOpenNow = true; 
        }
    }
}
