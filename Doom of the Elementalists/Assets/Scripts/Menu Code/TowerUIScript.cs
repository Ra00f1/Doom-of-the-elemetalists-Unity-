using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUIScript : MonoBehaviour
{
    public TowerSc towerSc;
    public GameObject TowerUI;
    public bool IsOpenNow;
    public TowerUIScriptClose TowerUIScriptClose;
    void Start()
    {
        TowerUI.active = false;
        towerSc = gameObject.GetComponent<TowerSc>();
        IsOpenNow = false;
    }
    public void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && IsOpenNow == false)
        {
            TowerUI.active = true;
            towerSc.TowerRangeGO.active = true;
            TowerUIScriptClose.BuildMenuOpen = true;
            IsOpenNow = true; 
        }
    }
}
