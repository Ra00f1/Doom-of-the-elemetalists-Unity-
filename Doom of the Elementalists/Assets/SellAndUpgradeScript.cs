using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SellAndUpgradeScript : MonoBehaviour
{
    private GameManagerSc GameManagerScript;

    private GameObject GamemnanegerObject;
    public GameObject BuildableSpot = null;

    public Transform Temp;
    
    private int Towercost;
    private int UpgradedTimes = 0;
    private int UpgradeCost;
    private int refund;

    private float TowerDamage;
    private float TowerFireRate;
    private float TowerRange;
    private float PhysicalDamage;
    private float MagicalDamage;

    public TextMeshProUGUI RefundAmount; 
    public TextMeshProUGUI UpgradeCostText;

    public Button UpgradeButton;

    public Image UpgradePic1;
    public Image UpgradePic2;
    public Image UpgradePic3;

    public bool sell = false;
    private bool gotbuildspot = false;

    void Start()
    {
        gotbuildspot = false;
        GamemnanegerObject = GameObject.Find("GameManagerObject");
        GameManagerScript = GamemnanegerObject.GetComponent < GameManagerSc> ();

        UpgradePic1.enabled = false;
        UpgradePic2.enabled = false;
        UpgradePic3.enabled = false;

        if (gameObject.tag == "ArcherTower")
        {
            TowerSc TowerSc = gameObject.GetComponent<TowerSc>();
            Towercost = TowerSc.TowerCost;
            TowerDamage = TowerSc.Damage;
            TowerFireRate = TowerSc.FireRate;
            TowerRange = TowerSc.range;
            PhysicalDamage = TowerSc.PhysicalDamage;
            MagicalDamage = TowerSc.MagicalDamage;
            UpgradeCost = TowerSc.ATowerUpgradeCost1;
            refund = Towercost/2;
            RefundAmount.SetText(refund.ToString());
            UpgradeCostText.SetText(UpgradeCost.ToString());
        }
        if (gameObject.tag == "BomberTower")
        {
            TowerSc TowerSc = gameObject.GetComponent<TowerSc>();
            Towercost = TowerSc.TowerCost;
            TowerDamage = TowerSc.Damage;
            TowerRange = TowerSc.range;
            PhysicalDamage = TowerSc.PhysicalDamage;
            MagicalDamage = TowerSc.MagicalDamage;
            UpgradeCost = TowerSc.BTowerUpgradeCost1;
            refund = Towercost/2;
            RefundAmount.SetText(refund.ToString());
            UpgradeCostText.SetText(UpgradeCost.ToString());
        }
        if (gameObject.tag == "CrystalTower")
        {
            CrystalTowerSc CrystalTowerScript = gameObject.GetComponent<CrystalTowerSc>();
            Towercost = CrystalTowerScript.TowerCost;
            TowerDamage = CrystalTowerScript.Damage;
            TowerRange = CrystalTowerScript.range;
            PhysicalDamage = CrystalTowerScript.PhysicalDamage;
            MagicalDamage = CrystalTowerScript.MagicalDamage;
            UpgradeCost = CrystalTowerScript.CTowerUpgradeCost1;
            refund = Towercost/2;
            RefundAmount.SetText(refund.ToString());
            UpgradeCostText.SetText(UpgradeCost.ToString());
        }
        //DefenderTower Only has dmage/range and not phy and magical damage types
        if (gameObject.tag == "DefenderTower")
        {
            DefenderTowerSc DefenderTowerScript = gameObject.GetComponent<DefenderTowerSc>();
            Towercost = DefenderTowerScript.TowerCost;
            TowerDamage = DefenderTowerScript.Damage;
            TowerRange = DefenderTowerScript.range;
            UpgradeCost = DefenderTowerScript.DTowerUpgradeCost1;
            refund = Towercost/2;
            RefundAmount.SetText(refund.ToString());
            UpgradeCostText.SetText(UpgradeCost.ToString());
        }
    }

    void Update()
    {
        if (BuildableSpot == null && gotbuildspot == false)
        {
            foreach (Transform child in transform)
            {
                if (child.tag == "BuildablePlaces")
                {
                    BuildableSpot = child.gameObject;
                    gotbuildspot = true;
                }
            }
        }
    }

    public void SellTower()
    {
        sell = true;
        MakeParent();
        GameManagerScript.Money += Towercost / 2;
        Debug.Log("Sell Complete");
        Destroy(gameObject);
    }

    public void MakeParent()
    {
        BuildableSpot.active = true;
        GameObject ParentToBe = BuildableSpot;
            ParentToBe.transform.parent = null;
            gameObject.transform.parent = ParentToBe.transform;
    }

    public void UpgradeTower()
    {
        if(GameManagerScript.Money >= UpgradeCost)
        {
         if(UpgradedTimes == 2)
        {
            if(gameObject.tag == "ArcherTower")
            {
                TowerSc TowerSc = gameObject.GetComponent<TowerSc>();
                
                TowerDamage = 9;
                TowerRange = 300;
                TowerFireRate = 2f;
                PhysicalDamage = 9;
                MagicalDamage = 1;

                TowerSc.Damage = TowerDamage;
                TowerSc.range = TowerRange;
                TowerSc.FireRate = TowerFireRate;
                TowerSc.PhysicalDamage = PhysicalDamage;
                TowerSc.MagicalDamage = MagicalDamage;

                GameManagerScript.Money -= UpgradeCost;

                UpgradePic3.enabled = true;

                UpgradedTimes++;

                UpgradeButton.interactable = false;
                UpgradeCostText.enabled = false;
            }
            if(gameObject.tag == "BomberTower")
            {
                TowerSc TowerSc = gameObject.GetComponent<TowerSc>();
                
                TowerDamage = 16;
                TowerRange = 200;
                TowerFireRate = 0.7f;
                PhysicalDamage = 16;
                MagicalDamage = 3;

                TowerSc.Damage = TowerDamage;
                TowerSc.range = TowerRange;
                TowerSc.FireRate = TowerFireRate;
                TowerSc.PhysicalDamage = PhysicalDamage;
                TowerSc.MagicalDamage = MagicalDamage;

                GameManagerScript.Money -= UpgradeCost;

                UpgradePic3.enabled = true;

                UpgradedTimes++;

                UpgradeButton.interactable = false;
                UpgradeCostText.enabled = false;
            }
            if(gameObject.tag == "CrystalTower")
            {
                CrystalTowerSc crystalTowerSc = gameObject.GetComponent<CrystalTowerSc>();
                
                TowerDamage = 14;
                TowerRange = 155;
                TowerFireRate = 0.65f;
                PhysicalDamage = 3;
                MagicalDamage = 21;

                crystalTowerSc.Damage = TowerDamage;
                crystalTowerSc.range = TowerRange;
                crystalTowerSc.FireRate = TowerFireRate;
                crystalTowerSc.PhysicalDamage = PhysicalDamage;
                crystalTowerSc.MagicalDamage = MagicalDamage;

                GameManagerScript.Money -= UpgradeCost;

                UpgradePic3.enabled = true;

                UpgradedTimes++;

                UpgradeButton.interactable = false;
                UpgradeCostText.enabled = false;
            }
            if(gameObject.tag == "DefenderTower")
            {
                DefenderTowerSc defenderTowerSc = gameObject.GetComponent<DefenderTowerSc>();
                
                TowerRange = 300;

                defenderTowerSc.Damage = TowerDamage;
                defenderTowerSc.range = TowerRange;
                defenderTowerSc.FireRate = TowerFireRate;

                GameManagerScript.Money -= UpgradeCost;

                UpgradePic3.enabled = true;

                UpgradedTimes++;

                UpgradeButton.interactable = false;
                UpgradeCostText.enabled = false;
            }
        }
        if(UpgradedTimes == 1)
        {
            if(gameObject.tag == "ArcherTower")
            {
                TowerSc TowerSc = gameObject.GetComponent<TowerSc>();
                
                TowerDamage = 8;
                TowerRange = 270;
                TowerFireRate = 1.7f;
                PhysicalDamage = 8;
                MagicalDamage = 0;

                TowerSc.Damage = TowerDamage;
                TowerSc.range = TowerRange;
                TowerSc.FireRate = TowerFireRate;
                TowerSc.PhysicalDamage = PhysicalDamage;
                TowerSc.MagicalDamage = MagicalDamage;

                GameManagerScript.Money -= UpgradeCost;

                UpgradeCost = TowerSc.ATowerUpgradeCost3;
                UpgradeCostText.SetText(UpgradeCost.ToString());

                UpgradePic2.enabled = true;

                UpgradedTimes++;    
            }
            if(gameObject.tag == "BomberTower")
            {
                TowerSc TowerSc = gameObject.GetComponent<TowerSc>();
                
                TowerDamage = 14;
                TowerRange = 175;
                TowerFireRate = 0.65f;
                PhysicalDamage = 14;
                MagicalDamage = 2;

                TowerSc.Damage = TowerDamage;
                TowerSc.range = TowerRange;
                TowerSc.FireRate = TowerFireRate;
                TowerSc.PhysicalDamage = PhysicalDamage;
                TowerSc.MagicalDamage = MagicalDamage;

                GameManagerScript.Money -= UpgradeCost;

                UpgradeCost = TowerSc.BTowerUpgradeCost3;
                UpgradeCostText.SetText(UpgradeCost.ToString());

                UpgradePic2.enabled = true;

                UpgradedTimes++;    
            }
            if(gameObject.tag == "CrystalTower")
            {
                CrystalTowerSc crystalTowerSc = gameObject.GetComponent<CrystalTowerSc>();
                
                TowerDamage = 13;
                TowerRange = 150;
                TowerFireRate = 0.6f;
                PhysicalDamage = 2;
                MagicalDamage = 19;

                crystalTowerSc.Damage = TowerDamage;
                crystalTowerSc.range = TowerRange;
                crystalTowerSc.FireRate = TowerFireRate;
                crystalTowerSc.PhysicalDamage = PhysicalDamage;
                crystalTowerSc.MagicalDamage = MagicalDamage;

                GameManagerScript.Money -= UpgradeCost;
                
                UpgradeCost = crystalTowerSc.CTowerUpgradeCost3;
                UpgradeCostText.SetText(UpgradeCost.ToString());

                UpgradePic2.enabled = true;

                UpgradedTimes++;
            }
            if(gameObject.tag == "DefenderTower")
            {
                DefenderTowerSc defenderTowerSc = gameObject.GetComponent<DefenderTowerSc>();
                
                TowerRange = 260;

                defenderTowerSc.Damage = TowerDamage;
                defenderTowerSc.range = TowerRange;
                defenderTowerSc.FireRate = TowerFireRate;

                GameManagerScript.Money -= UpgradeCost;

                UpgradeCost = defenderTowerSc.DTowerUpgradeCost3;
                UpgradeCostText.SetText(UpgradeCost.ToString());

                UpgradePic2.enabled = true;

                UpgradedTimes++;
            }
        }
        if(UpgradedTimes == 0)
        {
            if(gameObject.tag == "ArcherTower")
            {
                TowerSc TowerSc = gameObject.GetComponent<TowerSc>();

                TowerDamage = 7;
                TowerRange = 250;
                TowerFireRate = 1.4f;
                PhysicalDamage = 7;
                MagicalDamage = 0;

                TowerSc.Damage = TowerDamage;
                TowerSc.range = TowerRange;
                TowerSc.FireRate = TowerFireRate;
                TowerSc.PhysicalDamage = PhysicalDamage;
                TowerSc.MagicalDamage = MagicalDamage;

                //TowerSc.TowerRangeGO.transform.localScale.x = 250f;

                GameManagerScript.Money -= UpgradeCost;

                UpgradeCost = TowerSc.ATowerUpgradeCost2;
                UpgradeCostText.SetText(UpgradeCost.ToString());

                UpgradePic1.enabled = true;

                UpgradedTimes++;
            }
            if(gameObject.tag == "BomberTower")
            {
                TowerSc TowerSc = gameObject.GetComponent<TowerSc>();

                TowerDamage = 12;
                TowerRange = 150;
                TowerFireRate = 0.6f;
                PhysicalDamage = 12;
                MagicalDamage = 1;

                TowerSc.Damage = TowerDamage;
                TowerSc.range = TowerRange;
                TowerSc.FireRate = TowerFireRate;
                TowerSc.PhysicalDamage = PhysicalDamage;
                TowerSc.MagicalDamage = MagicalDamage;

                GameManagerScript.Money -= UpgradeCost;

                UpgradeCost = TowerSc.BTowerUpgradeCost2;
                UpgradeCostText.SetText(UpgradeCost.ToString());

                UpgradePic1.enabled = true;

                UpgradedTimes++;
            }
            if(gameObject.tag == "CrystalTower")
            {
                CrystalTowerSc crystalTowerSc = gameObject.GetComponent<CrystalTowerSc>();
                
                TowerDamage = 12;
                TowerRange = 145;
                TowerFireRate = 0.55f;
                PhysicalDamage = 1;
                MagicalDamage = 17;

                crystalTowerSc.Damage = TowerDamage;
                crystalTowerSc.range = TowerRange;
                crystalTowerSc.FireRate = TowerFireRate;
                crystalTowerSc.PhysicalDamage = PhysicalDamage;
                crystalTowerSc.MagicalDamage = MagicalDamage;

                GameManagerScript.Money -= UpgradeCost;
                
                UpgradeCost = crystalTowerSc.CTowerUpgradeCost2;
                UpgradeCostText.SetText(UpgradeCost.ToString());

                UpgradePic1.enabled = true;

                UpgradedTimes++;
            }
            if(gameObject.tag == "DefenderTower")
            {
                DefenderTowerSc defenderTowerSc = gameObject.GetComponent<DefenderTowerSc>();
                
                TowerRange = 230;

                defenderTowerSc.Damage = TowerDamage;
                defenderTowerSc.range = TowerRange;
                defenderTowerSc.FireRate = TowerFireRate;

                GameManagerScript.Money -= UpgradeCost;
                
                UpgradeCost = defenderTowerSc.DTowerUpgradeCost2;
                UpgradeCostText.SetText(UpgradeCost.ToString());

                UpgradePic1.enabled = true;

                UpgradedTimes++;
            }
        }
        
        }
    }
}
