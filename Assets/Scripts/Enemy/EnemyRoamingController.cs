using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

///<summary>
/// Only Controls enemys raoiming between deteinated points.
///</summary>
public class EnemyRoamingController : MonoBehaviour
{
    [SerializeField]Transform[] roamingPoints;
    [SerializeField] NavMeshAgent navAgent;
    [SerializeField]int currentRoamingPoint = 0;
    bool isArrived,isDestineted;
    [SerializeField] float reachedDistance,waitTimeWhenReachedToPoint;
    void Start()
    {
        Roam();
    }

    void Update()
    {
        IsPointReached();
    }
    
    void IsPointReached()
    {
        //Eğer aradaki mesafe ulaşma mesafesinden küçükse  
        if(Vector3.Distance(transform.position,roamingPoints[currentRoamingPoint].position) <= reachedDistance  && isArrived == false)
        {
            Debug.Log("reached");
            isArrived = true;
            //Ajan durdu
            navAgent.isStopped = true;
            DestinateToNextPoint();
            StartCoroutine( WaitWhenPointReached() );
        }
    }
    void DestinateToNextPoint()
    {
        currentRoamingPoint++;
        
        if(currentRoamingPoint >= roamingPoints.Length)
        {
            currentRoamingPoint = 0;
        }
        
        navAgent.destination = roamingPoints[currentRoamingPoint].position;
        isDestineted = true;
    }
    //Eğer bi nokta atanmamışsa ata ve git 
    //atanmışsa direk git
    void Roam()
    {
        isArrived = false;
        if(isDestineted == false)
        {
            navAgent.destination = roamingPoints[currentRoamingPoint].position;
            isDestineted = true;
            navAgent.isStopped = false;
        }
        else
        {
            navAgent.isStopped = false;
        }
    }
    IEnumerator WaitWhenPointReached()
    {
        yield return new WaitForSeconds(waitTimeWhenReachedToPoint);
        Roam();
    }
    public void EnemyStop()
    {
        navAgent.isStopped = true;
    }
    public void EnemyResume()
    {
        navAgent.isStopped = false;
    }
}
