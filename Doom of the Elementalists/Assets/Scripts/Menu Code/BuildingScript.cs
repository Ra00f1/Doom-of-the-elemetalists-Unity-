using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildingScript : MonoBehaviour
{
    public GameObject BuildMenu;

    public GameObject ArcherTower;
    public GameObject BombTower;
    public GameObject CrystalTower;
    public GameObject DefenderTower;

    public GameManagerSc _GameManagerSc;
    public TowerSc ArcherSc;
    public TowerSc BombTowerSc;
    public CrystalTowerSc CrystalTowerSc;
    public DefenderTowerSc DefenderTowerSc;

    public BuildMenuCloseSc BuildMenuCloseSc;

    public TextMeshProUGUI ArcherCostText;
    public TextMeshProUGUI BombCostText;
    public TextMeshProUGUI CrystalTowerText;
    public TextMeshProUGUI DefenderTowerText;

    public bool IsOpenNow = false;

    public void Start()
    {
        BuildMenu.active = false;
        IsOpenNow = false;
        ArcherCostText.text = ArcherSc.TowerCost.ToString();
        BombCostText.text = BombTowerSc.TowerCost.ToString();
        CrystalTowerText.text = CrystalTowerSc.TowerCost.ToString();
        DefenderTowerText.text = DefenderTowerSc.TowerCost.ToString();
    }
    public void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && IsOpenNow == false)
        {
            BuildMenu.active = true;
            BuildMenuCloseSc.BuildMenuOpen = true;
            IsOpenNow = true; 
        }
    }

    public void ArcherTowerChoice()
    {
        if (_GameManagerSc.Money >= ArcherSc.TowerCost)
        {
            _GameManagerSc.Money -= ArcherSc.TowerCost;
            GameObject NewTower = Instantiate(ArcherTower, transform.position, transform.rotation);
            gameObject.transform.parent = NewTower.transform;
            SellAndUpgradeScript SellScript = NewTower.GetComponent<SellAndUpgradeScript>();
            IsOpenNow = false;
            BuildMenu.active = false;
            gameObject.active = false;
        }
    }

    public void BombTowerChoice()
    {
        if (_GameManagerSc.Money >= BombTowerSc.TowerCost)
        {
            _GameManagerSc.Money -= BombTowerSc.TowerCost;
            GameObject NewTower = Instantiate(BombTower, transform.position, transform.rotation);
            gameObject.transform.parent = NewTower.transform;
            SellAndUpgradeScript SellScript = NewTower.GetComponent<SellAndUpgradeScript>();
            IsOpenNow = false;
            BuildMenu.active = false;
            gameObject.active = false;
        }
    }

    public void CrystalTowerChoice()
    {
        if (_GameManagerSc.Money >= ArcherSc.TowerCost)
        {
            _GameManagerSc.Money -= CrystalTowerSc.TowerCost;
            GameObject NewTower = Instantiate(CrystalTower, transform.position, transform.rotation);
            gameObject.transform.parent = NewTower.transform;
            SellAndUpgradeScript SellScript = NewTower.GetComponent<SellAndUpgradeScript>();
            IsOpenNow = false;
            BuildMenu.active = false;
            gameObject.active = false;
        }
    }

    public void DefenderTowerChoice()
    {
        if (_GameManagerSc.Money >= DefenderTowerSc.TowerCost)
        {
            _GameManagerSc.Money -= DefenderTowerSc.TowerCost;
            GameObject NewTower = Instantiate(DefenderTower, transform.position, transform.rotation);
            gameObject.transform.parent = NewTower.transform;
            SellAndUpgradeScript SellScript = NewTower.GetComponent<SellAndUpgradeScript>();
            IsOpenNow = false;
            BuildMenu.active = false;
            gameObject.active = false;
        }
    }
}
