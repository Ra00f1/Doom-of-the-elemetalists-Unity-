using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsSystem : MonoBehaviour
{
    public static Transform[] Waypoints;

    public void Awake()
    {
        Waypoints = new Transform[transform.childCount];

        for (int i = 0; i<Waypoints.Length; i++)

        {
            Waypoints[i] = transform.GetChild(i);
        }
    }
}
