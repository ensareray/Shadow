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
        Debug.DrawRay(transform.position + Vector3.up * hightMultiplier, (transform.forward + transform.right).normalized * sightDist, Color.green);
        Debug.DrawRay(transform.position + Vector3.up * hightMultiplier, (transform.forward - transform.right).normalized * sightDist, Color.green);
        if( isDetected == false )
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up * hightMultiplier, transform.forward, out hit, sightDist))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    Debug.Log("Player detected");
                    ISawPlayer();
                }
            }
            if (Physics.Raycast(transform.position + Vector3.up * hightMultiplier, (transform.forward + transform.right).normalized, out hit, sightDist))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    Debug.Log("Player detected");
                    ISawPlayer();
                }
            }
            if (Physics.Raycast(transform.position + Vector3.up * hightMultiplier, (transform.forward - transform.right).normalized, out hit, sightDist))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    Debug.Log("Player detected");
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
