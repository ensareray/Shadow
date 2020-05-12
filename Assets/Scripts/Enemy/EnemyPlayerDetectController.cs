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
    [SerializeField] float sightDist, hightMultiplier, waitingTimeWhenContact;
    [SerializeField] EnemyRoamingController roamingController;
    [SerializeField] float fieldOfWiewAngle;

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
        Vector3 dir = target.position - transform.position;
		float angle = Vector3.Angle(dir, transform.forward);
		if(angle < fieldOfWiewAngle * 0.5f && isDetected == false)
		{
            RaycastHit hit;
            if(Physics.Raycast(transform.position, dir, out hit, sightDist ))
            {
                if(hit.transform.CompareTag("Player"))
                {
                    //End Game - Player Dies
                    Debug.DrawRay(transform.position, dir,Color.green);
                    Debug.Log("I saw Him");
                    ISawPlayer();
                }
            }	
        }
    }
    void ISawPlayer()
    {
        isDetected = true;
        //Dur
        roamingController.EnemyStop();
        //Oyuncuyu uyar
        //yarım saniye bekle
        StartCoroutine(WaitWhenYouSee());
    }
    IEnumerator WaitWhenYouSee()
    {
        yield return new WaitForSeconds(waitingTimeWhenContact);
        //oyuncuya bak ve fenerini ona tut
        transform.LookAt(target);
        yield return new WaitForSeconds(waitingTimeWhenContact);
        roamingController.EnemyResume();
        isDetected = false;
    }
}
