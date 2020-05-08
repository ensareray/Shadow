using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRoamingController : MonoBehaviour
{
    [SerializeField]Transform[] roamingPoints;
    [SerializeField] NavMeshAgent navAgent;
    [SerializeField]int currentRoamingPoint = 0;
    bool walking;

    void Start()
    {
        walking = true;
    }
    void Update()
    {
        while(walking == true)
        {
            Roam();
        }
    }
    void RoamToNextPoint()
    {
        currentRoamingPoint++;
        if(currentRoamingPoint >= roamingPoints.Length)
        {
            currentRoamingPoint = 0;
        }
    }
    void Roam()
    {
        navAgent.destination = roamingPoints[currentRoamingPoint].position;
        navAgent.isStopped = false;
    }
}
