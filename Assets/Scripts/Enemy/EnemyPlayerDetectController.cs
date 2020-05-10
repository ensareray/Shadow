using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// Only for detecting player in front of enemy.
///</summary>
public class EnemyPlayerDetectController : MonoBehaviour
{
    Transform target;
    bool isDetected;
    [SerializeField]float sightDist, hightMultiplier;
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform; 
    }
    
    void Update()
    {
        SearchPlayer();
    }
    void SearchPlayer()
    {
        Debug.DrawRay(transform.position + Vector3.up * hightMultiplier, transform.forward * sightDist, Color.green);
        Debug.DrawRay(transform.position + Vector3.up * hightMultiplier, (transform.forward + transform.right ).normalized * sightDist, Color.green);
        Debug.DrawRay(transform.position + Vector3.up * hightMultiplier, (transform.forward - transform.right ).normalized * sightDist, Color.green);
        RaycastHit hit;
        if(Physics.Raycast(transform.position + Vector3.up * hightMultiplier, transform.forward, out hit, sightDist ))
        {
            if(hit.transform.CompareTag("Player"))
            {
                Debug.Log("Player detected");
            }
        }
        if(Physics.Raycast(transform.position + Vector3.up * hightMultiplier, (transform.forward + transform.right ).normalized, out hit, sightDist ))
        {
            if(hit.transform.CompareTag("Player"))
            {
                Debug.Log("Player detected");
            }
        }
        if(Physics.Raycast(transform.position + Vector3.up * hightMultiplier, (transform.forward - transform.right ).normalized, out hit, sightDist ))
        {
            if(hit.transform.CompareTag("Player"))
            {
                Debug.Log("Player detected");
            }
        }
    }
     void OnDrawGizmos()
    {
        /* Gizmos.DrawLine( transform.position 
            ,new Vector3(transform.position.x,transform.position.y,transform.position.z + sightConstraints.z) );

        Gizmos.DrawLine( new Vector3(transform.position.x - sightConstraints.x,transform.position.y,transform.position.z) 
            ,new Vector3(transform.position.x + sightConstraints.x,transform.position.y,transform.position.z) );

        Gizmos.DrawLine( new Vector3(transform.position.x ,transform.position.y -sightConstraints.y,transform.position.z) 
            ,new Vector3(transform.position.x ,transform.position.y+sightConstraints.y,transform.position.z) ); */
		//Gizmos.DrawLine(transform.position,target.position);
    } 

}
