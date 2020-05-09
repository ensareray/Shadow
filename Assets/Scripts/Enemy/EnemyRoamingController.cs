using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
        Debug.Log("Roaming");
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
        Debug.Log("Waiting S");
        yield return new WaitForSeconds(waitTimeWhenReachedToPoint);
        Debug.Log("Waiting E");
        Roam();
    }
}
