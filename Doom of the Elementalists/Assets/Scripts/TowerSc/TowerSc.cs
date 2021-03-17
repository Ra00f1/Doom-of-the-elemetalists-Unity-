using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSc : MonoBehaviour
{
    [Header("Attrebiutes")]

    public float range = 50f;
    public float FireCountDown = 0f;
    public float FireRate = 1f;
    public float Damage = 10f;
    public float PhysicalDamage;
    public float MagicalDamage;
    public float RotationSpeed = 90f;

    public int TowerCost = 50;
    public int ATowerUpgradeCost1 = 50;
    public int ATowerUpgradeCost2 = 70;
    public int ATowerUpgradeCost3 = 100;
    public int BTowerUpgradeCost1 = 80;
    public int BTowerUpgradeCost2 = 100;
    public int BTowerUpgradeCost3 = 150;

    [Header("Unity Stuff")]

    public Transform target;
    public Transform thistower;
    public Transform FirePoint;

    public GameObject ArrowPrefab;
    public GameObject RotatablePart;
    public GameObject TowerRangeGO;

    private SpriteRenderer TowerRangeSpriteRenderer;

    public string enemyTag = "Attackers";

    private float dir2;
    private GameObject TargetGO;

    [System.Obsolete]
    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.3f);
        TowerRangeSpriteRenderer = TowerRangeGO.GetComponent<SpriteRenderer>();

        TowerRangeGO.active = false;
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestdistance = Mathf.Infinity;

        GameObject nearestenemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestdistance)
            {
                shortestdistance = distanceToEnemy;
                nearestenemy = enemy;
            }
        }

        if (nearestenemy != null && shortestdistance <= range)
        {
            target = nearestenemy.transform;
            TargetGO = nearestenemy.gameObject;
        }
        else
        {
            target = null;
            TargetGO = null;
        }
    }

    private void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 vectorToTarget = target.position - RotatablePart.transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        RotatablePart.transform.rotation = Quaternion.Slerp(RotatablePart.transform.rotation, q, Time.deltaTime * RotationSpeed);

        if (FireCountDown <= 0)
        {
            Shoot();
            FireCountDown = 1f / FireRate;
        }

        FireCountDown -= Time.deltaTime;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void Shoot()
    {
        GameObject BulletGO = (GameObject)Instantiate(ArrowPrefab, FirePoint.position, FirePoint.rotation);
        if (gameObject.tag == "ArcherTower")
        {
            NormalBullet _Bullet = BulletGO.GetComponent<NormalBullet>();
            if (_Bullet != null)
            {
                _Bullet.seek(target, TargetGO);
                _Bullet.GetDamage(Damage, PhysicalDamage, MagicalDamage);
                _Bullet.GetTowerPosition(gameObject.transform.position);
            }
        }
        if (gameObject.tag == "BomberTower")
        {
            BulletSc _Bullet = BulletGO.GetComponent<BulletSc>();
            if (_Bullet != null)
            {
                _Bullet.seek(target, TargetGO);
                _Bullet.GetDamage(Damage, PhysicalDamage, MagicalDamage);
                _Bullet.GetTowerPosition(gameObject.transform.position);
            }
        }
        if (gameObject.tag == "CrystalTower")
        {
            NormalBullet _Bullet = BulletGO.GetComponent<NormalBullet>();
            if (_Bullet != null)
            {
                _Bullet.seek(target, TargetGO);
                _Bullet.GetDamage(Damage, PhysicalDamage, MagicalDamage);
                _Bullet.GetTowerPosition(gameObject.transform.position);
            }
        }
    }
}
