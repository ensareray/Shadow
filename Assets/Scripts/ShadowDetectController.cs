using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowDetectController : MonoBehaviour
{
	[SerializeField] Transform target;
	[SerializeField] uint rayDistance;

	//Oyuncu gölgede mi ışıkta mı onu anlamaya çalışıyoruz.
	//Şu anda direk gövdeye bağlı ama kafaya yönelmeli.	
    void Update()
    {
		Vector3 dir = target.position - transform.position;
		RaycastHit hit;
		if(Physics.Raycast(transform.position, dir, out hit, rayDistance ))
		{
			if(hit.transform.CompareTag("Player"))
			{
				//End Game - Player Dies
				Debug.Log("I can see youu");
			}
		}
    }
	void OnDrawGizmos()
	{
		Gizmos.DrawLine(transform.position,target.position);
	}
}
