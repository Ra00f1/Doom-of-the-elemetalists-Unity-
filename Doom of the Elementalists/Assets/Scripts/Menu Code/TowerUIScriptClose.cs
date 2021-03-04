using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUIScriptClose : MonoBehaviour
{
    public TowerUIScript TowerUISc;

    public CircleCollider2D CircleCollider;

    public bool BuildMenuOpen;
    public bool OnMenuStay;
    public bool OnMenuExit;


    private void Start()
    {

    }
    [System.Obsolete]
    private void Update()
    {
        if (TowerUISc.IsOpenNow == true)
        {
            if (OnMenuExit == true && OnMenuStay == false)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    TowerUISc.TowerUI.active = false;
                    BuildMenuOpen = false;
                    TowerUISc.IsOpenNow = false;
                    OnMenuExit = false;
                }
            }
        }
    }
    private void OnMouseOver()
    {
        OnMenuStay = true;
        OnMenuExit = false;
    }
    private void OnMouseExit()
    {
        OnMenuExit = true;
        OnMenuStay = false;
    }
}
