using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenuCloseSc : MonoBehaviour
{
    public BuildingScript BuildingSc;

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
        if(BuildingSc.IsOpenNow == true)
        {
            if (OnMenuExit == true && OnMenuStay == false)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    BuildingSc.BuildMenu.active = false;
                    BuildMenuOpen = false;
                    BuildingSc.IsOpenNow = false;
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
