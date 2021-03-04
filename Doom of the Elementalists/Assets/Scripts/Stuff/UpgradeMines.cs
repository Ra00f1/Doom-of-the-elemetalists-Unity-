using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMines : MonoBehaviour
{
    public GameObject Mine1;
    public GameObject Mine2;
    public GameObject Mine3;
    public GameObject Mine4;
    public GameObject Mine5;

    public int MineCount = 1;
    public int MineUpgradeCount = 0;
    public int MineUnlockCost = 30;

    public TextMeshProUGUI UpgradeCostText;
    public TextMeshProUGUI UpgradeText;
    public TextMeshProUGUI AllUnlockedText;

    public GameManagerSc GameManagerSc;

    [System.Obsolete]
    public void UpgradeButton()
    {
        if (MineCount == 4)
        {
            if (GameManagerSc.Money >= MineUnlockCost)
            {
                Mine5.active = true;
                GameManagerSc.Money = GameManagerSc.Money - MineUnlockCost;
                UpgradeCostText.gameObject.active = false;
                UpgradeText.gameObject.active = false;
                AllUnlockedText.gameObject.active = true;
                MineCount++;
            }
        }
        if (MineCount == 3)
        {
            if (GameManagerSc.Money >= MineUnlockCost)
            {
                Mine4.active = true;
                GameManagerSc.Money = GameManagerSc.Money - MineUnlockCost;
                MineUnlockCost = MineUnlockCost + 40;
                UpgradeCostText.SetText("cost: " + MineUnlockCost.ToString());
                MineCount++;
            }
        }
        if (MineCount == 2)
        {
            if (GameManagerSc.Money >= MineUnlockCost)
            {
                Mine3.active = true;
                GameManagerSc.Money = GameManagerSc.Money - MineUnlockCost;
                MineUnlockCost = MineUnlockCost + 30;
                UpgradeCostText.SetText("cost: " + MineUnlockCost.ToString());
                MineCount++;
            }
        }
        if (MineCount == 1)
        { 
            if (GameManagerSc.Money >= MineUnlockCost)
            {
                Mine2.active = true;
                GameManagerSc.Money = GameManagerSc.Money - MineUnlockCost;
                MineUnlockCost = MineUnlockCost + 20;
                UpgradeCostText.SetText("cost: " + MineUnlockCost.ToString());
                MineCount++;
            }
        }
    }
}
