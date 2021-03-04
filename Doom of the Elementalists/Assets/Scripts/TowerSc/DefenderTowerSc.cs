using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderTowerSc : MonoBehaviour
{
    [Header("Attrebiutes")]

    public float range = 50f;
    public float FireCountDown = 0f;
    public float FireRate = 1f;
    public float Damage = 0f;

    public int TowerCost = 50;
    public int DTowerUpgradeCost1 = 55;
    public int DTowerUpgradeCost2 = 80;
    public int DTowerUpgradeCost3 = 110;

    [Header("Unity Stuff")]

    public Transform target;
    public Transform FirePoint;

    public GameObject ArrowPrefab;
    public string enemyTag = "Attackers";

    Enemy EnemySc;

    [System.Obsolete]
    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.01f);
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        foreach (GameObject enemy in enemies)
        {
            float dis = Vector3.Distance(gameObject.transform.position, enemy.transform.position);
            EnemySc = enemy.GetComponent<Enemy>();
            if (dis < range && EnemySc.Slowed == false)
            {
                EnemySc.Slowed = true;
            }
            if (dis > range)
            {
                EnemySc.Slowed = false;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
