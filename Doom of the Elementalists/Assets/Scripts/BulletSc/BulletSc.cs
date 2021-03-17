using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class BulletSc : MonoBehaviour
{
    private Transform Target;
    private float RotationSpeed = 100f;
    private float damage;
    private float magicalDamage;
    private float physicalDamage;
    private Vector3 TowerPosition;
    private GameObject TargetGO;

    public AudioClip AudioClip;
    public float BulletSpeed = 70f;

    public void seek(Transform _Target, GameObject _TargetGO)
    {
        Target = _Target;
        TargetGO = _TargetGO;
    }
    public void GetDamage(float _Damage, float PhysicalDamageAmount, float MagicalDamageAmount)
    {
        damage = _Damage;
        physicalDamage = PhysicalDamageAmount;
        magicalDamage = MagicalDamageAmount;
    }
    public void GetTowerPosition(Vector3 _Towerposition)
    {
        TowerPosition = _Towerposition;
    }
    void Update()
    {
        if (Target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = Target.position - transform.position;
        float TravelDistance = BulletSpeed * Time.deltaTime;
        if (dir.magnitude <= TravelDistance)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * TravelDistance, Space.World);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * RotationSpeed);
    }
    void HitTarget()
    {
        float ExplosionRadius = 100f;
        Vector3 center = gameObject.transform.position;
        Collider2D[] HitColliders = Physics2D.OverlapCircleAll(center, ExplosionRadius);
        for (int i = 0; i < HitColliders.Length; i++)
        {
            if (HitColliders[i].tag == "Attackers")
            {
                Enemy enemySc = HitColliders[i].gameObject.GetComponent<Enemy>();
                enemySc.Getdamaged(damage, physicalDamage, magicalDamage);
                AudioSource.PlayClipAtPoint(AudioClip, TowerPosition, 1f);
                Destroy(gameObject);
            }
        }
    }
}