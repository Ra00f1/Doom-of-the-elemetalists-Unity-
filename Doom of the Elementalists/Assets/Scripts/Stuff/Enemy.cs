using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Attrebiutes")]

    public float speed = 10f;
    public float Health = 50f;
    public float PhysicalDefense;
    public float MagicalDefense;

    public int GoldOnDeath = 10;
    public int healthDecrease = 1;

    public bool Slowed = false;

    [Header("Unity Stuff")]

    private Transform Target;

    private int Waypointindex = 0;

    private float SpeedT = 10f;
    private float FullHealth;

    private GameManagerSc _GameManagerSc;

    private GameObject GameManagerGameObject;
    public GameObject SlowedGO;

    public Animator animator;

    public Image HealthBar;
    public Image DeathHealthbar;

    private Rigidbody2D rig;

    public bool FirstAndLastDeath = false;


    private void Start()
    {
        SlowedGO.active = false;
        FullHealth = Health;
        SpeedT = speed;
        Target = WaypointsSystem.Waypoints[0];
        FirstAndLastDeath = false;
        Slowed = false;
        rig = GetComponent<Rigidbody2D>();
        GameManagerGameObject = GameObject.Find("GameManagerObject");
        _GameManagerSc = GameManagerGameObject.GetComponent<GameManagerSc>();
    }
    private void Update()
    {
        if (gameObject.tag != "Dead Enemy" && Slowed == false)
        {
            speed = SpeedT;
        }
        if (gameObject.tag != "Dead Enemy" && Slowed == true)
        {
            speed = SpeedT / 2;
        }
        Vector3 dir = Target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, Target.position) <= 5f)
        {
            GetNextWaypoint();
        }
        if (Health <= 0)
        {
            speed = 0f;
            gameObject.tag = "Dead Enemy";
            animator.SetBool("Dead", true);
            rig.simulated = false;
            //HealthBar.fillAmount = 0f;
            Destroy(DeathHealthbar); 
            Destroy(SlowedGO);
            if (FirstAndLastDeath == false)
            {
                _GameManagerSc.Money = _GameManagerSc.Money + GoldOnDeath;
                FirstAndLastDeath = true;
            }
        }
    }

    private void GetNextWaypoint()
    {
        if (Waypointindex >= WaypointsSystem.Waypoints.Length - 1)
        {
            Destroy(gameObject);
            GameManagerSc.Health = GameManagerSc.Health - healthDecrease;
            return;
        }
        Waypointindex++;
        Target = WaypointsSystem.Waypoints[Waypointindex];
    }

    public void Getdamaged(float DamageAmount, float PhysicalDamageAmount, float MagicalDamageAmount)
    {
        float tempPD = PhysicalDamageAmount - PhysicalDefense;
        float tempMD = MagicalDamageAmount - MagicalDefense;
        if(tempPD < 0)
        {
            tempPD = 0;
        }
        if(tempMD < 0)
        {
            tempMD = 0;
        }
        Health = Health - (DamageAmount + tempPD + tempMD);
        HealthBar.fillAmount = 1 * (Health/FullHealth);
    }
}
