using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldOreMOneyMaking : MonoBehaviour
{
    public int MoneyAmount = 5;

    public GameManagerSc GameManagerSc;

    void Start()
    {
        if (gameObject.activeSelf == true)
        {
            InvokeRepeating("MakeMoney", 2, 2);
        }
    }
    void MakeMoney()
    {
        GameManagerSc.Money = GameManagerSc.Money + MoneyAmount;
    }
}
